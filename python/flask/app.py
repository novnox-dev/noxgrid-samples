# Copyright © 2026 Nox. All rights reserved.
"""NoxGrid web edition with a Python (Flask) backend.

The page loads NoxGrid from the npm CDN and talks to this server with JSON:
  GET  /api/orders        -> all orders
  POST /api/orders/save   -> { "rows": [...] } changed or new orders (upsert by id)
Data lives in a small SQLite file (orders.db) created on first run.

Run:  pip install -r requirements.txt  then  python app.py  ->  http://localhost:5000
"""

import random
import sqlite3
from datetime import date, timedelta
from pathlib import Path

from flask import Flask, abort, jsonify, render_template, request

DB = Path(__file__).with_name("orders.db")
FIELDS = ("id", "customer", "item", "qty", "price", "due", "status", "invoiced")
STATUSES = ("Received", "In production", "Shipping", "Completed")

app = Flask(__name__)


def connect():
    con = sqlite3.connect(DB)
    con.row_factory = sqlite3.Row
    return con


def init_db():
    """Creates the table with 300 made-up orders (the same ones on every first run)."""
    with connect() as con:
        con.execute(
            "CREATE TABLE IF NOT EXISTS orders (id TEXT PRIMARY KEY, customer TEXT, item TEXT, qty INTEGER,"
            " price REAL, due TEXT, status TEXT, invoiced INTEGER)"
        )
        if con.execute("SELECT COUNT(*) FROM orders").fetchone()[0]:
            return
        rnd = random.Random(7)
        items = [("Steel bracket A", 4), ("Bearing 6204", 7), ("Hydraulic hose", 18), ("Control panel", 420), ("LED module", 12)]
        rows = []
        for i in range(300):
            item, price = rnd.choice(items)
            rows.append((
                f"SO-{260001 + i}", f"Customer {'ABCDE'[rnd.randrange(5)]}", item,
                rnd.randint(1, 3) if price > 100 else 10 * rnd.randint(1, 30), price,
                (date(2026, 11, 1) + timedelta(days=rnd.randint(0, 60))).isoformat(),
                rnd.choice(STATUSES), int(rnd.random() < 0.3),
            ))
        con.executemany("INSERT INTO orders VALUES (?, ?, ?, ?, ?, ?, ?, ?)", rows)


init_db()   # also when started with "flask run"


@app.get("/")
def index():
    return render_template("index.html")


@app.get("/api/orders")
def list_orders():
    with connect() as con:
        rows = con.execute("SELECT * FROM orders ORDER BY id").fetchall()
    # invoiced is stored as 0/1; the grid's check column wants true/false
    return jsonify([{**dict(r), "invoiced": bool(r["invoiced"])} for r in rows])


def clean(row):
    """Checks one row from the browser. Never trust the client: types and ranges are checked again here."""
    try:
        out = {
            "id": str(row["id"]).strip()[:20],
            "customer": str(row.get("customer") or "")[:60],
            "item": str(row.get("item") or "")[:60],
            "qty": int(row.get("qty") or 0),
            "price": float(row.get("price") or 0),
            # a date column sends back an ISO string (or a full ISO date-time after editing): keep yyyy-MM-dd
            "due": date.fromisoformat(str(row.get("due") or "")[:10]).isoformat() if row.get("due") else None,
            "status": row.get("status") if row.get("status") in STATUSES else STATUSES[0],
            "invoiced": int(bool(row.get("invoiced"))),
        }
    except (KeyError, TypeError, ValueError):
        abort(400, "bad row")
    if not out["id"] or out["qty"] < 0 or out["price"] < 0:
        abort(400, "bad row")
    return out


@app.post("/api/orders/save")
def save_orders():
    body = request.get_json(silent=True) or {}
    rows = [clean(r) for r in body.get("rows", [])[:5000]]
    with connect() as con:
        con.executemany(
            "INSERT INTO orders VALUES (:id, :customer, :item, :qty, :price, :due, :status, :invoiced)"
            " ON CONFLICT(id) DO UPDATE SET customer=excluded.customer, item=excluded.item, qty=excluded.qty,"
            " price=excluded.price, due=excluded.due, status=excluded.status, invoiced=excluded.invoiced",
            rows,
        )
    return jsonify(saved=len(rows))


if __name__ == "__main__":
    app.run(debug=True)

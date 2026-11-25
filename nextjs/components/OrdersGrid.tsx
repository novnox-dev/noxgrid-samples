"use client";
// Copyright © 2026 Nox. All rights reserved.
// The grid draws on a canvas in the browser, so it lives in a client component.
// On the server only the empty container is rendered; the grid is created after hydration.
import { useMemo, useRef, useState } from "react";
import { NoxGridReact } from "@novnox/grid-react";
import type { NoxGrid } from "@novnox/grid";

// Free license key from https://novnox.dev/license/ (removes the license notice; not needed on localhost):
// import { setLicenseKey } from "@novnox/grid";
// setLicenseKey("NOX1....");

const customers = ["Acme Corp", "Globex", "Initech", "Umbrella", "Stark Ind."];
const statuses = ["Open", "Shipped", "On hold"];

type Order = { no: string; date: Date; customer: string; qty: number; price: number; status: string; paid: boolean };

const makeOrders = (n: number): Order[] =>
  Array.from({ length: n }, (_, i) => ({
    no: `SO-${String(i + 1).padStart(5, "0")}`,
    date: new Date(2026, 0, 1 + (i % 330)),
    customer: customers[i % customers.length],
    qty: 1 + ((i * 37) % 120),
    price: 5 + ((i * 13) % 95),
    status: statuses[i % statuses.length],
    paid: i % 4 === 0,
  }));

const columns = [
  { field: "no", header: "Order", kind: "label" as const, width: 100, align: "center" as const },
  { field: "date", header: "Date", kind: "date" as const, width: 100 },
  { field: "customer", header: "Customer", kind: "combo" as const, items: customers, width: 120 },
  { field: "qty", header: "Qty", kind: "number" as const, format: "#,##0", width: 70, minimum: 1 },
  { field: "price", header: "Unit price", kind: "number" as const, format: "#,##0.00", width: 90 },
  { field: "status", header: "Status", kind: "combo" as const, items: statuses, width: 90 },
  { field: "paid", header: "Paid", kind: "check" as const, width: 60 },
];

export default function OrdersGrid() {
  const [orders] = useState(() => makeOrders(1000));
  const [shown, setShown] = useState(true);
  const [last, setLast] = useState("Click a cell and type to edit.");
  const grid = useRef<NoxGrid | null>(null);

  // Keep the handlers object stable: a new object on every render makes the component re-subscribe.
  const on = useMemo(
    () => ({
      cellValueChanged: (e: { row: number; col: number; newValue: unknown }) =>
        setLast(`row ${e.row + 1}, col ${e.col + 1} → ${String(e.newValue)}`),
    }),
    [],
  );

  return (
    <div>
      <div style={{ display: "flex", gap: 6, marginBottom: 8, alignItems: "center" }}>
        <button onClick={() => setShown((s) => !s)}>{shown ? "Unmount grid" : "Mount grid"}</button>
        <button disabled={!shown} onClick={() => grid.current?.sort([{ col: "qty", order: "desc" }])}>Sort by qty</button>
        <span id="last" style={{ marginLeft: 8, color: "#64748b" }}>{last}</span>
        <span style={{ marginLeft: 8, color: "#64748b" }}>{orders.length} orders</span>
      </div>
      {shown && (
        <NoxGridReact
          ref={grid}
          // The container needs a height (400px by default).
          style={{ height: 420, border: "1px solid #e2e8f0", borderRadius: 8, overflow: "hidden" }}
          colorScheme="modern"
          columns={columns}
          data={orders}
          allowFilter
          on={on}
        />
      )}
    </div>
  );
}

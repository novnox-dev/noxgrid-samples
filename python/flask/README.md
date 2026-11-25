# NoxGrid web with a Python backend (Flask)

The NoxGrid web edition needs nothing special from the server: any backend that serves an HTML page and JSON works.
This sample uses Flask and SQLite (both need no setup beyond `pip install flask`).

## Run

```
pip install -r requirements.txt
python app.py
```

Open http://localhost:5000. On the first run `orders.db` is created with 300 made-up orders.

| Try | What happens |
|---|---|
| Edit cells, then **Save** | Only the changed rows are posted to `/api/orders/save` and stored in SQLite (insert or update by order number) |
| **Add order**, type an item, **Save** | The new row is inserted |
| Reload the page | The orders come back from the database with your changes |
| **Save CSV** | The grid writes the CSV in the browser (`grid.toCsv()`), no server code |

## How it works

| Side | Code |
|---|---|
| Page (`templates/index.html`) | Loads NoxGrid from the npm CDN, `grid.setData(await (await fetch('/api/orders')).json())`. Column `field` names are the JSON keys. Edited rows are collected from the `cellValueChanged` event (`grid.rowData(row)`) |
| Server (`app.py`) | `GET /api/orders` returns rows as JSON; `POST /api/orders/save` checks every value again (never trust the browser) and upserts them |

- Dates travel as `yyyy-MM-dd` strings; a `date` column shows, edits and sorts them as dates.
- SQLite stores the check box as 0/1; the server turns it into `true`/`false` for the grid.
- The same page works with Django or FastAPI: return the same JSON from your view and serve the HTML from your templates.
- For a real app add authentication and CSRF protection to the save endpoint (Flask-WTF, or Django's built-in CSRF).

## License key

Not needed on `localhost`. On a real site call `NoxGridLib.setLicenseKey('NOX1...')` before creating the grid. Free key: https://novnox.dev/license/

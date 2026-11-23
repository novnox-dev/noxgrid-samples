# NoxGrid web samples (plain HTML)

Open any page in a browser. NoxGrid loads from the npm CDN (jsDelivr), so no build step is needed.

| Page | What it shows |
|---|---|
| `erp.html` | Sales orders: formulas, sort, filter, subtotals, validation, CSV, print, 100,000 rows |
| `factory.html` | Production results: daily plan vs. actual, defect rate, conditional formatting |
| `office.html` | Department budget and expenses: several grids, formulas you can type in |

English by default. Add `?lang=ko` to the address for Korean.

To use your own copy instead of the CDN: `npm install @novnox/grid` and change the `<script src>` to `node_modules/@novnox/grid/dist/nox-grid.iife.js`.

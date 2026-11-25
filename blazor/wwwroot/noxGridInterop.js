// Copyright © 2026 Nox. All rights reserved.

// JS side of Components/NoxGridView.razor. Blazor loads it with
//   JS.InvokeAsync<IJSObjectReference>("import", "./noxGridInterop.js")
//
// The grid comes from the npm package @novnox/grid via the jsDelivr CDN.
// To serve your own copy instead (offline, intranet, strict CSP):
//   npm install @novnox/grid
//   copy node_modules/@novnox/grid/dist/nox-grid.min.js to wwwroot/lib/nox-grid/nox-grid.min.js
// and change the import to: import { NoxGrid } from './lib/nox-grid/nox-grid.min.js';
import { NoxGrid } from 'https://cdn.jsdelivr.net/npm/@novnox/grid@1.0.1/dist/nox-grid.min.js';

// Dates going to C#. Dates bound from C# stay ISO strings ("2026-06-06T00:00:00"), but a date the user types becomes a JS Date
// at local midnight. JSON would write that in UTC ("2026-03-14T15:00:00.000Z" in UTC+9, the previous day in C#), so send the
// local wall-clock time without an offset instead; C# reads it as DateTimeKind.Unspecified, the same as the bound value.
const pad = n => String(n).padStart(2, '0');
const toWire = v => (v instanceof Date
  ? `${v.getFullYear()}-${pad(v.getMonth() + 1)}-${pad(v.getDate())}T${pad(v.getHours())}:${pad(v.getMinutes())}:${pad(v.getSeconds())}`
  : v);

/** Creates the grid on the host element, binds the rows and reports cellValueChanged to [JSInvokable] OnCellValueChanged. */
export function create(host, options, rows, dotNetRef) {
  const grid = new NoxGrid(host, options);
  grid.setData(rows); // the grid reads and writes these objects through each column's field
  grid.on('cellValueChanged', e => {
    const row = grid.rowData(e.row);
    dotNetRef.invokeMethodAsync('OnCellValueChanged', {
      row: e.row,
      id: row ? String(row.id) : null,
      field: grid.columns.get(e.col).field ?? null,
      oldValue: toWire(e.oldValue),
      newValue: toWire(e.newValue),
    }).catch(() => { /* the component is gone (page left, circuit closed) */ });
  });
  return grid; // C# gets an IJSObjectReference to the grid and passes it back to the functions below
}

/** Binds new rows. */
export function setData(grid, rows) {
  grid.setData(rows);
}

/**
 * The bound rows (grid.data, with every edit) as UTF-8 JSON bytes. A Uint8Array return value reaches C# as an
 * IJSStreamReference, which is streamed in chunks. A plain return value would be one SignalR message, and on Blazor Server
 * anything over 32 KB (about 300 rows here) exceeds MaximumReceiveMessageSize and closes the circuit.
 */
export function getDataJson(grid) {
  // `this[k]` is the raw value; JSON.stringify has already turned Dates into UTC strings in `v`.
  return new TextEncoder().encode(JSON.stringify(grid.data ?? [], function (k, v) { return toWire(this[k]); }));
}

export function destroy(grid) {
  grid.destroy();
}

// NoxGrid React sample: change data through state and show grid events on the page.
// Uses createElement (h) so it runs without a JSX setup; the same props work in .tsx files.
import { createElement as h, useMemo, useRef, useState, StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { NoxGridReact } from '@novnox/grid-react';
import type { NoxGrid } from '@novnox/grid';

// Free license key from https://novnox.dev/license/ (removes the license notice):
// import { setLicenseKey } from '@novnox/grid';
// setLicenseKey('NOX1....');

const classes = ['Class A', 'Class B', 'Class C'];

type Row = { name: string; dept: string; score: number; pass: boolean };
const make = (n: number): Row[] =>
  Array.from({ length: n }, (_, i) => {
    const score = 50 + ((i * 37) % 51);
    return { name: `Student ${i + 1}`, dept: classes[i % 3], score, pass: score >= 60 };
  });

function App() {
  const [rows, setRows] = useState(() => make(30));
  const [scheme, setScheme] = useState<'modern' | 'dark'>('modern');
  const [last, setLast] = useState('');
  const grid = useRef<NoxGrid | null>(null);
  const on = useMemo(() => ({
    cellValueChanged: (e: { row: number; col: number; newValue: unknown }) =>
      setLast(`row ${e.row + 1}, col ${e.col + 1} → ${String(e.newValue)}`),
  }), []);
  return h('div', { style: { padding: 16, fontFamily: 'Segoe UI, system-ui, sans-serif' } },
    h('h1', { style: { fontSize: 18, margin: '0 0 8px' } }, 'NoxGrid · React'),
    h('div', { style: { display: 'flex', gap: 6, marginBottom: 8 } },
      h('button', { onClick: () => setRows(make(rows.length + 10)) }, '+10 students'),
      h('button', { onClick: () => setScheme(scheme === 'modern' ? 'dark' : 'modern') }, 'Toggle theme'),
      h('button', { onClick: () => grid.current?.sort([{ col: 'score', order: 'desc' }]) }, 'Sort by score'),
      h('span', { style: { marginLeft: 8, color: '#64748b' } }, last),
      h('span', { style: { marginLeft: 8, color: '#64748b' } }, `${rows.length} students`),
    ),
    h(NoxGridReact, {
      ref: grid,
      style: { height: 420, border: '1px solid #e2e8f0', borderRadius: 8, overflow: 'hidden' },
      colorScheme: scheme,
      data: rows,
      allowFilter: true,
      columns: [
        { field: 'name', header: 'Name', width: 110 },
        { field: 'dept', header: 'Class', kind: 'combo', items: classes, mergeMode: 'always' },
        { field: 'score', header: 'Score', kind: 'number', minimum: 0, maximum: 100 },
        { field: 'pass', header: 'Pass', kind: 'check' },
      ],
      on,
    }),
  );
}

createRoot(document.getElementById('app')!).render(h(StrictMode, null, h(App)));

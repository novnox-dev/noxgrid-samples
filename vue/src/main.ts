// NoxGrid Vue 3 sample: reactive data and grid events.
// Uses render functions (h) so it runs without a .vue compiler; the same props work in templates.
import { createApp, defineComponent, h, ref } from 'vue';
import { NoxGridVue } from '@novnox/grid-vue';
import type { NoxGrid } from '@novnox/grid';

// Free license key from https://novnox.dev/license/ (removes the license notice):
// import { setLicenseKey } from '@novnox/grid';
// setLicenseKey('NOX1....');

type Row = { item: string; qty: number; price: number };
const make = (n: number): Row[] =>
  Array.from({ length: n }, (_, i) => ({ item: `Item ${i + 1}`, qty: 1 + (i % 7), price: 10 * (1 + (i % 5)) }));

const App = defineComponent({
  setup() {
    const rows = ref(make(20));
    const last = ref('');
    const scheme = ref<'teal' | 'midnight'>('teal');
    let grid: NoxGrid | undefined;
    return () =>
      h('div', { style: { padding: '16px', fontFamily: 'Segoe UI, system-ui, sans-serif' } }, [
        h('h1', { style: { fontSize: '18px', margin: '0 0 8px' } }, 'NoxGrid · Vue 3'),
        h('div', { style: { display: 'flex', gap: '6px', marginBottom: '8px' } }, [
          h('button', { onClick: () => (rows.value = make(rows.value.length + 5)) }, '+5 items'),
          h('button', { onClick: () => (scheme.value = scheme.value === 'teal' ? 'midnight' : 'teal') }, 'Toggle theme'),
          h('button', { onClick: () => grid?.setFormula(0, 'price', '=SUM(B1:B5)') }, 'Insert formula'),
          h('span', { style: { marginLeft: '8px', color: '#64748b' } }, last.value),
          h('span', { style: { marginLeft: '8px', color: '#64748b' } }, `${rows.value.length} items`),
        ]),
        h(NoxGridVue, {
          options: {
            columns: [
              { field: 'item', header: 'Item', width: 120 },
              { field: 'qty', header: 'Qty', kind: 'number' },
              { field: 'price', header: 'Price', kind: 'number', format: '"$"#,##0' },
            ],
          },
          data: rows.value,
          colorScheme: scheme.value,
          height: 420,
          onReady: (g: NoxGrid) => { grid = g; },
          onCellValueChanged: (e: { row: number; col: number; newValue: unknown }) =>
            (last.value = `row ${e.row + 1}, col ${e.col + 1} → ${String(e.newValue)}`),
        }),
      ]);
  },
});

createApp(App).mount('#app');

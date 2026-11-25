# NoxGrid Next.js sample

Next.js (App Router, TypeScript) with `@novnox/grid` and `@novnox/grid-react` from npm: 1,000 orders in a grid on a Server Component page, the last edit shown in React state, a button to unmount and mount the grid again, and a second route to check client-side navigation.

```
npm install
npm run dev
```

Then open http://localhost:3000. `npm run build` and `npm start` run the production build.

The grid is in `components/OrdersGrid.tsx`; `app/page.tsx` renders it.

## Notes

- **`"use client"`**: the grid runs in the browser, so use `NoxGridReact` in a file that starts with `"use client"` (here `components/OrdersGrid.tsx`). With `@novnox/grid-react` 1.0.1 or later you can import it from a Server Component too; with 1.0.0 put it in a `"use client"` file, for example a one-line re-export:
  ```tsx
  "use client";
  export { NoxGridReact } from "@novnox/grid-react";
  ```
- **No `ssr: false` needed**: on the server only the empty container is rendered and the grid is created after hydration, so there is no `window is not defined` and no hydration warning. `next/dynamic` is not required.
- **Functions cannot cross the server/client boundary**: from a Server Component you can pass `columns`, `data`, `colorScheme` and `style`, but not `on`, `onReady` or `ref`. Handle events in a client component.
- **Stable `on`**: create the handlers object with `useMemo` (or outside the component); a new object on every render makes the grid re-subscribe.
- **Height**: give the container a height through `style` (400px by default), or use `autoHeight`.
- React StrictMode (on by default in development) creates, destroys and creates the grid again; this is expected and leaves one grid.

## License key

The grid shows a license notice unless a key is set (not needed on localhost). Free keys: https://novnox.dev/license/. Call `setLicenseKey('NOX1....')` from `@novnox/grid` once before the grid is created; see the comment at the top of `components/OrdersGrid.tsx`.

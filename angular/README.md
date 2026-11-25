# NoxGrid Angular sample

A standalone Angular 22 component (`src/app/orders-grid.ts`) that creates a NoxGrid on a host element, binds 1,000 orders, shows edits on the page through signals, and destroys the grid in `ngOnDestroy`. The **Hide grid / Show grid** button removes and recreates the component.

```
npm install
npm start
```

Then open http://localhost:4200. `npm run build` makes a production build in `dist`.

Angular 22 needs Node.js `^22.22.3`, `^24.15.0` or `>=26.0.0` (older Node versions stop with an error before building). With an older Node, use Angular 21 (Node `^20.19.0`, `^22.12.0` or `>=24.0.0`); the component code is the same.

Uses `@novnox/grid` from npm. No license key is needed on localhost; for a real site, call `setLicenseKey('NOX1....')` once at startup with a free key from https://novnox.dev/license/ (see `src/main.ts`).

## Gotchas

- **SSR / prerendering.** `ng new` does not turn on SSR by default. If you add it, create the grid only in the browser: keep the `isPlatformBrowser` check in `ngAfterViewInit`, or create the grid in `afterNextRender()`. Without it, prerendering logs `ReferenceError: document is not defined`.
- **Change detection.** Angular 22 components are OnPush by default, so a plain property changed in a grid event (`cellValueChanged` and so on) does not show on the page. Use signals as this sample does, or call `ChangeDetectorRef.markForCheck()`. `NgZone.run` is not needed.
- **Bundle budget.** The default production budget warns when the initial bundle is over 500 kB. This sample is about 305 kB (86 kB compressed), of which the grid is about 200 kB. An app with the router and zone.js grows toward the limit; raise `maximumWarning` in `angular.json` if needed.
- **Height.** The grid fills its host element, so give the host a height (here `.grid-host { height: 420px }`).
- **Cleanup.** Call `grid.destroy()` (and the function `grid.on()` returns, to unsubscribe) in `ngOnDestroy`, as in the sample.

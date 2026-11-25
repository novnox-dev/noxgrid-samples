// Copyright © 2026 Nox. All rights reserved.
// NoxGrid Angular sample: the root component shows or hides the orders grid,
// so the grid is created and destroyed together with its component.
import { Component, signal } from '@angular/core';
import { OrdersGrid } from './orders-grid';

@Component({
  selector: 'app-root',
  imports: [OrdersGrid],
  template: `
    <div style="padding: 16px">
      <h1 style="font-size: 18px; margin: 0 0 8px">NoxGrid · Angular</h1>
      <button id="toggle" (click)="show.set(!show())">{{ show() ? 'Hide grid' : 'Show grid' }}</button>
      @if (show()) {
        <app-orders-grid />
      }
    </div>
  `,
})
export class App {
  readonly show = signal(true);
}

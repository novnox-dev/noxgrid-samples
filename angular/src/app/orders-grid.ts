// Copyright © 2026 Nox. All rights reserved.
// Orders grid: creates a NoxGrid on a host element, binds 1,000 orders,
// shows edits on the page through signals and destroys the grid with the component.
import {
  AfterViewInit, Component, ElementRef, OnDestroy, PLATFORM_ID, ViewChild, inject, signal,
} from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { NoxGrid } from '@novnox/grid';

const customers = ['Acme Corp', 'Blue Harbor', 'Cedar & Co', 'Delta Foods', 'Evergreen Ltd'];
const products = ['Keyboard', 'Monitor', 'Mouse', 'Laptop', 'Headset', 'Webcam'];
const statuses = ['New', 'Shipped', 'Delivered', 'Cancelled'];

interface Order {
  no: string;
  customer: string;
  product: string;
  ordered: Date;
  qty: number;
  price: number;
  status: string;
  paid: boolean;
}

function makeOrders(n: number): Order[] {
  return Array.from({ length: n }, (_, i) => ({
    no: `SO-${10001 + i}`,
    customer: customers[i % customers.length],
    product: products[(i * 7) % products.length],
    ordered: new Date(2026, (i * 5) % 12, 1 + ((i * 3) % 28)),
    qty: 1 + ((i * 13) % 20),
    price: 20 + ((i * 37) % 480),
    status: statuses[i % statuses.length],
    paid: i % 3 !== 0,
  }));
}

@Component({
  selector: 'app-orders-grid',
  templateUrl: './orders-grid.html',
  styles: [`
    .status { margin: 8px 0; color: #64748b; }
    .grid-host { height: 420px; border: 1px solid #e2e8f0; border-radius: 8px; overflow: hidden; }
  `],
})
export class OrdersGrid implements AfterViewInit, OnDestroy {
  @ViewChild('host', { static: true }) private host!: ElementRef<HTMLDivElement>;
  private readonly platformId = inject(PLATFORM_ID);
  private grid?: NoxGrid;
  private off?: () => void;

  // Signals, because Angular 22 components are OnPush by default: a plain property changed
  // in a grid event would not show on the page (call markForCheck() if you prefer properties).
  readonly rowCount = signal(0);
  readonly editCount = signal(0);
  readonly lastEdit = signal('');

  ngAfterViewInit(): void {
    // Needed only if you add SSR / prerendering: the grid draws on a canvas, so create it in the browser only.
    if (!isPlatformBrowser(this.platformId)) return;

    this.grid = new NoxGrid(this.host.nativeElement, {
      colorScheme: 'modern',
      allowFilter: true,
      columns: [
        { field: 'no', header: 'Order', width: 90 },
        { field: 'customer', header: 'Customer', width: 130 },
        { field: 'product', header: 'Product', width: 110 },
        { field: 'ordered', header: 'Ordered', kind: 'date', width: 110 },
        { field: 'qty', header: 'Qty', kind: 'number', width: 70 },
        { field: 'price', header: 'Price', kind: 'number', width: 90 },
        { field: 'status', header: 'Status', kind: 'combo', items: statuses, width: 100 },
        { field: 'paid', header: 'Paid', kind: 'check', width: 60 },
      ],
    });
    // setData is typed Record<string, unknown>[] in 1.0, which an interface type does not match,
    // hence the cast. From 1.1 the typing is relaxed and the cast is not needed.
    this.grid.setData(makeOrders(1000) as unknown as Record<string, unknown>[]);
    this.rowCount.set(this.grid.rowCount);

    this.off = this.grid.on('cellValueChanged', (e) => {
      this.editCount.update((n) => n + 1);
      this.lastEdit.set(`row ${e.row + 1}, col ${e.col + 1}: ${String(e.oldValue)} → ${String(e.newValue)}`);
    });
  }

  ngOnDestroy(): void {
    this.off?.(); // unsubscribe the event handler
    this.grid?.destroy(); // removes the canvas and the grid's listeners
    this.grid = undefined;
  }
}

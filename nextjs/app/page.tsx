// Copyright © 2026 Nox. All rights reserved.
// Server Component page. It renders the client component directly; no next/dynamic or ssr: false needed.
import OrdersGrid from "@/components/OrdersGrid";

export default function Home() {
  return (
    <>
      <h1>NoxGrid · Next.js</h1>
      <OrdersGrid />
    </>
  );
}

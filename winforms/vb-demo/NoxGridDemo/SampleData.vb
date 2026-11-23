' Copyright © 2026 Nox. All rights reserved.

''' <summary>Made-up sample data (not real companies or transactions). A fixed seed gives the same data on every run.</summary>
Public NotInheritable Class SampleData

    Private Sub New()
    End Sub

    Public Shared ReadOnly Customers As String() = {"Customer A", "Customer B", "Customer C", "Customer D", "Customer E", "Customer F", "Customer G", "Customer H"}
    Public Shared ReadOnly Statuses As String() = {"Received", "In production", "Shipping", "Completed", "On hold"}
    Public Shared ReadOnly SalesReps As String() = {"Alex Morgan", "Sam Lee", "Jordan Park", "Taylor Reed"}
    Public Shared ReadOnly Carriers As String() = {"FastShip Express", "Metro Freight", "Coastal Logistics", "Own delivery"}

    ''' <summary>Items: code, name, unit price</summary>
    Public Shared ReadOnly Items As (Code As String, Name As String, Price As Decimal)() = {
        ("BK-200", "Steel Bracket A", 4.5D),
        ("BR-6204", "Bearing 6204", 8.2D),
        ("HS-110", "Hydraulic Hose", 21D),
        ("CP-300", "Control Panel", 480D),
        ("LD-050", "LED Module", 13.5D),
        ("GM-040", "Gear Motor 0.4kW", 295D),
        ("SK-010", "Sensor Kit", 110D),
        ("PB-L", "Shipping Box L", 1.2D)
    }

    ''' <summary>The sample's "today" (fixed so the data never changes)</summary>
    Public Shared ReadOnly Today As Date = New Date(2026, 11, 21)

    ''' <summary>One sales order</summary>
    Public Class Order
        Public Property OrderNo As String
        Public Property Customer As String
        Public Property ItemName As String
        Public Property Quantity As Integer
        Public Property Price As Decimal
        Public Property Ordered As Date
        Public Property Due As Date
        Public Property Urgent As Boolean
        Public Property Status As String
        Public Property SalesRep As String
    End Class

    Public Shared Function CreateOrders(count As Integer) As List(Of Order)
        Dim rnd As New Random(20261121)
        Dim list As New List(Of Order)(count)
        For i = 0 To count - 1
            Dim item = Items(rnd.Next(Items.Length))
            Dim qty = If(item.Price >= 100D, rnd.Next(1, 6), rnd.Next(1, 41) * 10)
            Dim ordered = New Date(2026, 1, 1).AddDays(rnd.Next(0, 320))
            Dim due = ordered.AddDays(rnd.Next(7, 28))
            Dim status As String
            If rnd.Next(17) = 0 Then
                status = "On hold"
            ElseIf due < Today Then
                status = If(rnd.Next(8) = 0, "Shipping", "Completed")
            Else
                status = Statuses(rnd.Next(3))
            End If
            list.Add(New Order With {
                .OrderNo = "SO-" & (260001 + i).ToString(),
                .Customer = Customers(rnd.Next(Customers.Length)),
                .ItemName = item.Name,
                .Quantity = qty,
                .Price = item.Price,
                .Ordered = ordered,
                .Due = due,
                .Urgent = rnd.Next(10) = 0,
                .Status = status,
                .SalesRep = SalesReps(rnd.Next(SalesReps.Length))
            })
        Next
        list.Sort(Function(a, b) a.Ordered.CompareTo(b.Ordered))
        For i = 0 To list.Count - 1
            list(i).OrderNo = "SO-" & (260001 + i).ToString()
        Next
        Return list
    End Function

    ''' <summary>Shipments (DataTable): each order ships in 1 to 3 parts</summary>
    Public Shared Function CreateShipments(orders As List(Of Order)) As DataTable
        Dim t As New DataTable("Shipments")
        t.Columns.Add("OrderNo", GetType(String))
        t.Columns.Add("Customer", GetType(String))
        t.Columns.Add("Shipped", GetType(Date))
        t.Columns.Add("ItemName", GetType(String))
        t.Columns.Add("OrderQty", GetType(Integer))
        t.Columns.Add("ShipQty", GetType(Integer))
        t.Columns.Add("Remaining", GetType(Integer))
        t.Columns.Add("Carrier", GetType(String))
        t.Columns.Add("Invoice", GetType(String))
        t.Columns.Add("State", GetType(String))
        Dim rnd As New Random(7)
        For Each o In orders
            If o.Status = "Received" OrElse o.Status = "In production" OrElse o.Status = "On hold" Then Continue For
            Dim parts = If(o.Quantity >= 30, rnd.Next(1, 4), 1)
            Dim left = o.Quantity
            For p = 1 To parts
                Dim q = If(p = parts, left, Math.Max(1, o.Quantity \ parts))
                If o.Status = "Shipping" AndAlso p = parts Then q = Math.Max(0, q \ 2)
                left -= q
                Dim state = If(o.Status = "Shipping" AndAlso p = parts, "In transit", If(rnd.Next(40) = 0, "Returned", "Delivered"))
                t.Rows.Add(o.OrderNo, o.Customer, o.Ordered.AddDays(3 + p * 2), o.ItemName, o.Quantity, q, left,
                           Carriers(rnd.Next(Carriers.Length)), (600000000000L + rnd.Next(100000000)).ToString(), state)
            Next
        Next
        Return t
    End Function

End Class

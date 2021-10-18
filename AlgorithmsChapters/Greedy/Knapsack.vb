Imports System
Imports System.Collections.Generic

Public Class Knapsack
	Private Class Items
		Friend wt As Integer
		Friend cost As Integer
		Friend density As Double

		Friend Sub New(ByVal w As Integer, ByVal v As Integer)
			wt = w
			cost = v
			density = CDbl(cost) / wt
		End Sub
	End Class

	Private Class DecDensity
		Implements IComparer(Of Items)

		Public Function Compare(ByVal a As Items, ByVal b As Items) As Integer
			Return CInt(Math.Truncate(b.density - a.density))
		End Function
	End Class

	' Approximate solution.
	Public Function GetMaxCostGreedy(ByVal wt() As Integer, ByVal cost() As Integer, ByVal capacity As Integer) As Integer
		Dim totalCost As Integer = 0
		Dim n As Integer = wt.Length
		Dim itemList(n - 1) As Items
		For i As Integer = 0 To n - 1
			itemList(i) = New Items(wt(i), cost(i))
		Next i

		Array.Sort(itemList, New DecDensity())
		Dim i As Integer = 0
		Do While i < n AndAlso capacity > 0
			If capacity - itemList(i).wt >= 0 Then
				capacity -= itemList(i).wt
				totalCost += itemList(i).cost
			End If
			i += 1
		Loop
		Return totalCost
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim wt() As Integer = {10, 40, 20, 30}
		Dim cost() As Integer = {60, 40, 90, 120}
		Dim capacity As Integer = 50

		Dim kp As New Knapsack()
		Dim maxCost As Integer = kp.GetMaxCostGreedy(wt, cost, capacity)
		Console.WriteLine("Maximum cost obtained = " & maxCost)
	End Sub
End Class

'
'Maximum cost obtained = 150
'

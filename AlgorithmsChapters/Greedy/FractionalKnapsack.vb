﻿Imports System

Public Module FractionalKnapsack
	Private Class Items
		Implements IComparable(Of Items)

		Friend wt As Integer
		Friend cost As Integer
		Friend density As Double

		Friend Sub New(ByVal w As Integer, ByVal v As Integer)
			wt = w
			cost = v
			density = CDbl(cost) / wt
		End Sub

		Private Function IComparable_CompareTo(other As Items) As Integer Implements IComparable(Of Items).CompareTo
			Return CInt(Math.Truncate(other.density - Me.density))
		End Function
	End Class

	Public Function GetMaxCostFractional(ByVal wt() As Integer, ByVal cost() As Integer, ByVal capacity As Integer) As Double
		Dim totalCost As Double = 0
		Dim n As Integer = wt.Length
		Dim itemList(n - 1) As Items
		For i As Integer = 0 To n - 1
			itemList(i) = New Items(wt(i), cost(i))
		Next i

		Array.Sort(itemList)
		For i As Integer = 0 To n - 1
			If capacity - itemList(i).wt >= 0 Then
				capacity -= itemList(i).wt
				totalCost += itemList(i).cost
			Else
				totalCost += (itemList(i).density * capacity)
				Exit For
			End If
		Next i
		Return totalCost
	End Function

	' Testing code.
	Sub Main(ByVal args() As String)
		Dim wt() As Integer = {10, 40, 20, 30}
		Dim cost() As Integer = {60, 40, 90, 120}
		Dim capacity As Integer = 50

		Dim maxCost As Double = GetMaxCostFractional(wt, cost, capacity)
		Console.WriteLine("Maximum cost obtained = " & maxCost)
	End Sub
End Module

'
'Maximum cost obtained = 230
'
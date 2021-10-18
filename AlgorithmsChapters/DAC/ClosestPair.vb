Imports System
Imports System.Collections.Generic

Public Class ClosestPair
	Public Class Point
		Public x, y As Integer
		Public Sub New(ByVal a As Integer, ByVal b As Integer)
			x = a
			y = b
		End Sub
	End Class

	Public Function ClosestPairBF(ByVal arr(,) As Integer) As Double
		Dim n As Integer = arr.GetLength(0)
		Dim dmin As Double = Double.MaxValue, d As Double
		Dim i As Integer = 0
		Do While i < n - 1
			For j As Integer = i + 1 To n - 1
				d = Math.Sqrt((arr(i, 0) - arr(j, 0)) * (arr(i, 0) - arr(j, 0)) + (arr(i, 1) - arr(j, 1)) * (arr(i, 1) - arr(j, 1)))
				If d < dmin Then
					dmin = d
				End If
			Next j
			i += 1
		Loop
		Return dmin
	End Function

	Private Shared Function Distance(ByVal a As Point, ByVal b As Point) As Double
		Return Math.Sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y))
	End Function


	Class xComp
		Implements IComparer(Of Point)

		Public Function Compare(ByVal s1 As Point, ByVal s2 As Point) As Integer
			Return (s1.x - s2.x)
		End Function
	End Class

	Class yComp
		Implements IComparer(Of Point)

		Public Function Compare(ByVal s1 As Point, ByVal s2 As Point) As Integer
			Return (s1.y - s2.y)
		End Function
	End Class

	Private Shared Function StripMin(ByVal q() As Point, ByVal n As Integer, ByVal d As Double) As Double
		Dim min As Double = d

		' Find the Distance between all the points in the strip. 
		' Array q is sorted according to the y axis coordinate.
		' The inner loop will run at most 6 times for each point.
		For i As Integer = 0 To n - 1
			Dim j As Integer = i + 1
			Do While j < n AndAlso (q(j).y - q(i).y) < min
				d = Distance(q(i),q(j))
				If d < min Then
					min = d
				End If
				j += 1
			Loop
		Next i
		Return min
	End Function

	Private Function ClosestPairUtil(ByVal p() As Point, ByVal startVal As Integer, ByVal stopVal As Integer, ByVal q() As Point, ByVal n As Integer) As Double
		If stopVal - startVal < 1 Then
			Return Double.MaxValue
		End If

		If stopVal - startVal = 1 Then
			Return Distance(p(startVal), p(stopVal))
		End If

		' Find the middle point
		Dim mid As Integer = (startVal + stopVal) \ 2

		Dim dl As Double = ClosestPairUtil(p, startVal, mid, q, n)
		Dim dr As Double = ClosestPairUtil(p, mid + 1, stopVal, q, n)
		Dim d As Double = Math.Min(dl, dr)

		' Build an array strip[] that contains points whose x axis coordinate
		' in the range p[mid]-d and p[mid]+d.
		' Points are already sorted according to y axis.
		Dim strip(n - 1) As Point
		Dim j As Integer = 0
		For i As Integer = 0 To n - 1
			If Math.Abs(q(i).x - p(mid).x) < d Then
				strip(j) = q(i)
				j += 1
			End If
		Next i
		' Find the closest points in strip and compare with d.
		Return Math.Min(d, StripMin(strip, j, d))
	End Function


	Public Function ClosestPairDC(ByVal arr(,) As Integer) As Double
		Dim n As Integer =arr.GetLength(0)
		Dim p(n - 1) As Point
		For i As Integer = 0 To n - 1
			p(i) = New Point(arr(i, 0), arr(i, 1))
		Next i
		' Sort according to x axis.
		Array.Sort(p, New xComp())

		Dim q() As Point = DirectCast(p.Clone(), ClosestPair.Point())
		' Sort according to y axis.
		Array.Sort(q, New yComp())
		Return ClosestPairUtil(p, 0, n - 1, q, n)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim arr(,) As Integer = {
			{648, 896},
			{269, 879},
			{250, 922},
			{453, 347},
			{213, 17}
		}
		Dim cp As New ClosestPair()
		Console.WriteLine("Smallest Distance is:" & cp.ClosestPairBF(arr))
		Console.WriteLine("Smallest Distance is:" & cp.ClosestPairDC(arr))
	End Sub
End Class

'
'Smallest Distance is:47.0106370941726
'Smallest Distance is:47.0106370941726
'

Imports System

Public Class OptimalMergePattern
	Public Shared Function Merge(ByVal lists() As Integer, ByVal size As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)()
		Dim i As Integer = 0
		For i = 0 To size - 1
			pq.add(lists(i))
		Next i

		Dim total As Integer = 0
		Dim value As Integer = 0
		Do While pq.size() > 1
			value = pq.remove()
			value += pq.remove()
			pq.add(value)
			total += value
		Loop
		Console.WriteLine("Total : " & total)
		Return total
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim lists() As Integer = {4, 3, 2, 6}
		OptimalMergePattern.Merge(lists, lists.Length)
	End Sub
End Class


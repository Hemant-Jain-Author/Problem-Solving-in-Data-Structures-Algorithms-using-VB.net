Imports System

Public Class PriorityQueueDemo
	Public Shared Sub Main(ByVal args() As String)

		Dim pq As New PriorityQueue(Of Integer)()
		Dim arr() As Integer = {1, 2, 10, 8, 7, 3, 4, 6, 5, 9}
		For Each i As Integer In arr
			pq.add_Conflict(i)
		Next i

		Console.Write("Heap Array: ")
		pq.print_Conflict()
		Do While pq.isEmpty_Conflict() = False
			Console.Write(pq.remove_Conflict() & " ")
		Loop
		Console.WriteLine()

		pq = New PriorityQueue(Of Integer)(False)
		For Each i As Integer In arr
			pq.add_Conflict(i)
		Next i

		Console.Write("Heap Array: ")
		pq.print_Conflict()
		Do While pq.isEmpty_Conflict() = False
			Console.Write(pq.remove_Conflict() & " ")
		Loop
	End Sub
End Class


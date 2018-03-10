Imports System
Imports System.Collections
Imports System.Collections.Generic

Public Class PriorityQueueDemo
	Public Shared Sub Main77(ByVal args() As String)
		Dim arr() As Integer = {1, 2, 10, 8, 7, 3, 4, 6, 5, 9}
		Dim pq As New PriorityQueue(Of Integer)(arr, False)
		For Each i As Integer In arr
			pq.Enqueue(i)
		Next i

		Console.WriteLine("Priority Queue ::")
		For Each o As Integer In pq
			Console.WriteLine(o)
		Next o

		Dim size As Integer = pq.Count
		Console.WriteLine("Dequeue elements of priority queue ::")
		Do While pq.isEmpty() = False
			Console.WriteLine(pq.Dequeue())
		Loop
	End Sub
End Class

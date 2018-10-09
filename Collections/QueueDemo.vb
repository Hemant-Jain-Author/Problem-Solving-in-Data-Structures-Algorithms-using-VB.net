Imports System
Imports System.Collections.Generic

Friend Class QueueDemo
	Public Shared Sub Main(ByVal args() As String)
		Dim que As New Queue(Of Integer)()
		que.Enqueue(1)
		que.Enqueue(2)
		que.Enqueue(3)
		que.Enqueue(4)

		Dim size As Integer = que.Count
		For i As Integer = 0 To size - 1
			Console.WriteLine("Dequeue from queue: " & que.Dequeue())
		Next i
	End Sub
End Class
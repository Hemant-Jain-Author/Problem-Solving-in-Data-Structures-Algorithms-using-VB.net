Imports System
Imports System.Collections.Generic

Friend Class QueueDemo
	Public Shared Sub Main(ByVal args() As String)
		Dim que As New Queue(Of Integer)()
		que.Enqueue(1)
		que.Enqueue(2)
		que.Enqueue(3)

		Console.Write("Queue : ")
		Dim ele As Integer
		For Each ele In que
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()

		Console.WriteLine("Queue size : " & que.Count)
		Console.WriteLine("Queue peek : " & que.Peek())
		Console.WriteLine("Queue remove : " & que.Dequeue())
		Console.WriteLine("Queue isEmpty : " & (que.Count = 0))
	End Sub
End Class


' 
'Queue : 1 2 3 
'Queue size : 3
'Queue peek : 1
'Queue remove : 1
'Queue isEmpty : False
'
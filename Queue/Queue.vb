Imports System

Public Class Queue
	Private count As Integer
	Private capacity As Integer = 100
	Private data() As Integer
	Friend front As Integer = 0
	Friend back As Integer = 0

	Public Sub New(ByVal n As Integer)
		count = 0
		capacity = n
		data = New Integer(n - 1){}
	End Sub

	Public Function add(ByVal value As Integer) As Boolean
		If count >= capacity Then
			Console.WriteLine("Queue is full.")
			Return False
		Else
			count += 1
			data(back) = value
			back = (++back) Mod capacity
		End If
		Return True
	End Function

	Public Function remove() As Integer
		Dim value As Integer
		If count <= 0 Then
			Console.WriteLine("Queue is empty.")
			Return -999
		Else
			count -= 1
			value = data(front)
			front = (++front) Mod capacity
		End If
		Return value
	End Function

	Friend Function isEmpty() As Boolean
		Return count = 0
	End Function

	Friend Function Size() As Integer
		Return count
	End Function

	Friend Sub print()
		If count = 0 Then
			Console.Write("Queue is empty.")
			Return
		End If
		Dim temp As Integer = front
		Dim s As Integer = count
		Console.Write("Queue is : ")
		Do While s > 0
			s -= 1
			Console.Write(data(temp) & " ")
			temp = (++temp) Mod capacity
		Loop
		Console.WriteLine()
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim que As New Queue(5)
		For i As Integer = 0 To 4
			que.add(i)
		Next i
		que.print()

		For i As Integer = 0 To 4
			Console.Write(que.remove() & " ")
		Next i
	End Sub
End Class

'
'Queue is : 0 1 2 3 4 
'0 1 2 3 4 
'
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
		data = New Integer(n - 1) {}
	End Sub

	Public Function Add(ByVal value As Integer) As Boolean
		If count >= capacity Then
			Console.WriteLine("Queue is full.")
			Return False
		Else
			count += 1
			data(back) = value
			back += 1
			back = back Mod capacity
		End If
		Return True
	End Function

	Public Function Remove() As Integer
		Dim value As Integer
		If count <= 0 Then
			Console.WriteLine("Queue is empty.")
			Return -999
		Else
			count -= 1
			value = data(front)
			front += 1
			front = front Mod capacity
		End If
		Return value
	End Function

	Friend Function IsEmpty() As Boolean
		Return count = 0
	End Function

	Friend Function Size() As Integer
		Return count
	End Function

	Friend Sub Print()
		If count = 0 Then
			Console.Write("Queue is empty.")
			Return
		End If
		Dim temp As Integer = front
		Dim s As Integer = count
		Console.Write("Queue is : ")
		While s > 0
			s -= 1
			Console.Write(data(temp) & " ")
			temp += 1
			temp = temp Mod capacity
		End While
		Console.WriteLine()
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim que As New Queue(5)
		For i As Integer = 0 To 4
			que.Add(i)
		Next i
		que.Print()

		For i As Integer = 0 To 4
			Console.Write(que.Remove() & " ")
		Next i
	End Sub
End Class

'
'Queue is : 0 1 2 3 4 
'0 1 2 3 4 
'
Imports System
Imports System.Collections

Public Class Queue
	Private count As Integer
	Private Capacity As Integer = 100
	Private data() As Integer
	Friend front As Integer = 0
	Friend back As Integer = 0

	Public Sub New()
		count = 0
		data = New Integer(99) {}
	End Sub



	Public Overridable Sub add(ByVal value As Integer)
		If count >= Capacity Then
			Throw New System.InvalidOperationException("QueueFullException")
		Else
			count += 1
			data(back) = value
			back = (++back) Mod (Capacity - 1)
		End If
	End Sub

	Public Overridable Function remove() As Integer
		Dim value As Integer
		If count <= 0 Then
			Throw New System.InvalidOperationException("QueueEmptyException")
		Else
			count -= 1
			value = data(front)
			front = (++front) Mod (Capacity - 1)
		End If
		Return value
	End Function

	Friend Overridable ReadOnly Property Empty() As Boolean
		Get
			Return count = 0
		End Get
	End Property

	Friend Overridable Function size() As Integer
		Return count
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim que As New Queue()

		For i As Integer = 0 To 19
			que.add(i)
		Next i
		For i As Integer = 0 To 21
			Console.WriteLine(que.remove())
		Next i
	End Sub
End Class
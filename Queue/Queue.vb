Imports System
Imports System.Collections

Public Class Queue
	Private count As Integer
	Private capacity As Integer = 100
	Private data() As Integer
	Friend front As Integer = 0
	Friend back As Integer = 0

	Public Sub New()
		count = 0
		data = New Integer(99){}
	End Sub

	Public Overridable Function add(ByVal value As Integer) As Boolean
		If count >= capacity Then
			Console.WriteLine("Queue is full.")
			Return False
		Else
			count += 1
			data(back) = value
			back = (++back) Mod (capacity - 1)
		End If
		Return True
	End Function

	Public Overridable Function remove() As Integer
		Dim value As Integer
		If count <= 0 Then
			Console.WriteLine("Queue is empty.")
			Return -999
		Else
			count -= 1
			value = data(front)
			front = (++front) Mod (capacity - 1)
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
		Dim q As New Queue()
		q.add(1)
		q.add(2)
		q.add(3)
		For i As Integer = 0 To 2
			Console.WriteLine(q.remove())
		Next i
	End Sub
End Class

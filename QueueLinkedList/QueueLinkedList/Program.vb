Imports System
Imports System.Collections

Public Class Queue
	Private Class Node
		Friend value As Integer
		Friend nextNode As Node

		Public Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			nextNode = n
		End Sub
	End Class

	Private head As Node = Nothing
	Private tail As Node = Nothing
	Private count As Integer = 0
	' Other Methods


	Public Overridable Function size() As Integer
		Return count
	End Function

	Public Overridable ReadOnly Property Empty() As Boolean
		Get
			Return count = 0
		End Get
	End Property


	Public Overridable Function peek() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("QueueEmptyException")
		End If
		Return head.value
	End Function

	Public Overridable Sub add(ByVal value As Integer)
		Dim temp As New Node(value, Nothing)

		If head Is Nothing Then
			tail = temp
			head = tail
		Else
			tail.nextNode = temp
			tail = temp
		End If
		count += 1
	End Sub


	Public Overridable Function remove() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("QueueEmptyException")
		End If
		Dim value As Integer = head.value
		head = head.nextNode
		count -= 1
		Return value
	End Function

	Public Overridable Sub print()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			Console.Write(temp.value & " ")
			temp = temp.nextNode
		Loop
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim q As New Queue()
		For i As Integer = 1 To 100
			q.add(i)
		Next i
		For i As Integer = 1 To 50
			q.remove()
		Next i
		q.print()
	End Sub
End Class
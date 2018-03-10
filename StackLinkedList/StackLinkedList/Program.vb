Imports System
Imports System.Collections

Public Class ListStack
	Private Class Node
		Friend data As Integer
		Friend nextNode As Node
	End Class

	Private head As Node = Nothing
	Private count As Integer = 0

	Public Function size() As Integer
		Return count
	End Function

	Public ReadOnly Property Empty() As Boolean
		Get
			Return count = 0
		End Get
	End Property

	Public Function peek() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("ListStackEmptyException")
		End If
		Return head.data
	End Function

	Public Sub Push(ByVal value As Integer)
		head = New Node(value, head)
		count += 1
	End Sub


	Public Function Pop() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("ListStackEmptyException")
		End If
		Dim value As Integer = head.data
		head = head.nextNode
		count -= 1
		Return value
	End Function

	Public Sub insertAtBottom(ByVal value As Integer)
		If Empty Then
			Push(value)
		Else
			Dim temp As Integer = Pop()
			insertAtBottom(value)
			Push(temp)
		End If
	End Sub


	Public Sub print()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			Console.Write(temp.data & " ")
			temp = temp.nextNode
		Loop
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim s As New ListStack()
		For i As Integer = 1 To 100
			s.Push(i)
		Next i
		For i As Integer = 1 To 50
			s.Pop()
		Next i
		s.print()
	End Sub
End Class
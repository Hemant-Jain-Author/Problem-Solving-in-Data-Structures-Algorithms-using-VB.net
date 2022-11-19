Imports System

Public Class StackLL
	Private head As Node = Nothing
	Private length As Integer = 0

	Private Class Node
		Friend value As Integer
		Friend nextPtr As Node

		Friend Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			nextPtr = n
		End Sub
	End Class

	Public Function Size() As Integer
		Return length
	End Function

	Public Function IsEmpty() As Boolean
		Return length = 0
	End Function

	Public Function Peek() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException("StackEmptyException")
		End If
		Return head.value
	End Function

	Public Sub Push(ByVal value As Integer)
		head = New Node(value, head)
		length += 1
	End Sub

	Public Function Pop() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException("StackEmptyException")
		End If
		Dim value As Integer = head.value
		head = head.nextPtr
		length -= 1
		Return value
	End Function

	Public Sub InsertAtBottom(ByVal value As Integer)
		If IsEmpty() Then
			Push(value)
		Else
			Dim temp As Integer = Pop()
			InsertAtBottom(value)
			Push(temp)
		End If
	End Sub

	Public Sub Print()
		Dim temp As Node = head
		While temp IsNot Nothing
			Console.Write(temp.value & " ")
			temp = temp.nextPtr
		End While
		Console.WriteLine()
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim s As New StackLL()
		s.Push(1)
		s.Push(2)
		s.Push(3)
		s.Print()
		Console.WriteLine(s.Pop())
		Console.WriteLine(s.Pop())
	End Sub
End Class
'
'3 2 1 
'3
'2
'

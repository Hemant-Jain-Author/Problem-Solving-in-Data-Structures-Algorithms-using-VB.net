Imports System

Public Class StackLL
	Private head As Node = Nothing
	Private count As Integer = 0

	Private Class Node
		Friend value As Integer
		Friend [next] As Node

		Public Sub New(ByVal v As Integer, ByVal n As Node)
			value = v
			[next] = n
		End Sub
	End Class

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
			Throw New System.InvalidOperationException("StackEmptyException")
		End If
		Return head.value
	End Function

	Public Sub Push(ByVal value As Integer)
		head = New Node(value, head)
		count += 1
	End Sub

	Public Function Pop() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("StackEmptyException")
		End If
		Dim value As Integer = head.value
		head = head.next
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

	Public Sub Print()
		Dim temp As Node = head
		Do While temp IsNot Nothing
			Console.Write(temp.value & " ")
			temp = temp.next
		Loop
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim s As New StackLL()
		s.Push(1)
		s.Push(2)
		s.Push(3)
		s.Print()
		Console.WriteLine(s.Pop())
		s.Print()
	End Sub
End Class

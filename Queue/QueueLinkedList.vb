Imports System

Public Class QueueLL
	Private tail As Node = Nothing
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

	' Other Methods 

	Public Function peek() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("StackEmptyException")
		End If
		Dim value As Integer
		If tail Is tail.next Then
			value = tail.value
		Else
			value = tail.next.value
		End If

		Return value
	End Function

	Public Sub add(ByVal value As Integer)
		Dim temp As New Node(value, Nothing)

		If tail Is Nothing Then
			tail = temp
			tail.next = tail
		Else
			temp.next = tail.next
			tail.next = temp
			tail = temp
		End If
		count += 1
	End Sub

	Public Function remove() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("StackEmptyException")
		End If

		Dim value As Integer = 0
		If tail Is tail.next Then
			value = tail.value
			tail = Nothing
		Else
			value = tail.next.value
			tail.next = tail.next.next
		End If
		count -= 1
		Return value
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim q As New QueueLL()
		q.add(1)
		q.add(2)
		q.add(3)
		For i As Integer = 0 To 2
			Console.WriteLine(q.remove())
		Next i
	End Sub
End Class
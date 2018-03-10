Imports System
Imports System.Collections

Public Class ArrayStack

	Private Const CAPACITY As Integer = 1000
	Private data() As Integer
	Private top As Integer = -1

	Public Sub New()
		Me.New(CAPACITY)
	End Sub

	Public Sub New(ByVal capacity As Integer)
		data = New Integer(capacity - 1) {}
	End Sub
	' Other stack fields and methods.


	Public Function size() As Integer
		Return (top + 1)
	End Function

	Public ReadOnly Property Empty() As Boolean
		Get
			Return (top = -1)
		End Get
	End Property

	Public Sub Push(ByVal value As Integer)
		If size() = data.Length Then
			Throw New System.InvalidOperationException("ArrayStackOvarflowException")
		End If
		top += 1
		data(top) = value
	End Sub


	Public Function Peek() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("ArrayStackEmptyException")
		End If
		Return data(top)
	End Function

	Public Function Pop() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("ArrayStackEmptyException")
		End If
		Dim topVal As Integer = data(top)
		top -= 1
		Return topVal
	End Function

	Public Sub Print()
		For i As Integer = top To 0 Step -1
			Console.Write(" " & data(i))
		Next i
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim s As New ArrayStack(1000)
		For i As Integer = 1 To 100
			s.Push(i)
		Next i
		For i As Integer = 1 To 50
			s.Pop()
		Next i
		s.Print()
	End Sub
End Class
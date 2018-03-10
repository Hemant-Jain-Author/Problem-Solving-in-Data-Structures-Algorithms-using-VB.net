Imports System
Imports System.Collections

Public Class GrowingReducingStack
	Private Const MIN_CAPACITY As Integer = 1000
	Private data() As Integer
	Private top As Integer = -1
	Private minCapacity As Integer
	Private maxCapacity As Integer

	Public Sub New()
		Me.New(MIN_CAPACITY)
		minCapacity = MIN_CAPACITY
		maxCapacity = minCapacity
	End Sub

	Public Sub New(ByVal capacity As Integer)
		data = New Integer(capacity - 1) {}
		minCapacity = capacity
		maxCapacity = minCapacity
	End Sub


	Public Function size() As Integer
		Return (top + 1)
	End Function

	Public ReadOnly Property Empty() As Boolean
		Get
			Return (top = -1)
		End Get
	End Property

	Public Sub Push(ByVal value As Integer)
		If size() = maxCapacity Then
			Console.WriteLine("size dubbelled")
			Dim newData((maxCapacity * 2) - 1) As Integer
			Array.Copy(data, 0, newData, 0, maxCapacity)
			data = newData
			maxCapacity = maxCapacity * 2
		End If
		top += 1
		data(top) = value
	End Sub

	Public Function Peek() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("GrowingReducingStackEmptyException")
		End If
		Return data(top)
	End Function

	Public Function Pop() As Integer
		If Empty Then
			Throw New System.InvalidOperationException("GrowingReducingStackEmptyException")
		End If

		Dim topVal As Integer = data(top)
		top -= 1

		If size() = maxCapacity \ 2 AndAlso maxCapacity > minCapacity Then
			Console.WriteLine("size halfed")
			maxCapacity = maxCapacity \ 2
			Dim newData(maxCapacity - 1) As Integer
			Array.Copy(data, 0, newData, 0, maxCapacity)
			data = newData
		End If
		Return topVal
	End Function

	Public Sub print()
		For i As Integer = top To 0 Step -1
			Console.Write(" " & data(i))
		Next i
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim s As New GrowingReducingStack(10)
		For i As Integer = 1 To 100
			s.Push(i)
		Next i
		For i As Integer = 1 To 100
			s.Pop()
		Next i
		s.print()
	End Sub
End Class
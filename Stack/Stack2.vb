Imports System

Public Class Stack2
	Private data() As Integer
	Private top As Integer = -1
	Private minCapacity As Integer
	Private capacity As Integer

	Public Sub New()
		Me.New(1000)
	End Sub

	Public Sub New(ByVal size As Integer)
		data = New Integer(size - 1){}
		minCapacity = size
		capacity = minCapacity
	End Sub

	' Other methods 

	Public Function Size() As Integer
		Return (top + 1)
	End Function

	Public Function IsEmpty() As Boolean
		Return (top = -1)
	End Function

	Public Sub Push(ByVal value As Integer)
		If Size() = capacity Then
			Console.WriteLine("size doubled")
			Dim newData((capacity * 2) - 1) As Integer
			Array.Copy(data, 0, newData, 0, capacity)
			data = newData
			capacity = capacity * 2
		End If
		top += 1
		data(top) = value
	End Sub

	Public Function Peek() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException("StackEmptyException")
		End If
		Return data(top)
	End Function

	Public Function Pop() As Integer
		If IsEmpty() Then
			Throw New System.InvalidOperationException("StackEmptyException")
		End If

		Dim topVal As Integer = data(top)
		top -= 1
		If Size() = capacity \ 2 AndAlso capacity > minCapacity Then
			Console.WriteLine("size halved")
			capacity = capacity \ 2
			Dim newData(capacity - 1) As Integer
			Array.Copy(data, 0, newData, 0, capacity)
			data = newData
		End If
		Return topVal
	End Function

	Public Sub Print()
		For i As Integer = top To 0 Step -1
			Console.Write(data(i) & " ")
		Next i
		Console.WriteLine()
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim s As New Stack2(5)
		For i As Integer = 1 To 11
			s.Push(i)
		Next i
		s.Print()
		For i As Integer = 1 To 11
			s.Pop()
		Next i
	End Sub
End Class
'
'size doubled
'size doubled
'11 10 9 8 7 6 5 4 3 2 1 
'size halved
'size halved
'
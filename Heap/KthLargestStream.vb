
Imports System

Public Class KthLargestStream
	Friend pq As New PriorityQueue(Of Integer)()
	Friend size As Integer = 0
	Friend k As Integer = 10

	Friend Sub New(ByVal a As Integer)
		k = a
	End Sub

	Public Sub Add(ByVal value As Integer)
		If size < k Then
			pq.Add(value)
		ElseIf pq.Peek() < value Then
				pq.Add(value)
				pq.Remove()
		End If
		size += 1
	End Sub

	Public Sub Print()
		Console.WriteLine(pq)
	End Sub

	Public Sub Add2(ByVal value As Integer)
		If size < k Then
			pq.Add(value)
			Console.Write("- ")
		Else
			If pq.Peek() < value Then
				pq.Add(value)
				pq.Remove()
			End If
			Console.Write(pq.Peek() & " ")
		End If
		size += 1
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim kt As New KthLargestStream(10)
		Dim value As Integer
		Dim rand As New Random()
		For i As Integer = 0 To 99
			value = rand.Next(1000)
			kt.Add2(value)
		Next i
		kt.Print()
	End Sub
End Class
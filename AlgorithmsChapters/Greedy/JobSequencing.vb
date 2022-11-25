Imports System

Public Class JobSequencing
	Private jobs() As Job
	Private n As Integer
	Private maxDL As Integer

	Friend Class Job
		Friend id As Char
		Friend deadline, profit As Integer

		Friend Sub New(ByVal id As Char, ByVal deadline As Integer, ByVal profit As Integer)
			Me.id = id
			Me.deadline = deadline
			Me.profit = profit
		End Sub
	End Class

	Public Sub New(ByVal ids() As Char, ByVal deadlines() As Integer, ByVal profits() As Integer, ByVal n As Integer)
		Me.jobs = New Job(n - 1){}
		Me.n = n
		Me.maxDL = deadlines(0)
		For i As Integer = 1 To n - 1
			If deadlines(i) > Me.maxDL Then
			Me.maxDL = deadlines(i)
			End If
		Next i

		For i As Integer = 0 To n - 1
			Me.jobs(i) = New Job(ids(i), deadlines(i), profits(i))
		Next i
	End Sub

	Public Sub Print()
		Array.Sort(Me.jobs, Function(a, b) b.profit - a.profit)
		Dim result(Me.maxDL - 1) As Boolean
		Dim job(Me.maxDL - 1) As Char
		Dim profit As Integer = 0

		' Iterate through all given jobs
		For i As Integer = 0 To n - 1
			For j As Integer = Me.jobs(i).deadline - 1 To 0 Step -1
				If result(j) = False Then
					result(j) = True
					job(j) = Me.jobs(i).id
					profit += Me.jobs(i).profit
					Exit For
				End If
			Next j
		Next i
		Console.WriteLine("Profit is :: " & profit)
		Console.Write("Jobs selected are::")
		For i As Integer = 0 To Me.maxDL - 1
			If job(i) <> ChrW(&H0000) Then
				Console.Write(" " & job(i))
			End If
		Next i
	End Sub


	Sub Main(ByVal args() As String)
		Dim id() As Char = {"a"c, "b"c, "c"c, "d"c, "e"c}
		Dim deadline() As Integer = {3, 1, 2, 4, 4}
		Dim profit() As Integer = {50, 40, 27, 31, 30}
		Dim js As New JobSequencing(id, deadline, profit, 5)
		js.Print()
	End Sub
End Class

'
'Profit is :: 151
'Jobs selected are:: b e a d
'
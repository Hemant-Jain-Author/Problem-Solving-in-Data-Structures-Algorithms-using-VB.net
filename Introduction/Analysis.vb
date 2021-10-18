Imports System

Public Class Analysis

	Public Function Fun1(ByVal n As Integer) As Integer
		Dim m As Integer = 0
		For i As Integer = 0 To n - 1
			m += 1
		Next i
		Return m
	End Function

	Public Function Fun2(ByVal n As Integer) As Integer
		Dim i As Integer, j As Integer, m As Integer = 0
		For i = 0 To n - 1
			For j = 0 To n - 1
				m += 1
			Next j
		Next i
		Return m
	End Function

	Public Function Fun3(ByVal n As Integer) As Integer
		Dim i As Integer, j As Integer, m As Integer = 0
		For i = 0 To n - 1
			For j = 0 To i - 1
				m += 1
			Next j
		Next i
		Return m
	End Function

	Public Function Fun4(ByVal n As Integer) As Integer
		Dim i As Integer, m As Integer = 0
		i = 1
		Do While i < n
			m += 1
			i = i * 2
		Loop
		Return m
	End Function

	Public Function Fun5(ByVal n As Integer) As Integer
		Dim i As Integer, m As Integer = 0
		i = n
		Do While i > 0
			m += 1
			i = i \ 2
		Loop
		Return m
	End Function

	Public Function Fun6(ByVal n As Integer) As Integer
		Dim i As Integer, j As Integer, k As Integer, m As Integer = 0
		For i = 0 To n - 1
			For j = 0 To n - 1
				For k = 0 To n - 1
					m += 1
				Next k
			Next j
		Next i
		Return m
	End Function

	Public Function Fun7(ByVal n As Integer) As Integer
		Dim i As Integer, j As Integer, k As Integer, m As Integer = 0
		For i = 0 To n - 1
			For j = 0 To n - 1
				m += 1
			Next j
		Next i
		For i = 0 To n - 1
			For k = 0 To n - 1
				m += 1
			Next k
		Next i
		Return m
	End Function

	Public Function Fun8(ByVal n As Integer) As Integer
		Dim i As Integer, j As Integer, m As Integer = 0
		i = 0
		Do While i < n
			j = 0
			Do While j < Math.Sqrt(n)
				m += 1
				j += 1
			Loop
			i += 1
		Loop
		Return m
	End Function

	Public Function Fun9(ByVal n As Integer) As Integer
		Dim i As Integer, j As Integer, m As Integer = 0
		i = n
		Do While i > 0
			For j = 0 To i - 1
				m += 1
			Next j
			i \= 2
		Loop
		Return m
	End Function

	Public Function Fun10(ByVal n As Integer) As Integer
		Dim i As Integer, j As Integer, m As Integer = 0
		For i = 0 To n - 1
			For j = i To 1 Step -1
				m += 1
			Next j
		Next i
		Return m
	End Function

	Public Function Fun11(ByVal n As Integer) As Integer
		Dim i As Integer, j As Integer, k As Integer, m As Integer = 0
		For i = 0 To n - 1
			For j = i To n - 1
				For k = j + 1 To n - 1
					m += 1
				Next k
			Next j
		Next i
		Return m
	End Function

	Public Function Fun12(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, m As Integer = 0
		For i = 0 To n - 1
			Do While j < n
				m += 1
				j += 1
			Loop
		Next i
		Return m
	End Function

	Public Function Fun13(ByVal n As Integer) As Integer
		Dim i As Integer, j As Integer = 0, m As Integer = 0
		i = 1
		Do While i <= n
			For j = 0 To i
				m += 1
			Next j
			i *= 2
		Loop
		Return m
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim a As New Analysis()
		Console.WriteLine("N = 100, Number of instructions in O(n)::" & a.Fun1(100))
		Console.WriteLine("N = 100, Number of instructions in O(n^2)::" & a.Fun2(100))
		Console.WriteLine("N = 100, Number of instructions in O(n^2)::" & a.Fun3(100))
		Console.WriteLine("N = 100, Number of instructions in O(log(n))::" & a.Fun4(100))
		Console.WriteLine("N = 100, Number of instructions in O(log(n))::" & a.Fun5(100))
		Console.WriteLine("N = 100, Number of instructions in O(n^3)::" & a.Fun6(100))
		Console.WriteLine("N = 100, Number of instructions in O(n^2)::" & a.Fun7(100))
		Console.WriteLine("N = 100, Number of instructions in O(n^(3/2))::" & a.Fun8(100))
		Console.WriteLine("N = 100, Number of instructions in O(n)::" & a.Fun9(100))
		Console.WriteLine("N = 100, Number of instructions in O(n^2)::" & a.Fun10(100))
		Console.WriteLine("N = 100, Number of instructions in O(n^3)::" & a.Fun11(100))
		Console.WriteLine("N = 100, Number of instructions in O(n)::" & a.Fun12(100))
		Console.WriteLine("N = 100, Number of instructions in O(n)::" & a.Fun13(100))
	End Sub
End Class

'
'N = 100, Number of instructions in O(n)::100
'N = 100, Number of instructions in O(n^2)::10000
'N = 100, Number of instructions in O(n^2)::4950
'N = 100, Number of instructions in O(log(n))::7
'N = 100, Number of instructions in O(log(n))::7
'N = 100, Number of instructions in O(n^3)::1000000
'N = 100, Number of instructions in O(n^2)::20000
'N = 100, Number of instructions in O(n^(3/2))::1000
'N = 100, Number of instructions in O(n)::197
'N = 100, Number of instructions in O(n^2)::4950
'N = 100, Number of instructions in O(n^3)::166650
'N = 100, Number of instructions in O(n)::100
'N = 100, Number of instructions in O(n)::134
'
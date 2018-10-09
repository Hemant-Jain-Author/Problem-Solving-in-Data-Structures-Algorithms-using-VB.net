Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Class Analysis


	Public Shared Function Main(ByVal args() As String) As Integer
		Dim a As New Analysis()
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun1(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun2(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun3(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun4(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun5(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun6(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun7(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun8(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun9(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun10(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun11(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun12(100))
		System.Console.WriteLine("N = 100, Number of instructions :: " & a.fun13(100))

		Return 0
	End Function


	Function fun1(ByVal n As Integer) As Integer
		Dim m As Integer = 0
		For i As Integer = 0 To n - 1
			m += 1
		Next i
		Return m
	End Function

	Function fun2(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, m As Integer = 0
		For i = 0 To n - 1
			For j = 0 To n - 1
				m += 1
			Next j
		Next i
		Return m
	End Function

	Function fun3(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, m As Integer = 0
		For i = 0 To n - 1
			For j = 0 To i - 1
				m += 1
			Next j
		Next i
		Return m
	End Function

	Function fun4(ByVal n As Integer) As Integer
		Dim i As Integer = 0, m As Integer = 0
		i = 1
		Do While i < n
			m += 1
			i = i * 2
		Loop
		Return m
	End Function

	Function fun5(ByVal n As Integer) As Integer
		Dim i As Integer = 0, m As Integer = 0
		i = n
		Do While i > 0
			m += 1
			i = i \ 2
		Loop
		Return m
	End Function


	Function fun6(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, k As Integer = 0, m As Integer = 0
		i = n
		For i = 0 To n - 1
			For j = 0 To n - 1
				For k = 0 To n - 1
					m += 1
				Next k
			Next j
		Next i
		Return m
	End Function


	Function fun7(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, k As Integer = 0, m As Integer = 0
		i = n
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

	Function fun8(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, m As Integer = 0
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

	Function fun9(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, m As Integer = 0
		i = n
		Do While i > 0
			For j = 0 To i - 1
				m += 1
			Next j
			i \= 2
		Loop
		Return m
	End Function

	Function fun10(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, m As Integer = 0
		For i = 0 To n - 1
			For j = i To 1 Step -1
				m += 1
			Next j
		Next i
		Return m
	End Function

	Function fun11(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, k As Integer = 0, m As Integer = 0
		For i = 0 To n - 1
			For j = i To n - 1
				For k = j + 1 To n - 1
					m += 1
				Next k
			Next j
		Next i
		Return m
	End Function

	Function fun12(ByVal n As Integer) As Integer
		Dim i As Integer = 0, j As Integer = 0, m As Integer = 0
		For i = 0 To n - 1
			Do While j < n
				m += 1
				j += 1
			Loop
		Next i
		Return m
	End Function

	Function fun13(ByVal n As Integer) As Integer
		Dim i As Integer = 1, j As Integer = 0, m As Integer = 0
		i = 1
		Do While i <= n
			For j = 0 To i
				m += 1
			Next j
			i *= 2
		Loop
		Return m
	End Function
End Class
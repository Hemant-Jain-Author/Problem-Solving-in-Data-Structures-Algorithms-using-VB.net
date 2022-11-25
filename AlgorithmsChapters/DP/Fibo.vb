Imports System

Public Module Fibo
	Function Fibonacci(ByVal n As Integer) As Integer
		If n <= 2 Then
			Return n - 1
		End If
		Return Fibonacci(n - 1) + Fibonacci(n - 2)
	End Function

	Sub FibonacciSeries(ByVal n As Integer)
		For i As Integer = 1 To n
			Console.Write(Fibonacci(i) & " ")
		Next i
	End Sub


	Function FibonacciBU(ByVal n As Integer) As Integer
		If n <= 2 Then
			Return n - 1
		End If

		Dim first As Integer = 0, second As Integer = 1
		Dim temp As Integer = 0

		For i As Integer = 2 To n - 1
			temp = first + second
			first = second
			second = temp
		Next i
		Return temp
	End Function

	Sub FibonacciSeriesBU(ByVal n As Integer)
		If n < 1 Then
			Return
		End If

		Dim dp(n - 1) As Integer
		dp(0) = 0
		dp(1) = 1

		For i As Integer = 2 To n - 1
			dp(i) = dp(i - 2) + dp(i - 1)
		Next i

		For i As Integer = 0 To n - 1
			Console.Write(dp(i) & " ")
		Next i
	End Sub

	Sub FibonacciSeriesTD(ByVal n As Integer)
		If n < 1 Then
			Return
		End If
		Dim dp(n - 1) As Integer

		FibonacciSeriesTD(n - 1, dp)

		For i As Integer = 0 To n - 1
			Console.Write(dp(i) & " ")
		Next i
	End Sub

	Function FibonacciSeriesTD(ByVal n As Integer, ByVal dp() As Integer) As Integer
		If n <= 1 Then
			dp(n) = n
			Return dp(n)
		End If

		If dp(n) <> 0 Then
			Return dp(n)
		End If

		dp(n) = FibonacciSeriesTD(n - 1, dp) + FibonacciSeriesTD(n - 2, dp)
		Return dp(n)
	End Function

	Sub Main(ByVal args() As String)

		FibonacciSeries(6)
		Console.WriteLine()

		FibonacciSeriesBU(6)
		Console.WriteLine()

		FibonacciSeriesTD(6)
		Console.WriteLine()

		Console.WriteLine(Fibonacci(6))
		Console.WriteLine(FibonacciBU(6))
	End Sub
End Module

'
'0 1 1 2 3 5 
'0 1 1 2 3 5 
'0 1 1 2 3 5 
'5
'5
'
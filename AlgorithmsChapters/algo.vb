Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Class algo
	Public Shared Function fibonacci(ByVal n As Integer) As Integer
		If n <= 1 Then
			Return n
		End If

		Return fibonacci(n - 1) + fibonacci(n - 2)
	End Function

	Public Shared Function fibonacci2(ByVal n As Integer) As Integer
		Dim first As Integer = 0
		Dim second As Integer = 1
		Dim temp As Integer = 0

		If n = 0 Then
			Return first
		ElseIf n = 1 Then
			Return second
		End If

		Dim i As Integer = 2
		Do While i <= n
			temp = first + second
			first = second
			second = temp
			i += 1
		Loop
		Return temp
	End Function

	Public Shared Sub print(ByVal Q() As Integer, ByVal n As Integer)
		For i As Integer = 0 To n - 1
			Console.Write(" " & Q(i))
		Next i
		Console.WriteLine(" ")
	End Sub

	Public Shared Function Feasible(ByVal Q() As Integer, ByVal k As Integer) As Boolean
		For i As Integer = 0 To k - 1
			If Q(k) = Q(i) OrElse Math.Abs(Q(i) - Q(k)) = Math.Abs(i - k) Then
				Return False
			End If
		Next i
		Return True
	End Function

	Public Shared Sub NQueens(ByVal Q() As Integer, ByVal k As Integer, ByVal n As Integer)
		If k = n Then
			print(Q, n)
			Return
		End If
		Dim i As Integer = 0
		Do While i < n
			Q(k) = i
			If Feasible(Q, k) Then
				NQueens(Q, k + 1, n)
			End If
			i += 1
		Loop
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim Q(7) As Integer
		NQueens(Q, 0, 8)
	End Sub

	Public Shared Sub TOHUtil(ByVal num As Integer, ByVal from As Char, ByVal [to] As Char, ByVal temp As Char)
		If num < 1 Then
			Return
		End If

		TOHUtil(num - 1, from, temp, [to])
		Console.WriteLine("Move disk " & num & " from peg " & from & " to peg " & [to])
		TOHUtil(num - 1, temp, [to], from)
	End Sub

	Public Shared Sub TowersOfHanoi(ByVal num As Integer)
		Console.WriteLine("The sequence of moves involved in the Tower of Hanoi are :")
		TOHUtil(num, "A"c, "C"c, "B"c)
	End Sub

	Public Shared Sub main2(ByVal args() As String)
		TowersOfHanoi(3)
	End Sub

	Private Function isPrime(ByVal n As Integer) As Boolean
		Dim answer As Boolean = If(n > 1, True, False)

		Dim i As Integer = 2
		Do While i * i <= n
			If n Mod i = 0 Then
				answer = False
				Exit Do
			End If
			i += 1
		Loop
		Return answer
	End Function
End Class
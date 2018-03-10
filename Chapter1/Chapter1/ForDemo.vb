Imports System

Public Class ForDemo

	Private Const text As String = "Hello, World!"
	Friend Const PI As Double = 3.1415926535897931

    Public Shared Sub Main111(ByVal args() As String)
        Dim numbers() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
        Dim sum As Integer = 0
        For Each n As Integer In numbers
            sum += n
        Next n
        Console.WriteLine("Sum is :: " & sum)
    End Sub

	Public Shared Sub Main6666(ByVal args() As String)

		Dim numbers() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		Dim sum As Integer = 0
		For i As Integer = 0 To numbers.Length - 1
			sum += numbers(i)
		Next i

		Console.WriteLine("Sum is :: " & sum)
	End Sub

	Public Shared Sub Main3(ByVal args() As String)

		Dim numbers() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		Dim sum As Integer = 0
		Dim i As Integer = 0
		Do While i < numbers.Length
			sum += numbers(i)
			i += 1
		Loop
		Console.WriteLine("Sum is :: " & sum)
	End Sub
End Class

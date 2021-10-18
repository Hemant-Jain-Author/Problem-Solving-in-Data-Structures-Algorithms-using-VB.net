Imports System

Public Class ForDemo

	Friend Const PI As Double = 3.141592653589793

	Public Shared Sub main1()
		Dim numbers() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		Dim sum As Integer = 0
		For Each n As Integer In numbers
			sum += n
		Next n

		Console.WriteLine("Sum is :: " & sum)
	End Sub

	Public Shared Sub main2()
		Dim numbers() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		Dim sum As Integer = 0
		For i As Integer = 0 To numbers.Length - 1
			sum += numbers(i)
		Next i

		Console.WriteLine("Sum is :: " & sum)
	End Sub

	Public Shared Sub main3()
		Dim numbers() As Integer = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
		Dim sum As Integer = 0
		Dim i As Integer = 0
		Do While i < numbers.Length
			sum += numbers(i)
			i += 1
		Loop
		Console.WriteLine("Sum is :: " & sum)
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		main1()
		main2()
		main3()
	End Sub
End Class

'
'Sum is :: 55
'Sum is :: 55
'Sum is :: 55
'
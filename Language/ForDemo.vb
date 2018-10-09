Imports System

Public Class ForDemo
	Private Const text As String = "Hello, World!"
	Friend Const PI As Double = 3.141592653589793

	Public Shared Sub Main1(ByVal args() As String)
		If True Then
			' statements
		End If

		If True Then
			' if condition statements boolean condition true
		Else
			' else condition statements, boolean condition false
		End If
	End Sub

	Public Shared Sub Main2(ByVal args() As String)
		Dim numbers() As Integer = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
		Dim sum As Integer = 0
		For Each n As Integer In numbers
			sum += n
		Next n
		Console.WriteLine("Sum is :: " & sum)
	End Sub


	Public Shared Sub Main3(ByVal args() As String)
		Dim numbers() As Integer = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
		Dim sum As Integer = 0
		For i As Integer = 0 To numbers.Length - 1
			sum += numbers(i)
		Next i

		Console.WriteLine("Sum is :: " & sum)
	End Sub

	Public Shared Sub Main4(ByVal args() As String)
		Dim numbers() As Integer = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
		Dim sum As Integer = 0
		Dim i As Integer = 0
		Do While i < numbers.Length
			sum += numbers(i)
			i += 1
		Loop
		Console.WriteLine("Sum is :: " & sum)
	End Sub

	'	String[] stra=new String[2];
	'	stra[0]="hello";
	'	stra[1]="hello";
	'	main2(stra);
End Class

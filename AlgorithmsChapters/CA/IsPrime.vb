Imports System

Public Class IsPrime
	Public Shared Function TestPrime(ByVal n As Integer) As Boolean
		Dim answer As Boolean = If(n > 1, True, False)
		Dim i As Integer = 2
		Do While i * i <= n
			If n Mod i = 0 Then
				answer = True
				Exit Do
			End If
			i += 1
		Loop
		Return answer
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Console.WriteLine(IsPrime.TestPrime(7))
	End Sub
End Class
' True
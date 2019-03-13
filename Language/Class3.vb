Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Class Introduction3333
	Public Shared Sub Main333(ByVal args() As String)
		Dim arr() As Integer = { 1, -2, 3, 4, -4, 6, -14, 8, 2 }
		Console.WriteLine("Max sub array sum :" & maxSubArraySum2(arr, 9))
	End Sub

	Public Shared Function maxSubArraySum2(ByVal a() As Integer, ByVal size As Integer) As Integer
		Dim maxSoFar As Integer = 0, maxEndingHere As Integer = 0

		For i As Integer = 0 To size - 1
			maxEndingHere = maxEndingHere + a(i)
			If maxEndingHere < 0 Then
				maxEndingHere = 0
			End If
			If maxSoFar < maxEndingHere Then
				maxSoFar = maxEndingHere
			End If
		Next i
		Return maxSoFar
	End Function
End Class

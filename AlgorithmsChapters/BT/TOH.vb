Imports System

' Towers Of Hanoi problem.
Public Class TOH
	Private Shared Sub TOHUtil(ByVal num As Integer, ByVal src As Char, ByVal dst As Char, ByVal temp As Char)
		If num < 1 Then
			Return
		End If

		TOHUtil(num - 1, src, temp, dst)
		Console.WriteLine("Move disk " & num & " from peg " & src & " to peg " & dst)
		TOHUtil(num - 1, temp, dst, src)
	End Sub

	Public Shared Sub TOHSteps(ByVal num As Integer)
		Console.WriteLine("The sequence of moves involved in the Tower of Hanoi are :")
		TOHUtil(num, "A"c, "C"c, "B"c)
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		TOH.TOHSteps(3)
	End Sub
End Class
'
'The sequence of moves involved in the Tower of Hanoi are :
'Move disk 1 src peg A to peg C
'Move disk 2 src peg A to peg B
'Move disk 1 src peg C to peg B
'Move disk 3 src peg A to peg C
'Move disk 1 src peg B to peg A
'Move disk 2 src peg B to peg C
'Move disk 1 src peg A to peg C
'
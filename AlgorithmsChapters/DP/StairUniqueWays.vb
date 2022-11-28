Imports System

Public Module StairUniqueWays
	Function UniqueWaysBU(ByVal n As Integer) As Integer
		If n <= 2 Then
			Return n
		End If

		Dim first As Integer = 1, second As Integer = 2
		Dim temp As Integer = 0

		For i As Integer = 3 To n
			temp = first + second
			first = second
			second = temp
		Next i
		Return temp
	End Function

	Function UniqueWaysBU2(ByVal n As Integer) As Integer
		If n < 2 Then
			Return n
		End If

		Dim ways(n - 1) As Integer
		ways(0) = 1
		ways(1) = 2

		For i As Integer = 2 To n - 1
			ways(i) = ways(i - 1) + ways(i - 2)
		Next i

		Return ways(n - 1)
	End Function

	' Testing code.
	Sub Main(ByVal args() As String)
		Console.WriteLine("Unique way to reach top:: " & UniqueWaysBU(4))
		Console.WriteLine("Unique way to reach top:: " & UniqueWaysBU2(4))
	End Sub
End Module
'
'Unique way to reach top:: 5
'Unique way to reach top:: 5
'
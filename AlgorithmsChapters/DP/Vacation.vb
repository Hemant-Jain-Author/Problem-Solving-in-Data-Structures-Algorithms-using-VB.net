Imports System

Public Class Vacation
	' days are must travel days, costs are cost of tickets.
	Public Shared Function minCost(ByVal days() As Integer, ByVal costs() As Integer) As Integer
		Dim n As Integer = days.Length
		Dim max As Integer = days(n - 1)
		Dim dp(max) As Integer

		Dim j As Integer = 0
		For i As Integer = 1 To max
			If days(j) = i Then ' That days is definitely travelled.
				j += 1
				dp(i) = dp(i - 1) + costs(0)
				dp(i) = Math.Min(dp(i), dp(Math.Max(0, i - 7)) + costs(1))
				dp(i) = Math.Min(dp(i), dp(Math.Max(0, i - 30)) + costs(2))
			Else
				dp(i) = dp(i - 1) ' day may be ignored.
			End If
		Next i
		Return dp(max)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim days() As Integer = {1, 3, 5, 7, 12, 20, 30}
		Dim costs() As Integer = {2, 7, 20}
		Console.WriteLine("Min cost is:" & minCost(days, costs))

	End Sub
End Class
'
'Min cost is:13
'
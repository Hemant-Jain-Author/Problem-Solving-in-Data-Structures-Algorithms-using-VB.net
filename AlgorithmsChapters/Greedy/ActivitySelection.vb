Imports System


' Activities selection problem.

' Prints a maximum set of activities that can be done by a 
' single person performing one task at a time.
' s() is an array that contains start time of all activities
' f() is an array that contains finish time of all activities

Public Module ActivitySelection
	Friend Class Activity
		Implements IComparable(Of Activity)

		Friend start, finish As Integer

		Friend Sub New(ByVal s As Integer, ByVal f As Integer)
			start = s
			finish = f
		End Sub

		Private Function IComparable_CompareTo(other As Activity) As Integer Implements IComparable(Of Activity).CompareTo
			Return Me.finish - other.finish
		End Function
	End Class

	Public Sub MaxActivities(ByVal s() As Integer, ByVal f() As Integer, ByVal n As Integer)
		Dim act(n - 1) As Activity
		Dim i As Integer
		For i = 0 To n - 1
			act(i) = New Activity(s(i), f(i))
		Next i
		Array.Sort(act) ' sort according to finish time.

		i = 0 ' The first activity at index 0 is always gets selected.
		Console.Write("Activities are : (" & act(i).start & "," & act(i).finish & ")")

		For j As Integer = 1 To n - 1
			' Find next activity whose start time is greater than or equal
			' to the finish time of previous activity.
			If act(j).start >= act(i).finish Then
				Console.Write(", (" & act(j).start & "," & act(j).finish & ")")
				i = j
			End If
		Next j
	End Sub

	' Testing code.
	Sub Main(ByVal args() As String)
		Dim s() As Integer = {1, 5, 0, 3, 5, 6, 8}
		Dim f() As Integer = {2, 6, 5, 4, 9, 7, 9}
		Dim n As Integer = s.Length
		MaxActivities(s, f, n)
	End Sub
End Module

'
'Activities are : (1,2), (3,4), (5,6), (6,7), (8,9)
'
Imports System

Public Class ShellSort
	Private Function more(ByVal value1 As Integer, ByVal value2 As Integer) As Boolean
		Return value1 > value2
	End Function

	Public Sub Sort(ByVal arr() As Integer)
		Dim n As Integer = arr.Length

		' Gap starts with n/2 and half in each iteration.
		Dim gap As Integer = n \ 2
		While gap > 0
			' Do a gapped insertion Sort.
			For i As Integer = gap To n - 1
				Dim curr As Integer = arr(i)

				' Shift elements of already Sorted list
				' to find right position for curr value.
				Dim j As Integer
				j = i
				While j >= gap AndAlso more(arr(j - gap), curr)
					arr(j) = arr(j - gap)
					j -= gap
				End While

				' Put current value in its correct location
				arr(j) = curr
			Next i
			gap \= 2
		End While
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim array() As Integer = {36, 32, 11, 6, 19, 31, 17, 3}

		Dim b As New ShellSort()
		b.Sort(array)
		For i As Integer = 0 To array.Length - 1
			Console.Write(array(i) & " ")
		Next i
	End Sub
End Class

'
'3 6 11 17 19 31 32 36 
'
Imports System

' Also known as Activity Selection Weighted.
Public Class JobScheduling
	Public Class Job
		Implements IComparable(Of Job)

		Friend start, finish, value As Integer

		Friend Sub New(ByVal s As Integer, ByVal f As Integer, ByVal v As Integer)
			start = s
			finish = f
			value = v
		End Sub

		Private Function IComparable_CompareTo(other As Job) As Integer Implements IComparable(Of Job).CompareTo
			Return Me.finish - other.finish
		End Function
	End Class

	Public Shared Function MaxValueJobsUtil(ByVal arr() As Job, ByVal n As Integer) As Integer
		' Base case
		If n = 1 Then
			Return arr(0).value
		End If

		' Find Value when current job is included
		Dim incl As Integer = arr(n - 1).value
		For j As Integer = n - 1 To 0 Step -1
			If arr(j).finish <= arr(n - 1).start Then
				incl += MaxValueJobsUtil(arr, j + 1)
				Exit For
			End If
		Next j

		' Find Value when current job is excluded
		Dim excl As Integer = MaxValueJobsUtil(arr, n - 1)

		Return Math.Max(incl, excl)
	End Function


	Public Shared Function MaxValueJobs(ByVal s() As Integer, ByVal f() As Integer, ByVal v() As Integer, ByVal n As Integer) As Integer
		Dim act(n - 1) As Job
		For i As Integer = 0 To n - 1
			act(i) = New Job(s(i), f(i), v(i))
		Next i
		Array.Sort(act) ' sort according to finish time.
		Return MaxValueJobsUtil(act, n)
	End Function

	Private Shared Function MaxValueJobsUtilTD(ByVal dp() As Integer, ByVal arr() As Job, ByVal n As Integer) As Integer
		' Base case
		If n = 0 Then
			Return 0
		End If

		If dp(n - 1) <> 0 Then
			Return dp(n - 1)
		End If

		' Find Value when current job is included
		Dim incl As Integer = arr(n - 1).value
		For j As Integer = n - 2 To 0 Step -1
			If arr(j).finish <= arr(n - 1).start Then
				incl += MaxValueJobsUtilTD(dp, arr, j + 1)
				Exit For
			End If
		Next j

		' Find Value when current job is excluded
		Dim excl As Integer = MaxValueJobsUtilTD(dp, arr, n - 1)
		dp(n - 1) = Math.Max(incl, excl)
		Return dp(n - 1)
	End Function


	Public Shared Function MaxValueJobsTD(ByVal s() As Integer, ByVal f() As Integer, ByVal v() As Integer, ByVal n As Integer) As Integer
		Dim act(n - 1) As Job
		For i As Integer = 0 To n - 1
			act(i) = New Job(s(i), f(i), v(i))
		Next i
		Array.Sort(act) ' sort according to finish time.
		Dim dp(n - 1) As Integer
		Return MaxValueJobsUtilTD(dp, act, n)
	End Function

	Public Shared Function MaxValueJobsBU(ByVal s() As Integer, ByVal f() As Integer, ByVal v() As Integer, ByVal n As Integer) As Integer
		Dim act(n - 1) As Job
		For i As Integer = 0 To n - 1
			act(i) = New Job(s(i), f(i), v(i))
		Next i
		Array.Sort(act) ' sort according to finish time.

		Dim dp(n - 1) As Integer
		dp(0) = act(0).value

		For i As Integer = 1 To n - 1
			Dim incl As Integer = act(i).value
			For j As Integer = i - 1 To 0 Step -1
				If act(j).finish <= act(i).start Then
					incl += dp(j)
					Exit For
				End If
			Next j
			dp(i) = Math.Max(incl, dp(i - 1))
		Next i
		Return dp(n - 1)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim start() As Integer = {1, 5, 0, 3, 5, 6, 8}
		Dim finish() As Integer = {2, 6, 5, 4, 9, 7, 9}
		Dim value() As Integer = {2, 2, 4, 3, 10, 2, 8}
		Dim n As Integer = start.Length
		Console.WriteLine(MaxValueJobs(start, finish, value, n))
		Console.WriteLine(MaxValueJobsTD(start, finish, value, n))
		Console.WriteLine(MaxValueJobsBU(start, finish, value, n))
	End Sub
End Class

'
'17
'17
'17
'
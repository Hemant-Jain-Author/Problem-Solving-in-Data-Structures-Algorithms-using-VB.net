Imports System
Imports System.Collections.Generic

Public Class QueueEx

	Public Shared Function CircularTour(ByVal arr(,) As Integer, ByVal n As Integer) As Integer
		Dim que As New Queue(Of Integer)()
		Dim nextPump As Integer = 0, prevPump As Integer
		Dim count As Integer = 0
		Dim petrol As Integer = 0

		Do While que.Count <> n
			Do While petrol >= 0 AndAlso que.Count <> n
				que.Enqueue(nextPump)
				petrol += (arr(nextPump, 0) - arr(nextPump, 1))
				nextPump = (nextPump + 1) Mod n
			Loop
			Do While petrol < 0 AndAlso que.Count > 0
				prevPump = que.Dequeue()
				petrol -= (arr(prevPump, 0) - arr(prevPump, 1))
			Loop
			count += 1
			If count = n Then
				Return -1
			End If
		Loop
		If petrol >= 0 Then
			Return que.Dequeue()
		Else
			Return -1
		End If
	End Function

	Public Shared Sub Main1(ByVal args() As String)
		' Testing code
		Dim tour(,) As Integer = {
			{8, 6},
			{1, 4},
			{7, 6}
		}
		Console.WriteLine(" Circular Tour : " & CircularTour(tour, 3))
	End Sub

	Public Shared Function convertXY(ByVal src As Integer, ByVal dst As Integer) As Integer
		Dim que As New Queue(Of Integer)()
		Dim arr(99) As Integer
		Dim steps As Integer = 0
		Dim index As Integer = 0
		Dim value As Integer

		que.Enqueue(src)
		Do While que.Count <> 0
			value = que.Dequeue()
			arr(index) = value
			index += 1

			If value = dst Then
				For i As Integer = 0 To index - 1
					Console.Write(arr(i))
				Next i
				Console.Write("Steps countr :: " & steps)
				Return steps
			End If
			steps += 1
			If value < dst Then
				que.Enqueue(value * 2)
			Else
				que.Enqueue(value - 1)
			End If
		Loop
		Return -1
	End Function

	Public Shared Sub Main2(ByVal args() As String)
		convertXY(2, 7)
	End Sub

	Public Shared Sub maxSlidingWindows(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
		Dim que As New LinkedList(Of Integer)()
		For i As Integer = 0 To size - 1
			' Remove out of range elements
			If que.Count > 0 AndAlso que.First.Value <= i - k Then
				que.RemoveFirst()
			End If
			' Remove smaller values at left.
			Do While que.Count > 0 AndAlso arr(que.Last.Value) <= arr(i)
				que.RemoveLast()
			Loop

			que.AddLast(i)
			' Largest value in window of size k is at index que[0]
			' It is displayed to the screen.
			If i >= (k - 1) Then
				Console.WriteLine(arr(que.First.Value))
			End If
		Next i
	End Sub

	Public Shared Sub Main3(ByVal args() As String)
		Dim arr() As Integer = {11, 2, 75, 92, 59, 90, 55}
		Dim k As Integer = 3
		maxSlidingWindows(arr, 7, 3)
		' Output 75, 92, 92, 92, 90
	End Sub

	Public Shared Function minOfMaxSlidingWindows(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim que As New LinkedList(Of Integer)()
		Dim minVal As Integer = 999999
		For i As Integer = 0 To size - 1
			' Remove out of range elements
			If que.Count > 0 AndAlso que.First.Value <= i - k Then
				que.RemoveFirst()
			End If
			' Remove smaller values at left.
			Do While que.Count > 0 AndAlso arr(que.Last.Value) <= arr(i)
				que.RemoveLast()
			Loop
			que.AddLast(i)
			' window of size k
			If i >= (k - 1) AndAlso minVal > arr(que.First.Value) Then
				minVal = arr(que.First.Value)
			End If
		Next i
		Console.WriteLine("Min of max is :: " & minVal)
		Return minVal
	End Function

	Public Shared Sub Main4(ByVal args() As String)
		Dim arr() As Integer = {11, 2, 75, 92, 59, 90, 55}
		minOfMaxSlidingWindows(arr, 7, 3)
		' Output 75
	End Sub

	Public Shared Sub maxOfMinSlidingWindows(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
		Dim que As New LinkedList(Of Integer)()
		Dim maxVal As Integer = -999999
		For i As Integer = 0 To size - 1
			' Remove out of range elements
			If que.Count > 0 AndAlso que.First.Value <= i - k Then
				que.RemoveFirst()
			End If
			' Remove smaller values at left.
			Do While que.Count > 0 AndAlso arr(que.Last.Value) >= arr(i)
				que.RemoveLast()
			Loop
			que.AddLast(i)
			' window of size k
			If i >= (k - 1) AndAlso maxVal < arr(que.First.Value) Then
				maxVal = arr(que.First.Value)
			End If
		Next i
		Console.WriteLine("Max of min is :: " & maxVal)
	End Sub

	Public Shared Sub Main5(ByVal args() As String)
		Dim arr() As Integer = {11, 2, 75, 92, 59, 90, 55}
		Dim k As Integer = 3
		maxOfMinSlidingWindows(arr, 7, 3)
		' Output 59, as minimum values in sliding windows are [2, 2, 59, 59, 55]
	End Sub

	Public Shared Sub firstNegSlidingWindows(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
		Dim que As New Queue(Of Integer)()

		For i As Integer = 0 To size - 1
			' Remove out of range elements
			If que.Count > 0 AndAlso que.Peek() <= i - k Then
				que.Dequeue()
			End If
			If arr(i) < 0 Then
				que.Enqueue(i)
			End If
			' window of size k
			If i >= (k - 1) Then
				If que.Count > 0 Then
					Console.Write(arr(que.Peek()))
				Else
					Console.Write("NAN")
				End If
			End If
		Next i
	End Sub

	Public Shared Sub Main6(ByVal args() As String)
		Dim arr() As Integer = {3, -2, -6, 10, -14, 50, 14, 21}
		Dim k As Integer = 3
		firstNegSlidingWindows(arr, 8, 3)
		' Output [-2, -2, -6, -14, -14, NAN]
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Main1(args)
		Main2(args)
		Main3(args)
		Main4(args)
		Main5(args)
		Main6(args)
	End Sub
End Class
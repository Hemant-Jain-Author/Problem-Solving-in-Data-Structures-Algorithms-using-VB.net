
Imports System
Imports System.Collections.Generic

Public Class QueueEx
	Public Shared Function CircularTour(ByVal arr(,) As Integer, ByVal n As Integer) As Integer
		For i As Integer = 0 To n - 1
			Dim total As Integer = 0
			Dim found As Boolean = True
			For j As Integer = 0 To n - 1
				total += (arr((i + j) Mod n, 0) - arr((i + j) Mod n, 1))
				If total < 0 Then
					found = False
					Exit For
				End If
			Next j
			If found Then
				Return i
			End If
		Next i
		Return -1
	End Function

	Public Shared Function CircularTour2(ByVal arr(,) As Integer, ByVal n As Integer) As Integer
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

	' Testing code
	Public Shared Sub Main1()
		Dim tour(,) As Integer = {
			{8, 6},
			{1, 4},
			{7, 6}
		}
		Console.WriteLine("Circular Tour : " & CircularTour(tour, 3))
		Console.WriteLine("Circular Tour : " & CircularTour2(tour, 3))
	End Sub
'	
'Circular Tour : 2
'Circular Tour : 2
'	
	Public Shared Function ConvertXY(ByVal src As Integer, ByVal dst As Integer) As Integer
		Dim que As New Queue(Of Integer)()
		Dim arr(99) As Integer
		Dim Steps As Integer = 0
		Dim index As Integer = 0
		Dim value As Integer

		que.Enqueue(src)
		Do While que.Count <> 0
			value = que.Dequeue()

			arr(index) = value
			index += 1

			If value = dst Then
				Return Steps
			End If
			Steps += 1
			If value < dst Then
				que.Enqueue(value * 2)
			Else
				que.Enqueue(value - 1)
			End If
		Loop
		Return -1
	End Function

	Public Shared Sub Main2()
		Console.WriteLine("Steps counter :: " & ConvertXY(2, 7))
	End Sub
'	
'	Steps counter :: 3
'	

	Public Shared Sub MaxSlidingWindows(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
		Dim i As Integer = 0
		Do While i < size - k + 1
			Dim max As Integer = arr(i)
			For j As Integer = 1 To k - 1
				max = Math.Max(max, arr(i + j))
			Next j
			Console.Write(max & " ")
			i += 1
		Loop
		Console.WriteLine()
	End Sub

	Public Shared Sub MaxSlidingWindows2(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
		Dim dque As New LinkedList(Of Integer)()
		For i As Integer = 0 To size - 1
			' Remove out of range elements
			If dque.Count > 0 AndAlso dque.First.Value <= i - k Then
				dque.RemoveFirst()
			End If
			' Remove smaller values at left.
			Do While dque.Count > 0 AndAlso arr(dque.Last.Value) <= arr(i)
				dque.RemoveLast()
			Loop

			dque.AddLast(i)
			' Largest value in window of size k is at index que[0]
			' It is displayed to the screen.
			If i >= (k - 1) Then
				Console.Write(arr(dque.First.Value) & " ")
			End If
		Next i
	End Sub

	Public Shared Sub Main3()
		Dim arr() As Integer = {11, 2, 75, 92, 59, 90, 55}
		MaxSlidingWindows(arr, 7, 3)
		MaxSlidingWindows2(arr, 7, 3)

	End Sub

'	
'	75 92 92 92 90 
'	

	Public Shared Function MinOfMaxSlidingWindows(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer) As Integer
		Dim dque As New LinkedList(Of Integer)()
		Dim minVal As Integer = 999999
		For i As Integer = 0 To size - 1
			' Remove out of range elements
			If dque.Count > 0 AndAlso dque.First.Value <= i - k Then
				dque.RemoveFirst()
			End If
			' Remove smaller values at left.
			Do While dque.Count > 0 AndAlso arr(dque.Last.Value) <= arr(i)
				dque.RemoveLast()
			Loop
			dque.AddLast(i)
			' window of size k
			If i >= (k - 1) AndAlso minVal > arr(dque.First.Value) Then
				minVal = arr(dque.First.Value)
			End If
		Next i
		Console.WriteLine("Min of max is :: " & minVal)
		Return minVal
	End Function

	Public Shared Sub Main4()
		Dim arr() As Integer = {11, 2, 75, 92, 59, 90, 55}
		MinOfMaxSlidingWindows(arr, 7, 3)
	End Sub
'	
'	Min of max is :: 75
'	
	Public Shared Sub MaxOfMinSlidingWindows(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
		Dim dque As New LinkedList(Of Integer)()
		Dim maxVal As Integer = -999999
		For i As Integer = 0 To size - 1
			' Remove out of range elements
			If dque.Count > 0 AndAlso dque.First.Value <= i - k Then
				dque.RemoveFirst()
			End If
			' Remove smaller values at left.
			Do While dque.Count > 0 AndAlso arr(dque.Last.Value) >= arr(i)
				dque.RemoveLast()
			Loop
			dque.AddLast(i)
			' window of size k
			If i >= (k - 1) AndAlso maxVal < arr(dque.First.Value) Then
				maxVal = arr(dque.First.Value)
			End If
		Next i
		Console.WriteLine("Max of min is :: " & maxVal)
	End Sub

	Public Shared Sub Main5()
		Dim arr() As Integer = {11, 2, 75, 92, 59, 90, 55}
		MaxOfMinSlidingWindows(arr, 7, 3)
		' Output 59, as minimum values in sliding windows are [2, 2, 59, 59, 55]
	End Sub
'	
'	Max of min is :: 59
'	
	Public Shared Sub FirstNegSlidingWindows(ByVal arr() As Integer, ByVal size As Integer, ByVal k As Integer)
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
					Console.Write(arr(que.Peek()) & " ")
				Else
					Console.Write("NAN")
				End If
			End If
		Next i
	End Sub

	Public Shared Sub Main6()
		Dim arr() As Integer = {3, -2, -6, 10, -14, 50, 14, 21}
		FirstNegSlidingWindows(arr, 8, 3)
	End Sub

'	
'	-2 -2 -6 -14 -14 NAN
'	

	Private Shared Sub RottenFruitUtil(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer, ByVal currCol As Integer, ByVal currRow As Integer, ByVal traversed(,) As Integer, ByVal day As Integer)
		Dim dir(,) As Integer = {
			{-1, 0},
			{1, 0},
			{0, -1},
			{0, 1}
		}
		Dim x, y As Integer
		For i As Integer = 0 To 3
			x = currCol + dir(i, 0)
			y = currRow + dir(i, 1)
			If x >= 0 AndAlso x < maxCol AndAlso y >= 0 AndAlso y < maxRow AndAlso traversed(x, y) > day + 1 AndAlso arr(x, y) = 1 Then
				traversed(x, y) = day + 1
				RottenFruitUtil(arr, maxCol, maxRow, x, y, traversed, day + 1)
			End If
		Next i
	End Sub

	Public Shared Function RottenFruit(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer) As Integer
		Dim traversed(maxCol - 1, maxRow - 1) As Integer
		For i As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				traversed(i, j) = Integer.MaxValue
			Next j
		Next i

		Dim i As Integer = 0
		Do While i < maxCol
			Dim j As Integer = 0
			Do While j < maxRow
				If arr(i, j) = 2 Then
					traversed(i, j) = 0
					RottenFruitUtil(arr, maxCol, maxRow, i, j, traversed, 0)
				End If
				j += 1
			Loop
			i += 1
		Loop

		Dim maxDay As Integer = 0
		For i As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				If arr(i, j) = 1 Then
					If traversed(i, j) = Integer.MaxValue Then
						Return -1
					End If
					If maxDay < traversed(i, j) Then
						maxDay = traversed(i, j)
					End If
				End If
			Next j
		Next i
		Return maxDay
	End Function

	Private Class Fruit
		Friend x, y As Integer
		Friend day As Integer
		Friend Sub New(ByVal a As Integer, ByVal b As Integer, ByVal d As Integer)
			x = a
			y = b
			day = d
		End Sub
	End Class

	Public Shared Function RottenFruit2(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer) As Integer
		Dim traversed(maxCol - 1, maxRow - 1) As Boolean
		Dim dir(,) As Integer = {
			{-1, 0},
			{1, 0},
			{0, -1},
			{0, 1}
		}
		Dim que As New Queue(Of Fruit)()

		For i As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				traversed(i, j) = False
				If arr(i, j) = 2 Then
					que.Enqueue(New Fruit(i, j, 0))
					traversed(i, j) = True
				End If
			Next j
		Next i
		Dim max As Integer = 0, x As Integer, y As Integer, day As Integer
		Dim temp As Fruit
		Do While que.Count > 0
			temp = que.Peek()
			que.Dequeue()
			For i As Integer = 0 To 3
				x = temp.x + dir(i, 0)
				y = temp.y + dir(i, 1)
				day = temp.day + 1
				If x >= 0 AndAlso x < maxCol AndAlso y >= 0 AndAlso y < maxRow AndAlso arr(x, y) <> 0 AndAlso traversed(x, y) = False Then
					que.Enqueue(New Fruit(x, y, day))
					max = Math.Max(max, day)
					traversed(x, y) = True
				End If
			Next i
		Loop
		For i As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				If arr(i, j) = 1 AndAlso traversed(i, j) = False Then
					Return -1
				End If
			Next j
		Next i
		Return max
	End Function

	Public Shared Sub Main7()
		Dim arr(,) As Integer = {
			{1, 0, 1, 1, 0},
			{2, 1, 0, 1, 0},
			{0, 0, 0, 2, 1},
			{0, 2, 0, 0, 1},
			{1, 1, 0, 0, 1}
		}
		Console.WriteLine(RottenFruit(arr, 5, 5))
		Console.WriteLine(RottenFruit2(arr, 5, 5))
	End Sub

	' 3
	' 3

	Private Shared Sub StepsOfKnightUtil(ByVal size As Integer, ByVal currCol As Integer, ByVal currRow As Integer, ByVal traversed(,) As Integer, ByVal dist As Integer)
		Dim dir(,) As Integer = {
			{-2, -1},
			{-2, 1},
			{2, -1},
			{2, 1},
			{-1, -2},
			{1, -2},
			{-1, 2},
			{1, 2}
		}
		Dim x, y As Integer
		For i As Integer = 0 To 7
			x = currCol + dir(i, 0)
			y = currRow + dir(i, 1)
			If x >= 0 AndAlso x < size AndAlso y >= 0 AndAlso y < size AndAlso traversed(x, y) > dist + 1 Then
				traversed(x, y) = dist + 1
				StepsOfKnightUtil(size, x, y, traversed, dist + 1)
			End If
		Next i
	End Sub

	Public Shared Function StepsOfKnight(ByVal size As Integer, ByVal srcX As Integer, ByVal srcY As Integer, ByVal dstX As Integer, ByVal dstY As Integer) As Integer
		Dim traversed(size - 1, size - 1) As Integer
		For i As Integer = 0 To size - 1
			For j As Integer = 0 To size - 1
				traversed(i, j) = Integer.MaxValue
			Next j
		Next i
		traversed(srcX - 1, srcY - 1) = 0
		StepsOfKnightUtil(size, srcX - 1, srcY - 1, traversed, 0)
		Return traversed(dstX - 1, dstY - 1)
	End Function


	Private Class Knight
		Friend x, y As Integer
		Friend cost As Integer
		Friend Sub New(ByVal a As Integer, ByVal b As Integer, ByVal c As Integer)
			x = a
			y = b
			cost = c
		End Sub
	End Class

	Public Shared Function StepsOfKnight2(ByVal size As Integer, ByVal srcX As Integer, ByVal srcY As Integer, ByVal dstX As Integer, ByVal dstY As Integer) As Integer
		Dim traversed(size - 1, size - 1) As Integer
		Dim dir(,) As Integer = {
			{-2, -1},
			{-2, 1},
			{2, -1},
			{2, 1},
			{-1, -2},
			{1, -2},
			{-1, 2},
			{1, 2}
		}
		Dim que As New Queue(Of Knight)()

		For i As Integer = 0 To size - 1
			For j As Integer = 0 To size - 1
				traversed(i, j) = Integer.MaxValue
			Next j
		Next i
		que.Enqueue(New Knight(srcX - 1,srcY - 1, 0))
		traversed(srcX - 1, srcY - 1) = 0

		Dim x, y, cost As Integer
		Dim temp As Knight
		Do While que.Count > 0
			temp = que.Peek()
			que.Dequeue()
			For i As Integer = 0 To 7
				x = temp.x + dir(i, 0)
				y = temp.y + dir(i, 1)
				cost = temp.cost + 1
				If x >= 0 AndAlso x < size AndAlso y >= 0 AndAlso y < size AndAlso traversed(x, y) > cost Then
					que.Enqueue(New Knight(x, y, cost))
					traversed(x, y) = cost
				End If
			Next i
		Loop
		Return traversed(dstX - 1, dstY - 1)
	End Function

	Public Shared Sub Main8()
		Console.WriteLine(StepsOfKnight(20, 10, 10, 20, 20))
		Console.WriteLine(StepsOfKnight2(20, 10, 10, 20, 20))
	End Sub

	' 8
	' 8

	Private Shared Sub DistNearestFillUtil(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer, ByVal currCol As Integer, ByVal currRow As Integer, ByVal traversed(,) As Integer, ByVal dist As Integer) ' Range check
		Dim x, y As Integer
		Dim dir(,) As Integer = {
			{-1, 0},
			{1, 0},
			{0, -1},
			{0, 1}
		}
		For i As Integer = 0 To 3
			x = currCol + dir(i, 0)
			y = currRow + dir(i, 1)
			If x >= 0 AndAlso x < maxCol AndAlso y >= 0 AndAlso y < maxRow AndAlso traversed(x, y) > dist + 1 Then
				traversed(x, y) = dist + 1
				DistNearestFillUtil(arr, maxCol, maxRow, x, y, traversed, dist + 1)
			End If
		Next i
	End Sub

	Public Shared Sub DistNearestFill(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer)
		Dim traversed(maxCol - 1, maxRow - 1) As Integer
		For i As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				traversed(i, j) = Integer.MaxValue
			Next j
		Next i

		Dim i As Integer = 0
		Do While i < maxCol
			Dim j As Integer = 0
			Do While j < maxRow
				If arr(i, j) = 1 Then
					traversed(i, j) = 0
					DistNearestFillUtil(arr, maxCol, maxRow, i, j, traversed, 0)
				End If
				j += 1
			Loop
			i += 1
		Loop

		For i As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				Console.Write(traversed(i, j) & " ")
			Next j
			Console.WriteLine()
		Next i
	End Sub

	Private Class Node
		Friend x, y As Integer
		Friend dist As Integer
		Friend Sub New(ByVal a As Integer, ByVal b As Integer, ByVal d As Integer)
			x = a
			y = b
			dist = d
		End Sub
	End Class

	Public Shared Sub DistNearestFill2(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer)
		Dim traversed(maxCol - 1, maxRow - 1) As Integer
		Dim dir(,) As Integer = {
			{-1, 0},
			{1, 0},
			{0, -1},
			{0, 1}
		}
		Dim que As New Queue(Of Node)()

		For i As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				traversed(i, j) = Integer.MaxValue
				If arr(i, j) = 1 Then
					que.Enqueue(New Node(i,j, 0))
					traversed(i, j) = 0
				End If
			Next j
		Next i
		Dim x, y, dist As Integer
		Dim temp As Node
		Do While que.Count > 0
			temp = que.Peek()
			que.Dequeue()
			For i As Integer = 0 To 3
				x = temp.x + dir(i, 0)
				y = temp.y + dir(i, 1)
				dist = temp.dist + 1
				If x >= 0 AndAlso x < maxCol AndAlso y >= 0 AndAlso y < maxRow AndAlso traversed(x, y) > dist Then
					que.Enqueue(New Node(x, y, dist))
					traversed(x, y) = dist
				End If
			Next i
		Loop
		For i As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				Console.Write(traversed(i, j) & " ")
			Next j
			Console.WriteLine()
		Next i
	End Sub

	Public Shared Sub Main9()
		Dim arr(,) As Integer = {
			{1, 0, 1, 1, 0},
			{1, 1, 0, 1, 0},
			{0, 0, 0, 0, 1},
			{0, 0, 0, 0, 1},
			{0, 0, 0, 0, 1}
		}
		DistNearestFill(arr, 5, 5)
		DistNearestFill2(arr, 5, 5)
	End Sub

'	
'	0 1 0 0 1 
'	0 0 1 0 1 
'	1 1 2 1 0 
'	2 2 2 1 0 
'	3 3 2 1 0 
'
'	0 1 0 0 1 
'	0 0 1 0 1 
'	1 1 2 1 0 	
'	2 2 2 1 0 
'	3 3 2 1 0 
'	

	Private Shared Function FindLargestIslandUtil(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer, ByVal currCol As Integer, ByVal currRow As Integer, ByVal traversed(,) As Boolean) As Integer
		Dim dir(,) As Integer = {
			{-1, -1},
			{-1, 0},
			{-1, 1},
			{0, -1},
			{0, 1},
			{1, -1},
			{1, 0},
			{1, 1}
		}
		Dim x As Integer, y As Integer, sum As Integer = 1
		For i As Integer = 0 To 7
			x = currCol + dir(i, 0)
			y = currRow + dir(i, 1)
			If x >= 0 AndAlso x < maxCol AndAlso y >= 0 AndAlso y < maxRow AndAlso traversed(x, y) = False AndAlso arr(x, y) = 1 Then
				traversed(x, y) = True
				sum += FindLargestIslandUtil(arr, maxCol, maxRow, x, y, traversed)
			End If
		Next i
		Return sum
	End Function


	Public Shared Function FindLargestIsland(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer) As Integer
		Dim maxVal As Integer = 0
		Dim currVal As Integer = 0
		Dim traversed(maxCol - 1, maxRow - 1) As Boolean
		For i As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				traversed(i, j) = False
			Next j
		Next i

		Dim i As Integer = 0
		Do While i < maxCol
			Dim j As Integer = 0
			Do While j < maxRow
				If arr(i, j) = 1 Then
					traversed(i, j) = True
					currVal = FindLargestIslandUtil(arr, maxCol, maxRow, i, j, traversed)
					If currVal > maxVal Then
						maxVal = currVal
					End If
				End If
				j += 1
			Loop
			i += 1
		Loop

		Return maxVal
	End Function

	Public Shared Sub Main10()
		Dim arr(,) As Integer = {
			{1, 0, 1, 1, 0},
			{1, 0, 0, 1, 0},
			{0, 1, 1, 1, 1},
			{0, 1, 0, 0, 0},
			{1, 1, 0, 0, 1}
		}
		Console.WriteLine("Largest Island : " & FindLargestIsland(arr, 5, 5))
	End Sub

	' Largest Island : 12

	Public Shared Sub ReverseStack(ByVal stk As Stack(Of Integer))
		Dim que As New Queue(Of Integer)()
		Do While stk.Count > 0
			que.Enqueue(stk.Peek())
			stk.Pop()
		Loop
		Do While que.Count > 0
			stk.Push(que.Peek())
			que.Dequeue()
		Loop
	End Sub

	Public Shared Sub ReverseQueue(ByVal que As Queue(Of Integer))
		Dim stk As New Stack(Of Integer)()
		Do While que.Count > 0
			stk.Push(que.Peek())
			que.Dequeue()
		Loop
		Do While stk.Count > 0
			que.Enqueue(stk.Peek())
			stk.Pop()
		Loop
	End Sub
	Public Shared Sub Main11()
		Dim stk As New Stack(Of Integer)()
		For i As Integer = 0 To 4
			stk.Push(i)
		Next i
		For Each ele In stk
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()
		ReverseStack(stk)
		For Each ele In stk
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()

		Dim que As New Queue(Of Integer)()
		For i As Integer = 0 To 4
			que.Enqueue(i)
		Next i
		For Each ele In que
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()
		ReverseQueue(que)
		For Each ele In que
			Console.Write(ele & " ")
		Next ele
		Console.WriteLine()
	End Sub

'	
'4 3 2 1 0 
'0 1 2 3 4 
'0 1 2 3 4 
'4 3 2 1 0 
'	
	Public Shared Function Josephus(ByVal n As Integer, ByVal k As Integer) As Integer
		Dim que As New Queue(Of Integer)()
		For i As Integer = 0 To n - 1
			que.Enqueue(i + 1)
		Next i

		Do While que.Count > 1
			Dim i As Integer = 0
			Do While i < k - 1
				que.Enqueue(que.Peek())
				que.Dequeue()
				i += 1
			Loop
			que.Dequeue() ' Kth person executed.
		Loop
		Return que.Peek()
	End Function



	Public Shared Sub Main12()
		Console.WriteLine("Position : " & Josephus(11, 5))
	End Sub
'
'Position : 8
'
	Public Shared Sub Main(ByVal args() As String)
		Main1()
		Main2()
		Main3()
		Main4()
		Main5()
		Main6()
		Main7()
		Main8()
		Main9()
		Main10()
		Main11()
		Main12()
	End Sub
End Class

Imports System

Public Module OptimalBST
	Function OptCost(ByVal freq() As Integer, ByVal i As Integer, ByVal j As Integer) As Integer
		If i > j Then
			Return 0
		End If

		If j = i Then ' one element in this subarray
			Return freq(i)
		End If

		Dim min As Integer = Integer.MaxValue
		Dim r As Integer = i
		While r <= j
			min = Math.Min(min, OptCost(freq, i, r - 1) + OptCost(freq, r + 1, j))
			r += 1
		End While
		Return min + sum(freq, i, j)
	End Function

	Function OptCost(ByVal keys() As Integer, ByVal freq() As Integer) As Integer
		Dim n As Integer = freq.Length
		Return OptCost(freq, 0, n - 1)
	End Function

	Function OptCostTD(ByVal keys() As Integer, ByVal freq() As Integer) As Integer
		Dim n As Integer = freq.Length
		Dim cost(n - 1, n - 1) As Integer
		For i As Integer = 0 To n - 1
			For j As Integer = 0 To n - 1
				cost(i, j) = Integer.MaxValue
			Next j
		Next i

		For i As Integer = 0 To n - 1
			cost(i, i) = freq(i)
		Next i

		Return OptCostTD(freq, cost, 0, n - 1)
	End Function

	Function OptCostTD(ByVal freq() As Integer, ByVal cost(,) As Integer, ByVal i As Integer, ByVal j As Integer) As Integer
		If i > j Then
			Return 0
		End If

		If cost(i, j) <> Integer.MaxValue Then
			Return cost(i, j)
		End If

		Dim s As Integer = sum(freq, i, j)
		For r As Integer = i To j
			cost(i, j) = Math.Min(cost(i, j), OptCostTD(freq, cost, i, r - 1) + OptCostTD(freq, cost, r + 1, j) + s)
		Next r
		Return cost(i, j)
	End Function

	Function sum(ByVal freq() As Integer, ByVal i As Integer, ByVal j As Integer) As Integer
		Dim s As Integer = 0
		For k As Integer = i To j
			s += freq(k)
		Next k
		Return s
	End Function

	Function SumInit(ByVal freq() As Integer, ByVal n As Integer) As Integer()
		Dim sum(n - 1) As Integer
		sum(0) = freq(0)
		For i As Integer = 1 To n - 1
			sum(i) = sum(i - 1) + freq(i)
		Next i
		Return sum
	End Function

	Function SumRange(ByVal sum() As Integer, ByVal i As Integer, ByVal j As Integer) As Integer
		If i = 0 Then
			Return sum(j)
		End If
		Return sum(j) - sum(i - 1)
	End Function

	Function OptCostBU(ByVal keys() As Integer, ByVal freq() As Integer) As Integer
		Dim n As Integer = freq.Length
		Dim cost(n - 1, n - 1) As Integer

		For i As Integer = 0 To n - 1
			For j As Integer = 0 To n - 1
				cost(i, j) = Integer.MaxValue
			Next j
		Next i

		For i As Integer = 0 To n - 1
			cost(i, i) = freq(i)
		Next i

		Dim sm As Integer = 0
		For l As Integer = 1 To n - 1 ' l is length of range.
			Dim i As Integer = 0
			Dim j As Integer = i + l
			While j < n
				sm = sum(freq, i, j)
				For r As Integer = i To j
					cost(i, j) = Math.Min(cost(i, j), sm + (If(r - 1 >= i, cost(i, r - 1), 0)) + (If(r + 1 <= j, cost(r + 1, j), 0)))
				Next r
				i += 1
				j += 1
			End While
		Next l
		Return cost(0, n - 1)
	End Function

	Function OptCostBU2(ByVal keys() As Integer, ByVal freq() As Integer) As Integer
		Dim n As Integer = freq.Length
		Dim cost(n - 1, n - 1) As Integer
		For i As Integer = 0 To n - 1
			For j As Integer = 0 To n - 1
				cost(i, j) = Integer.MaxValue
			Next j
		Next i

		Dim sumArr() As Integer = SumInit(freq, n)
		For i As Integer = 0 To n - 1
			cost(i, i) = freq(i)
		Next i

		Dim sm As Integer = 0
		For l As Integer = 1 To n - 1 ' l is length of range.
			Dim i As Integer = 0
			Dim j As Integer = i + l
			While j < n
				sm = SumRange(sumArr, i, j)
				For r As Integer = i To j
					cost(i, j) = Math.Min(cost(i, j), sm + (If(r - 1 >= i, cost(i, r - 1), 0)) + (If(r + 1 <= j, cost(r + 1, j), 0)))
				Next r
				i += 1
				j += 1
			End While
		Next l
		Return cost(0, n - 1)
	End Function

	Sub Main(ByVal args() As String)
		Dim keys() As Integer = {9, 15, 25}
		Dim freq() As Integer = {30, 10, 40}
		Console.WriteLine("OBST cost:" & OptCost(keys, freq))
		Console.WriteLine("OBST cost:" & OptCostTD(keys, freq))
		Console.WriteLine("OBST cost:" & OptCostBU(keys, freq))
		Console.WriteLine("OBST cost:" & OptCostBU2(keys, freq))
	End Sub
End Module

'
'OBST cost:130
'OBST cost:130
'OBST cost:130
'OBST cost:130
'
Imports System

Public Class NutsAndBolts
	Private Shared Sub PrintArray(ByVal arr() As Integer)
		For Each i As Integer In arr
			Console.Write(i & " ")
		Next i
		Console.WriteLine()
	End Sub

	Public Shared Sub MakePairs(ByVal nuts() As Integer, ByVal bolts() As Integer)
		MakePairs(nuts, bolts, 0, nuts.Length - 1)
		Console.WriteLine("Matched nuts and bolts are : ")
		PrintArray(nuts)
		PrintArray(bolts)
	End Sub

	' Quick sort kind of approach.
	Private Shared Sub MakePairs(ByVal nuts() As Integer, ByVal bolts() As Integer, ByVal low As Integer, ByVal high As Integer)
		If low < high Then
			' Choose first element of bolts array as pivot to partition nuts.
			Dim pivot As Integer = Partition(nuts, low, high, bolts(low))

			' Using nuts[pivot] as pivot to partition bolts.
			Partition(bolts, low, high, nuts(pivot))

			' Recursively lower and upper half of nuts and bolts are matched.
			MakePairs(nuts, bolts, low, pivot - 1)
			MakePairs(nuts, bolts, pivot + 1, high)
		End If
	End Sub
	Private Shared Sub Swap(ByVal arr() As Integer, ByVal first As Integer, ByVal second As Integer)
		Dim temp As Integer = arr(first)
		arr(first) = arr(second)
		arr(second) = temp
	End Sub

	' Partition method similar to quick sort algorithm.
	Private Shared Function Partition(ByVal arr() As Integer, ByVal low As Integer, ByVal high As Integer, ByVal pivot As Integer) As Integer
		Dim i As Integer = low
		Dim j As Integer = low
		Do While j < high
			If arr(j) < pivot Then
				Swap(arr, i, j)
				i += 1
			ElseIf arr(j) = pivot Then
				Swap(arr, high, j)
				j -= 1
			End If
			j += 1
		Loop
		Swap(arr, i, high)
		Return i
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim nuts() As Integer = {1, 2, 6, 5, 4, 3}
		Dim bolts() As Integer = {6, 4, 5, 1, 3, 2}
		MakePairs(nuts, bolts)
	End Sub
End Class

'
'Matched nuts and bolts are : 
'1 2 3 4 5 6 
'1 2 3 4 5 6 
'
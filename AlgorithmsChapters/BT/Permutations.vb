Imports System

Public Class Permutations
	Private Shared Sub PrintArray(ByVal arr() As Integer, ByVal n As Integer)
		For i As Integer = 0 To n - 1
			Console.Write(arr(i) & " ")
		Next i
		Console.WriteLine()
	End Sub

	Private Shared Sub Swap(ByVal arr() As Integer, ByVal i As Integer, ByVal j As Integer)
		Dim temp As Integer = arr(i)
		arr(i) = arr(j)
		arr(j) = temp
	End Sub

	Public Shared Sub Permutation(ByVal arr() As Integer, ByVal i As Integer, ByVal length As Integer)
		If length = i Then
			PrintArray(arr, length)
			Return
		End If

		Dim j As Integer = i
		Do While j < length
			Swap(arr, i, j)
			Permutation(arr, i + 1, length)
			Swap(arr, i, j)
			j += 1
		Loop
		Return
	End Sub

'
'1 2 3 4 
'1 2 4 3 
'.....
'4 1 3 2 
'4 1 2 3 
'

	Private Shared Function IsValid(ByVal arr() As Integer, ByVal n As Integer) As Boolean
		For j As Integer = 1 To n - 1
			If Math.Abs(arr(j) - arr(j - 1)) < 2 Then
				Return False
			End If
		Next j
		Return True
	End Function

	Public Shared Sub Permutation2(ByVal arr() As Integer, ByVal i As Integer, ByVal length As Integer)
		If length = i Then
			If IsValid(arr, length) Then
				PrintArray(arr, length)
			End If
			Return
		End If

		Dim j As Integer = i
		Do While j < length
			Swap(arr, i, j)
			Permutation2(arr, i + 1, length)
			Swap(arr, i, j)
			j += 1
		Loop
		Return
	End Sub

	Private Shared Function IsValid2(ByVal arr() As Integer, ByVal i As Integer) As Boolean
		If i < 1 OrElse Math.Abs(arr(i) - arr(i - 1)) >= 2 Then
			Return True
		End If
		Return False
	End Function

	Public Shared Sub Permutation3(ByVal arr() As Integer, ByVal i As Integer, ByVal length As Integer)
		If length = i Then
			PrintArray(arr, length)
			Return
		End If

		Dim j As Integer = i
		Do While j < length
			Swap(arr, i, j)
			If IsValid2(arr, i) Then
				Permutation3(arr, i + 1, length)
			End If
			Swap(arr, i, j)
			j += 1
		Loop
		Return
	End Sub

	' Testing code 
	Public Shared Sub Main(ByVal args() As String)
		Dim arr(3) As Integer
		For i As Integer = 0 To 3
			arr(i) = i + 1
		Next i
		Permutation3(arr, 0, 4)
	End Sub
End Class

'
'2 4 1 3 
'3 1 4 2
'
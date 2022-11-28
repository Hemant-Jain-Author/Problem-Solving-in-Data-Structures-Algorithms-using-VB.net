Imports System

Public Class HuffmanTree
	Private root As Node = Nothing

	Friend Class Node
		Implements IComparable(Of Node)

		Friend c As Char
		Friend freq As Integer
		Friend left As Node
		Friend right As Node

		Friend Sub New(ByVal ch As Char, ByVal fr As Integer, ByVal l As Node, ByVal r As Node)
			c = ch
			freq = fr
			left = l
			right = r
		End Sub

		Private Function IComparable_CompareTo(other As Node) As Integer Implements IComparable(Of Node).CompareTo
			Return Me.freq - other.freq
		End Function
	End Class

	Public Sub New(ByVal arr() As Char, ByVal freq() As Integer)
		Dim n As Integer = arr.Length
		Dim hp As New Heap(Of Node)()

		For i As Integer = 0 To n - 1
			Dim node As New Node(arr(i), freq(i), Nothing, Nothing)
			hp.Enqueue(node)
		Next i

		Do While hp.Size() > 1
			Dim lt As Node = hp.Peek()
			hp.Dequeue()
			Dim rt As Node = hp.Peek()
			hp.Dequeue()

			Dim nd As New Node("+"c, lt.freq + rt.freq, lt, rt)
			hp.Enqueue(nd)
		Loop
		root = hp.Peek()
	End Sub

	Private Sub Print(ByVal root As Node, ByVal s As String)
		If root.left Is Nothing AndAlso root.right Is Nothing AndAlso root.c <> "+"c Then
			Console.WriteLine(root.c & " = " & s)
			Return
		End If
		Print(root.left, s & "0")
		Print(root.right, s & "1")
	End Sub

	Public Sub Print()
		Console.WriteLine("Char = Huffman code")
		Print(root, "")
	End Sub

	' Testing code.
	Public Shared Sub Main(ByVal args() As String)
		Dim ar() As Char = {"A"c, "B"c, "C"c, "D"c, "E"c}
		Dim fr() As Integer = {30, 25, 21, 14, 10}
		Dim hf As New HuffmanTree(ar, fr)
		hf.Print()
	End Sub
End Class

'
'Char = Huffman code
'C = 00
'E = 010
'D = 011
'B = 10
'A = 11
'



Public Class Heap(Of T As IComparable(Of T))
	Private Capacity As Integer = 100
	Private count As Integer ' Number of elements in Heap
	Private arr() As T ' The Heap array
	Private isMinHeap As Boolean

	Public Sub New(Optional ByVal isMin As Boolean = True)
		arr = New T(Capacity) {}
		count = 0
		isMinHeap = isMin
	End Sub

	Public Sub New(ByVal array() As T, Optional ByVal isMin As Boolean = True)
		Capacity = array.Length
		count = array.Length
		arr = array
		isMinHeap = isMin
		For i As Integer = (count \ 2) To 0 Step -1
			PercolateDown(i)
		Next i
	End Sub

	' Other Methods.
	Private Function Compare(ByVal arr() As T, ByVal first As Integer, ByVal second As Integer) As Boolean
		If isMinHeap Then
			Return arr(first).CompareTo(arr(second)) > 0
		Else
			Return arr(first).CompareTo(arr(second)) < 0
		End If
	End Function

	Private Sub PercolateDown(ByVal parent As Integer)
		Dim lChild As Integer = 2 * parent + 1
		Dim rChild As Integer = lChild + 1
		Dim child As Integer = -1
		Dim temp As T

		If lChild < count Then
			child = lChild
		End If

		If rChild < count AndAlso Compare(arr, lChild, rChild) Then
			child = rChild
		End If

		If child <> -1 AndAlso Compare(arr, parent, child) Then
			temp = arr(parent)
			arr(parent) = arr(child)
			arr(child) = temp
			PercolateDown(child)
		End If
	End Sub

	Private Sub PercolateUp(ByVal child As Integer)
		Dim parent As Integer = (child - 1) \ 2
		Dim temp As T
		If parent < 0 Then
			Return
		End If

		If Compare(arr, parent, child) Then
			temp = arr(child)
			arr(child) = arr(parent)
			arr(parent) = temp
			PercolateUp(parent)
		End If
	End Sub

	Public Sub Enqueue(ByVal value As T)
		If count = Capacity Then
			DoubleSize()
		End If

		arr(count) = value
		count += 1
		PercolateUp(count - 1)
	End Sub

	Private Sub DoubleSize()
		Dim old() As T = arr
		arr = New T(Capacity * 2) {}
		Capacity = Capacity * 2
		For i As Integer = 0 To count - 1
			arr(i) = old(i)
		Next i
	End Sub

	Public Function Dequeue() As T
		If count = 0 Then
			Throw New System.InvalidOperationException()
		End If

		Dim value As T = arr(0)
		arr(0) = arr(count - 1)
		count -= 1
		PercolateDown(0)
		Return value
	End Function

	Public Sub Print()
		For i As Integer = 0 To count - 1
			Console.Write(arr(i))
			Console.Write(" ")
		Next i
		Console.WriteLine()
	End Sub

	Public Function IsEmpty() As Boolean
		Return (count = 0)
	End Function

	Public Function Size() As Integer
		Return count
	End Function

	Public Function Peek() As T
		If count = 0 Then
			Throw New System.InvalidOperationException()
		End If
		Return arr(0)
	End Function

	Friend Shared Sub HeapSort(ByVal array() As Integer, ByVal inc As Boolean)
		' Create max heap for increasing order sorting.
		Dim hp As New Heap(Of Integer)(array, Not inc)
		For i As Integer = 0 To array.Length - 1
			array(array.Length - i - 1) = hp.Dequeue()
		Next i
	End Sub
End Class

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

		Public Function CompareTo(ByVal n2 As Node) As Integer
			Return Me.freq - n2.freq
		End Function
	End Class

	Public Sub New(ByVal arr() As Char, ByVal freq() As Integer)
		Dim n As Integer = arr.Length
		Dim que As New PriorityQueue(Of Node)()

		For i As Integer = 0 To n - 1
			Dim node As New Node(arr(i), freq(i), Nothing, Nothing)
			que.Add(node)
		Next i

		Do While que.Size() > 1
			Dim lt As Node = que.Peek()
			que.Remove()
			Dim rt As Node = que.Peek()
			que.Remove()

			Dim nd As New Node("+"c, lt.freq + rt.freq, lt, rt)
			que.Add(nd)
		Loop
		root = que.Peek()
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
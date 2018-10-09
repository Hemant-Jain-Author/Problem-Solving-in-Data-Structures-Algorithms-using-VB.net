Imports System

Public Class TST
	Private root As Node

	Private Class Node
		Friend data As Char
		Friend isLastChar As Boolean
		Friend left, equal, right As Node

		Friend Sub New(ByVal d As Char)
			data = d
			isLastChar = False
			right = Nothing
			equal = Nothing
			left = Nothing
		End Sub
	End Class

	Public Overridable Sub insert(ByVal word As String)
		root = insert(root, word, 0)
	End Sub

	Private Function insert(ByVal curr As Node, ByVal word As String, ByVal wordIndex As Integer) As Node
		If curr Is Nothing Then
			curr = New Node(word.Chars(wordIndex))
		End If

		If word.Chars(wordIndex) < curr.data Then
			curr.left = insert(curr.left, word, wordIndex)
		ElseIf word.Chars(wordIndex) > curr.data Then
			curr.right = insert(curr.right, word, wordIndex)
		Else
			If wordIndex < word.Length - 1 Then
				curr.equal = insert(curr.equal, word, wordIndex + 1)
			Else
				curr.isLastChar = True
			End If
		End If
		Return curr
	End Function

	Private Function find(ByVal curr As Node, ByVal word As String, ByVal wordIndex As Integer) As Boolean
		If curr Is Nothing Then
			Return False
		End If

		If word.Chars(wordIndex) < curr.data Then
			Return find(curr.left, word, wordIndex)
		ElseIf word.Chars(wordIndex) > curr.data Then
			Return find(curr.right, word, wordIndex)
		Else
			If wordIndex = word.Length - 1 Then
				Return curr.isLastChar
			End If
			Return find(curr.equal, word, wordIndex + 1)
		End If
	End Function

	Public Overridable Function find(ByVal word As String) As Boolean
		Dim ret As Boolean = find(root, word, 0)
		Console.Write(word & " :: ")
		If ret Then
			Console.WriteLine(" Found ")
		Else
			Console.WriteLine("Not Found ")
		End If
		Return ret
	End Function

	Public Shared Sub Main(ByVal args() As String)

		Dim tt As New TST()
		tt.insert("banana")
		tt.insert("apple")
		tt.insert("mango")
		Console.WriteLine(ControlChars.Lf & "Search results for apple, banana, grapes and mango :")
		tt.find("apple")
		tt.find("banana")
		tt.find("mango")
		tt.find("grapes")
	End Sub
End Class
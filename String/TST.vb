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

	Public Sub Add(ByVal word As String)
		root = Add(root, word, 0)
	End Sub

	Private Function Add(ByVal curr As Node, ByVal word As String, ByVal wordIndex As Integer) As Node
		If curr Is Nothing Then
			curr = New Node(word.Chars(wordIndex))
		End If
		If word.Chars(wordIndex) < curr.data Then
			curr.left = Add(curr.left, word, wordIndex)
		ElseIf word.Chars(wordIndex) > curr.data Then
			curr.right = Add(curr.right, word, wordIndex)
		Else
			If wordIndex < word.Length - 1 Then
				curr.equal = Add(curr.equal, word, wordIndex + 1)
			Else
				curr.isLastChar = True
			End If
		End If
		Return curr
	End Function

	Private Function Find(ByVal curr As Node, ByVal word As String, ByVal wordIndex As Integer) As Boolean
		If curr Is Nothing Then
			Return False
		End If
		If word.Chars(wordIndex) < curr.data Then
			Return Find(curr.left, word, wordIndex)
		ElseIf word.Chars(wordIndex) > curr.data Then
			Return Find(curr.right, word, wordIndex)
		Else
			If wordIndex = word.Length - 1 Then
				Return curr.isLastChar
			End If
			Return Find(curr.equal, word, wordIndex + 1)
		End If
	End Function

	Public Function Find(ByVal word As String) As Boolean
		Dim ret As Boolean = Find(root, word, 0)
		Return ret
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim tt As New TST()
		tt.Add("banana")
		tt.Add("apple")
		tt.Add("mango")
		Console.WriteLine("Apple Found : " & tt.Find("apple"))
		Console.WriteLine("Banana Found : " & tt.Find("banana"))
		Console.WriteLine("Grapes Found : " & tt.Find("grapes"))
	End Sub
End Class
'
'Apple Found : True
'Banana Found : True
'Grapes Found : False
'
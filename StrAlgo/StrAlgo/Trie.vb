Imports System

Public Class Trie
	Private Const CharCount As Integer = 26
	Private root As Node = Nothing

	Private Class Node
		Friend isLastChar As Boolean
		Friend ch As Char
		Friend child() As Node

		Public Sub New(ByVal c As Char)
			child = New Node(CharCount - 1) {}
			For i As Integer = 0 To CharCount - 1
				child(i) = Nothing
			Next i
			isLastChar = False
			ch = c
		End Sub
	End Class

	Public Sub New()
		root = New Node(" "c) 'first node with dummy value.
	End Sub



	Public Sub Insert(ByVal str As String)
		If String.ReferenceEquals(str, Nothing) Then
			Return
		End If
		Insert(root, str.ToLower(), 0)
	End Sub

	Private Function Insert(ByVal curr As Node, ByVal str As String, ByVal index As Integer) As Node
		If curr Is Nothing Then
			curr = New Node(str.Chars(index - 1))
		End If

		If str.Length = index Then
			curr.isLastChar = True
		Else
			curr.child(AscW(str.Chars(index)) - AscW("a"c)) = Insert(curr.child(AscW(str.Chars(index)) - AscW("a"c)), str, index + 1)
		End If

		Return curr
	End Function

	Friend Sub Remove(ByVal str As String)
		If String.ReferenceEquals(str, Nothing) Then
			Return
		End If
		str = str.ToLower()
		Remove(root, str, 0)
	End Sub

	Private Sub Remove(ByVal curr As Node, ByVal str As String, ByVal index As Integer)
		If curr Is Nothing Then
			Return
		End If
		If str.Length = index Then
			If curr.isLastChar Then
				curr.isLastChar = False
			End If
			Return
		End If
		Remove(curr.child(AscW(str.Chars(index)) - AscW("a"c)), str, index + 1)
	End Sub


	Friend Function Find(ByVal str As String) As Boolean
		If String.ReferenceEquals(str, Nothing) Then
			Return False
		End If
		str = str.ToLower()
		Return Find(root, str, 0)
	End Function

	Private Function Find(ByVal curr As Node, ByVal str As String, ByVal index As Integer) As Boolean
		If curr Is Nothing Then
			Return False
		End If

		If str.Length = index Then
			Return curr.isLastChar
		End If

		Return Find(curr.child(AscW(str.Chars(index)) - AscW("a"c)), str, index + 1)
	End Function



	Public Shared Sub Main(ByVal args() As String)
		Dim t As New Trie()
		Dim a As String = "hemant"
		Dim b As String = "heman"
		t.Insert(a)
		t.Insert(b)
		Console.WriteLine(t.Find(a))
		Console.WriteLine(t.Find(b))
	End Sub
End Class

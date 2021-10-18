Imports System

Public Class Polynomial
	Public Class Node
		Friend coeff As Integer
		Friend pow As Integer
		Friend nextPtr As Node
		Friend Sub New(ByVal c As Integer, ByVal p As Integer)
			coeff = c
			pow = p
			nextPtr = Nothing
		End Sub
	End Class

	Public Shared Function add(ByVal p1 As Node, ByVal p2 As Node) As Node
		Dim head As Node = Nothing, tail As Node = Nothing, temp As Node = Nothing
		Do While p1 IsNot Nothing OrElse p2 IsNot Nothing
			If p1 Is Nothing OrElse p1.pow < p2.pow Then
				temp = New Node(p2.coeff, p2.pow)
				p2 = p2.nextPtr
			ElseIf p2 Is Nothing OrElse p1.pow > p2.pow Then
				temp = New Node(p1.coeff, p1.pow)
				p1 = p1.nextPtr
			ElseIf p1.pow = p2.pow Then
				temp = New Node(p1.coeff + p2.coeff, p1.pow)
				p1 = p1.nextPtr
				p2 = p2.nextPtr
			End If

			If head Is Nothing Then
				tail = temp
				head = tail
			Else
				tail.nextPtr = temp
				tail = tail.nextPtr
			End If
		Loop
		Return head
	End Function

	Public Shared Function create(ByVal coeffs() As Integer, ByVal pows() As Integer, ByVal size As Integer) As Node
		Dim head As Node = Nothing, tail As Node = Nothing, temp As Node = Nothing
		For i As Integer = 0 To size - 1
			temp = New Node(coeffs(i), pows(i))
			If head Is Nothing Then
				tail = temp
				head = tail
			Else
				tail.nextPtr = temp
				tail = tail.nextPtr
			End If
		Next i
		Return head
	End Function

	Public Shared Sub print(ByVal head As Node)
		Do While head IsNot Nothing
			Console.Write(head.coeff & "x^" & head.pow)
			If head.nextPtr IsNot Nothing Then
				Console.Write(" + ")
			End If
				head = head.nextPtr
		Loop
		Console.WriteLine()
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim c1() As Integer = {6, 5, 4}
		Dim p1() As Integer = {2, 1, 0}
		Dim s1 As Integer = c1.Length
		Dim first As Node = create(c1, p1, s1)
		print(first)

		Dim c2() As Integer = {3, 2, 1}
		Dim p2() As Integer = {3, 1, 0}
		Dim s2 As Integer = c2.Length
		Dim second As Node = create(c2, p2, s2)
		print(second)

		Dim sum As Node = add(first, second)
		print(sum)
	End Sub
End Class

'
'3x^3 + 6x^2 + 7x^1 + 5x^0
'
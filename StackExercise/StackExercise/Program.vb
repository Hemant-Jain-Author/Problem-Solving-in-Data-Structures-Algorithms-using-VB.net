Imports System
Imports System.Collections.Generic

Public Class StackExercise


	Public Shared Function isBalancedParenthesis(ByVal expn As String) As Boolean
		Dim stk As New Stack(Of Char)()
		For Each ch As Char In expn.ToCharArray()
			Select Case ch
				Case "{"c, "["c, "("c
					stk.Push(ch)
				Case "}"c
					If stk.Pop() <> "{"c Then
						Return False
					End If
				Case "]"c
					If stk.Pop() <> "["c Then
						Return False
					End If
				Case ")"c
					If stk.Pop() <> "("c Then
						Return False
					End If
			End Select
		Next ch
		Return stk.Count = 0
	End Function

	Public Shared Sub main2(ByVal args() As String)
		Dim expn As String = "{()}["
		Dim value As Boolean = isBalancedParenthesis(expn)
		Console.WriteLine("Given Expn:" & expn)
		Console.WriteLine("Result after isParenthesisMatched:" & value)
	End Sub

	Public Shared Sub insertAtBottom(Of T)(ByVal stk As Stack(Of T), ByVal value As T)
		If stk.Count = 0 Then
			stk.Push(value)
		Else
			Dim popvalue As T = stk.Pop()
			insertAtBottom(stk, value)
			stk.Push(popvalue)
		End If
	End Sub

	Public Shared Sub reverseStack(Of T)(ByVal stk As Stack(Of T))
		If stk.Count = 0 Then
			Return
		Else
			Dim value As T = stk.Pop()
			reverseStack(stk)
			insertAtBottom(stk, value)
		End If
	End Sub


	Public Shared Function postfixEvaluate(ByVal expn As String) As Integer
		Dim stk As New Stack(Of Integer)()
		Dim tokens() As String = expn.Split(" "c)

		For Each token As String In tokens
			If "+-*/".Contains(token) Then
				Dim num1 As Integer = stk.Pop()
				Dim num2 As Integer = stk.Pop()

				Select Case token
					Case "+"
						stk.Push(num1 + num2)
					Case "-"
						stk.Push(num1 - num2)
					Case "*"
						stk.Push(num1 * num2)
					Case "/"
						stk.Push(num1 \ num2)
				End Select
			Else
				stk.Push(Convert.ToInt32(token))
			End If

		Next token
		Return stk.Pop()
	End Function

	Public Shared Sub Main435436(ByVal args() As String)
		Dim expn As String = "6 5 2 3 + 8 * + 3 + *"
		Dim value As Integer = postfixEvaluate(expn)
		Console.WriteLine("Given Postfix Expn: " & expn)
		Console.WriteLine("Result after Evaluation: " & value)
	End Sub

	Public Shared Function precedence(ByVal x As Char) As Integer
		If x = "("c Then
			Return (0)
		End If
		If x = "+"c OrElse x = "-"c Then
			Return (1)
		End If
		If x = "*"c OrElse x = "/"c OrElse x = "%"c Then
			Return (2)
		End If
		If x = "^"c Then
			Return (3)
		End If
		Return (4)
	End Function

	Public Shared Function infixToPostfix(ByVal expn As String) As String
		Dim output As String = ""
		Dim outArr() As Char = infixToPostfix(expn.ToCharArray())

		For Each ch As Char In outArr
			output = output & ch
		Next ch
		Return output
	End Function

	Public Shared Function infixToPostfix(ByVal expn() As Char) As Char()
		Dim stk As New Stack(Of Char)()

		Dim output As String = ""
		Dim temp As Char

		For Each ch As Char In expn
			If ch <= "9"c AndAlso ch >= "0"c Then
				output = output & ch
			Else
				Select Case ch
					Case "+"c, "-"c, "*"c, "/"c, "%"c, "^"c
						Do While stk.Count <> 0 AndAlso precedence(ch) <= precedence(stk.Peek())
							temp = stk.Pop()
							output = output & " " & temp
						Loop
						stk.Push(ch)
						output = output & " "
					Case "("c
						stk.Push(ch)
					Case ")"c
						temp = stk.Pop()
						Do While stk.Count <> 0 AndAlso temp <> "("c
							output = output & " " & temp & " "
							temp = stk.Pop()
						Loop
				End Select
			End If
		Next ch

		Do While stk.Count <> 0
			temp = stk.Pop()
			output = output & temp & " "
		Loop
		Return output.ToCharArray()
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim expn As String = "10+((3))*5/(16-4)"
		Dim value As String = infixToPostfix(expn)
		Console.WriteLine("Infix Expn: " & expn)
		Console.WriteLine("Postfix Expn: " & value)
	End Sub

	Public Shared Function infixToPrefix(ByVal expn As String) As String
		Dim arr() As Char = expn.ToCharArray()
		reverseString(arr)
		replaceParanthesis(arr)
		arr = infixToPostfix(arr)
		reverseString(arr)
		expn = New String(arr)
		Return expn
	End Function

	Public Shared Sub replaceParanthesis(ByVal a() As Char)
		Dim lower As Integer = 0
		Dim upper As Integer = a.Length - 1
		Do While lower <= upper
			If a(lower) = "("c Then
				a(lower) = ")"c
			ElseIf a(lower) = ")"c Then
				a(lower) = "("c
			End If
			lower += 1
		Loop
	End Sub

	Public Shared Sub reverseString(ByVal expn() As Char)
		Dim lower As Integer = 0
		Dim upper As Integer = expn.Length - 1
		Dim tempChar As Char
		Do While lower < upper
			tempChar = expn(lower)
			expn(lower) = expn(upper)
			expn(upper) = tempChar
			lower += 1
			upper -= 1
		Loop
	End Sub

	Public Shared Sub main5(ByVal args() As String)
		Dim expn As String = "10+((3))*5/(16-4)"
		Dim value As String = infixToPrefix(expn)
		Console.WriteLine("Infix Expn: " & expn)
		Console.WriteLine("Prefix Expn: " & value)
	End Sub



	Public Shared Function StockSpanRange(ByVal arr() As Integer) As Integer()
		Dim SR(arr.Length - 1) As Integer
		SR(0) = 1
		For i As Integer = 1 To arr.Length - 1
			SR(i) = 1
			Dim j As Integer = i - 1
			Do While (j >= 0) AndAlso (arr(i) >= arr(j))
				SR(i) += 1
				j -= 1
			Loop
		Next i
		Return SR
	End Function

	Friend Overridable Function StockSpanRange2(ByVal arr() As Integer) As Integer()
		Dim stk As New Stack(Of Integer)()

		Dim SR(arr.Length - 1) As Integer
		stk.Push(0)
		SR(0) = 1
		For i As Integer = 1 To arr.Length - 1
			Do While stk.Count <> 0 AndAlso arr(stk.Peek()) <= arr(i)
				stk.Pop()
			Loop
			SR(i) = If(stk.Count = 0, (i + 1), (i - stk.Peek()))
			stk.Push(i)
		Next i
		Return SR
	End Function

	Public Shared Function GetMaxArea(ByVal arr() As Integer) As Integer
		Dim size As Integer = arr.Length
		Dim maxArea As Integer = -1
		Dim currArea As Integer
		Dim minHeight As Integer = 0
		For i As Integer = 1 To size - 1
			minHeight = arr(i)
			For j As Integer = i - 1 To 0 Step -1
				If minHeight > arr(j) Then
					minHeight = arr(j)
				End If
				currArea = minHeight * (i - j + 1)
				If maxArea < currArea Then
					maxArea = currArea
				End If
			Next j
		Next i
		Return maxArea
	End Function


	Public Shared Function GetMaxArea2(ByVal arr() As Integer) As Integer
		Dim size As Integer = arr.Length
		Dim stk As New Stack(Of Integer)()
		Dim maxArea As Integer = 0
		Dim top As Integer
		Dim topArea As Integer
		Dim i As Integer = 0
		Do While i < size
			Do While (i < size) AndAlso (stk.Count = 0 OrElse arr(stk.Peek()) <= arr(i))
				stk.Push(i)
				i += 1
			Loop
			Do While stk.Count <> 0 AndAlso (i = size OrElse arr(stk.Peek()) > arr(i))
				top = stk.Peek()
				stk.Pop()
				topArea = arr(top) * (If(stk.Count = 0, i, i - stk.Peek() - 1))
				If maxArea < topArea Then
					maxArea = topArea
				End If
			Loop
		Loop
		Return maxArea
	End Function
End Class

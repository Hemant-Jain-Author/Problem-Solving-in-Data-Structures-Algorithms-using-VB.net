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

	Public Shared Sub Main1(ByVal args() As String)
		Dim expn As String = "{()}[]"
		Dim value As Boolean = isBalancedParenthesis(expn)
		Console.WriteLine("Given Expn:" & expn)
		Console.WriteLine("Result after isParenthesisMatched:" & value)
	End Sub

	Public Shared Sub insertAtBottom(Of T)(ByVal stk As Stack(Of T), ByVal value As T)
		If stk.Count = 0 Then
			stk.Push(value)
		Else
			Dim popValue As T = stk.Pop()
			insertAtBottom(stk, value)
			stk.Push(popValue)
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

	Public Shared Sub Main2(ByVal args() As String)
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
						'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
						'ORIGINAL LINE: while (stk.Count != 0 && (temp = stk.Pop()) != "("c)
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

	Public Shared Sub Main3(ByVal args() As String)
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

	Public Shared Sub Main4(ByVal args() As String)
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

	Public Shared Function StockSpanRange2(ByVal arr() As Integer) As Integer()
		Dim stk As New Stack(Of Integer)()

		Dim SR(arr.Length - 1) As Integer
		stk.Push(0)
		SR(0) = 1
		For i As Integer = 1 To arr.Length - 1
			Do While stk.Count > 0 AndAlso arr(stk.Peek()) <= arr(i)
				stk.Pop()
			Loop
			SR(i) = If(stk.Count = 0, (i + 1), (i - stk.Peek()))
			stk.Push(i)
		Next i
		Return SR
	End Function

	Public Shared Sub Main5(ByVal args() As String)
		Dim arr() As Integer = {6, 5, 4, 3, 2, 4, 5, 7, 9}
		Dim size As Integer = arr.Length
		Dim value() As Integer = StockSpanRange(arr)
		Console.Write(ControlChars.Lf & " StockSpanRange : ")
		For Each val As Integer In value
			Console.Write(" " & val)
		Next val
		value = StockSpanRange2(arr)
		Console.Write(ControlChars.Lf & " StockSpanRange : ")
		For Each val As Integer In value
			Console.Write(" " & val)
		Next val
		Console.WriteLine()
	End Sub

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
			Do While stk.Count > 0 AndAlso (i = size OrElse arr(stk.Peek()) > arr(i))
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

	Public Shared Sub Main6(ByVal args() As String)
		Dim arr() As Integer = {7, 6, 5, 4, 4, 1, 6, 3, 1}
		Dim size As Integer = arr.Length
		Dim value As Integer = GetMaxArea(arr)
		Console.WriteLine("GetMaxArea :: " & value)
		value = GetMaxArea2(arr)
		Console.WriteLine("GetMaxArea :: " & value)
	End Sub

	Public Shared Sub sortedInsert(ByVal stk As Stack(Of Integer), ByVal element As Integer)
		Dim temp As Integer
		If stk.Count = 0 OrElse element > stk.Peek() Then
			stk.Push(element)
		Else
			temp = stk.Pop()
			sortedInsert(stk, element)
			stk.Push(temp)
		End If
	End Sub

	Public Shared Sub sortStack(ByVal stk As Stack(Of Integer))
		Dim temp As Integer
		If stk.Count > 0 Then
			temp = stk.Pop()
			sortStack(stk)
			stk.Push(temp)
		End If
	End Sub

	Public Shared Sub sortStack2(ByVal stk As Stack(Of Integer))
		Dim temp As Integer
		Dim stk2 As New Stack(Of Integer)()
		Do While stk.Count > 0
			temp = stk.Pop()
			Do While (stk.Count > 0) AndAlso (stk2.Peek() < temp)
				stk.Push(stk2.Pop())
			Loop
			stk2.Push(temp)
		Loop
		Do While stk2.Count > 0
			stk.Push(stk2.Pop())
		Loop
	End Sub

	Public Shared Sub bottomInsert(ByVal stk As Stack(Of Integer), ByVal element As Integer)
		Dim temp As Integer
		If stk.Count = 0 Then
			stk.Push(element)
		Else
			temp = stk.Pop()
			bottomInsert(stk, element)
			stk.Push(temp)
		End If
	End Sub

	Public Shared Sub reverseStack2(ByVal stk As Stack(Of Integer))
		Dim que As New Queue(Of Integer)()
		Do While stk.Count > 0
			que.Enqueue(stk.Pop())
		Loop

		Do While que.Count <> 0
			stk.Push(que.Dequeue())
		Loop
	End Sub

	Public Shared Sub reverseKElementInStack(ByVal stk As Stack(Of Integer), ByVal k As Integer)
		Dim que As New Queue(Of Integer)()
		Dim i As Integer = 0
		Do While stk.Count > 0 AndAlso i < k
			que.Enqueue(stk.Pop())
			i += 1
		Loop
		Do While que.Count <> 0
			stk.Push(que.Dequeue())
		Loop
	End Sub

	Public Shared Sub reverseQueue(ByVal que As Queue(Of Integer))
		Dim stk As New Stack(Of Integer)()
		Do While que.Count <> 0
			stk.Push(que.Dequeue())
		Loop

		Do While stk.Count > 0
			que.Enqueue(stk.Pop())
		Loop
	End Sub

	Public Shared Sub reverseKElementInQueue(ByVal que As Queue(Of Integer), ByVal k As Integer)
		Dim stk As New Stack(Of Integer)()
		Dim i As Integer = 0, diff As Integer, temp As Integer
		Do While que.Count <> 0 AndAlso i < k
			stk.Push(que.Dequeue())
			i += 1
		Loop
		Do While stk.Count > 0
			que.Enqueue(stk.Pop())
		Loop
		diff = que.Count - k
		Do While diff > 0
			temp = que.Dequeue()
			que.Enqueue(temp)
			diff -= 1
		Loop
	End Sub

	Public Shared Sub Main7(ByVal args() As String)
		Dim stk As New Stack(Of Integer)()
		stk.Push(1)
		stk.Push(2)
		stk.Push(3)
		stk.Push(4)
		stk.Push(5)
		For Each i As Integer In stk
			Console.Write(" " & i)
		Next i
		Console.WriteLine()
	End Sub

	Public Shared Sub Main8(ByVal args() As String)
		Dim stk As New Stack(Of Integer)()
		stk.Push(-2)
		stk.Push(13)
		stk.Push(16)
		stk.Push(-6)
		stk.Push(40)
		For Each i As Integer In stk
			Console.Write(" " & i)
		Next i
		Console.WriteLine()

		reverseStack2(stk)
		For Each i As Integer In stk
			Console.Write(" " & i)
		Next i
		Console.WriteLine()

		reverseKElementInStack(stk, 2)
		For Each i As Integer In stk
			Console.Write(" " & i)
		Next i
		Console.WriteLine()
		'	
		'		* System.out.println(stk); sortStack2(stk); System.out.println(stk);
		'		
		Dim que As New Queue(Of Integer)()
		que.Enqueue(1)
		que.Enqueue(2)
		que.Enqueue(3)
		que.Enqueue(4)
		que.Enqueue(5)
		que.Enqueue(6)
		For Each i As Integer In que
			Console.Write(" " & i)
		Next i
		Console.WriteLine()

		reverseQueue(que)
		For Each i As Integer In que
			Console.Write(" " & i)
		Next i
		Console.WriteLine()

		reverseKElementInQueue(que, 2)
		For Each i As Integer In que
			Console.Write(" " & i)
		Next i
		Console.WriteLine()
	End Sub

	Public Shared Function maxDepthParenthesis(ByVal expn As String, ByVal size As Integer) As Integer
		Dim stk As New Stack(Of Char)()
		Dim maxDepth As Integer = 0
		Dim depth As Integer = 0
		Dim ch As Char

		For i As Integer = 0 To size - 1
			ch = expn.Chars(i)

			If ch = "("c Then
				stk.Push(ch)
				depth += 1
			ElseIf ch = ")"c Then
				stk.Pop()
				depth -= 1
			End If
			If depth > maxDepth Then
				maxDepth = depth
			End If
		Next i
		Return maxDepth
	End Function

	Public Shared Function maxDepthParenthesis2(ByVal expn As String, ByVal size As Integer) As Integer
		Dim maxDepth As Integer = 0
		Dim depth As Integer = 0
		Dim ch As Char
		For i As Integer = 0 To size - 1
			ch = expn.Chars(i)
			If ch = "("c Then
				depth += 1
			ElseIf ch = ")"c Then
				depth -= 1
			End If

			If depth > maxDepth Then
				maxDepth = depth
			End If
		Next i
		Return maxDepth
	End Function

	Public Shared Sub Main9(ByVal args() As String)
		Dim expn As String = "((((A)))((((BBB()))))()()()())"
		Dim size As Integer = expn.Length
		Dim value As Integer = maxDepthParenthesis(expn, size)
		Dim value2 As Integer = maxDepthParenthesis2(expn, size)

		Console.WriteLine("Given expn " & expn)
		Console.WriteLine("Max depth parenthesis is " & value)
		Console.WriteLine("Max depth parenthesis is " & value2)
	End Sub

	Public Shared Function longestContBalParen(ByVal str As String, ByVal size As Integer) As Integer
		Dim stk As New Stack(Of Integer)()
		stk.Push(-1)
		Dim length As Integer = 0

		For i As Integer = 0 To size - 1

			If str.Chars(i) = "("c Then
				stk.Push(i)
			Else ' string[i] == ')'
				stk.Pop()
				If stk.Count <> 0 Then
					length = Math.Max(length, i - stk.Peek())
				Else
					stk.Push(i)
				End If
			End If
		Next i
		Return length
	End Function

	Public Shared Sub Main10(ByVal args() As String)
		Dim expn As String = "())((()))(())()(()"
		Dim size As Integer = expn.Length
		Dim value As Integer = longestContBalParen(expn, size)
		Console.WriteLine("longestContBalParen " & value)
	End Sub

	Public Shared Function reverseParenthesis(ByVal expn As String, ByVal size As Integer) As Integer
		Dim stk As New Stack(Of Char)()
		Dim openCount As Integer = 0
		Dim closeCount As Integer = 0
		Dim ch As Char

		If size Mod 2 = 1 Then
			Console.WriteLine("Invalid odd length " & size)
			Return -1
		End If
		For i As Integer = 0 To size - 1
			ch = expn.Chars(i)
			If ch = "("c Then
				stk.Push(ch)
			ElseIf ch = ")"c Then
				If stk.Count <> 0 AndAlso stk.Peek() = "("c Then
					stk.Pop()
				Else
					stk.Push(")"c)
				End If
			End If
		Next i
		Do While stk.Count <> 0
			If stk.Pop() = "("c Then
				openCount += 1
			Else
				closeCount += 1
			End If
		Loop
		Dim reversal As Integer = CInt(Math.Truncate(Math.Ceiling(openCount / 2.0))) + CInt(Math.Truncate(Math.Ceiling(closeCount / 2.0)))
		Return reversal
	End Function

	Public Shared Sub Main11(ByVal args() As String)
		'string expn = "())((()))(())()(()()()()))";
		Dim expn2 As String = ")(())((("
		Dim size As Integer = expn2.Length
		Dim value As Integer = reverseParenthesis(expn2, size)
		Console.WriteLine("Given expn : " & expn2)
		Console.WriteLine("reverse Parenthesis is : " & value)
	End Sub

	Public Shared Function findDuplicateParenthesis(ByVal expn As String, ByVal size As Integer) As Boolean
		Dim stk As New Stack(Of Char)()
		Dim ch As Char
		Dim count As Integer

		For i As Integer = 0 To size - 1
			ch = expn.Chars(i)
			If ch = ")"c Then
				count = 0
				Do While stk.Count <> 0 AndAlso stk.Peek() <> "("c
					stk.Pop()
					count += 1
				Loop
				If count <= 1 Then
					Return True
				End If
			Else
				stk.Push(ch)
			End If
		Next i
		Return False
	End Function

	Public Shared Sub Main12(ByVal args() As String)
		' expn = "(((a+(b))+(c+d)))"
		' expn = "(b)"
		Dim expn As String = "(((a+b))+c)"
		Console.WriteLine("Given expn : " & expn)
		Dim size As Integer = expn.Length
		Dim value As Boolean = findDuplicateParenthesis(expn, size)
		Console.WriteLine("Duplicate Found : " & value)
	End Sub

	Public Shared Sub printParenthesisNumber(ByVal expn As String, ByVal size As Integer)
		Dim ch As Char
		Dim stk As New Stack(Of Integer)()
		Dim output As String = ""
		Dim count As Integer = 1
		For i As Integer = 0 To size - 1
			ch = expn.Chars(i)
			If ch = "("c Then
				stk.Push(count)
				output &= count
				count += 1
			ElseIf ch = ")"c Then
				output &= stk.Pop()
			End If
		Next i
		Console.WriteLine("Parenthesis Count : " & output)
	End Sub

	Public Shared Sub Main13(ByVal args() As String)
		Dim expn1 As String = "(((a+(b))+(c+d)))"
		Dim expn2 As String = "(((a+b))+c)((("
		Dim size As Integer = expn1.Length
		Console.WriteLine("Given expn " & expn1)
		printParenthesisNumber(expn1, size)
		size = expn2.Length
		Console.WriteLine("Given expn " & expn2)
		printParenthesisNumber(expn2, size)
	End Sub

	Public Shared Sub nextLargerElement(ByVal arr() As Integer, ByVal size As Integer)
		Dim output(size - 1) As Integer
		Dim outIndex As Integer = 0
		Dim [next] As Integer

		For i As Integer = 0 To size - 1
			[next] = -1
			For j As Integer = i + 1 To size - 1
				If arr(i) < arr(j) Then
					[next] = arr(j)
					Exit For
				End If
			Next j
			'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
			'ORIGINAL LINE: output[outIndex++] = next;
			output(outIndex) = [next]
			outIndex += 1
		Next i
		For Each val As Integer In output
			Console.Write(val & " ")
		Next val
		Console.WriteLine()
	End Sub

	Public Shared Sub nextLargerElement2(ByVal arr() As Integer, ByVal size As Integer)
		Dim stk As New Stack(Of Integer)()
		' output = [-1] * size;
		Dim output(size - 1) As Integer
		Dim index As Integer = 0
		Dim curr As Integer

		For i As Integer = 0 To size - 1
			curr = arr(i)
			' stack always have values in decreasing order.
			Do While stk.Count > 0 AndAlso arr(stk.Peek()) <= curr
				index = stk.Pop()
				output(index) = curr
			Loop
			stk.Push(i)
		Next i
		' index which dont have any next Larger.
		Do While stk.Count > 0
			index = stk.Pop()
			output(index) = -1
		Loop
		For Each val As Integer In output
			Console.Write(val & " ")
		Next val
		Console.WriteLine()
	End Sub

	Public Shared Sub nextSmallerElement(ByVal arr() As Integer, ByVal size As Integer)
		Dim stk As New Stack(Of Integer)()
		Dim output(size - 1) As Integer
		Dim curr, index As Integer
		For i As Integer = 0 To size - 1
			curr = arr(i)
			' stack always have values in increasing order.
			Do While stk.Count > 0 AndAlso arr(stk.Peek()) > curr
				index = stk.Pop()
				output(index) = curr
			Loop
			stk.Push(i)
		Next i
		' index which dont have any next Smaller.
		Do While stk.Count > 0
			index = stk.Pop()
			output(index) = -1
		Loop
		For Each val As Integer In output
			Console.Write(val & " ")
		Next val
		Console.WriteLine()
	End Sub

	Public Shared Sub Main14(ByVal args() As String)
		Dim arr() As Integer = {13, 21, 3, 6, 20, 3}
		Dim size As Integer = arr.Length
		nextLargerElement(arr, size)
		nextLargerElement2(arr, size)
		nextSmallerElement(arr, size)
	End Sub

	Public Shared Sub nextLargerElementCircular(ByVal arr() As Integer, ByVal size As Integer)
		Dim stk As New Stack(Of Integer)()
		Dim curr, index As Integer
		Dim output(size - 1) As Integer
		Dim i As Integer = 0
		Do While i < (2 * size - 1)
			curr = arr(i Mod size)
			' stack always have values in decreasing order.
			Do While stk.Count > 0 AndAlso arr(stk.Peek()) <= curr
				index = stk.Pop()
				output(index) = curr
			Loop
			stk.Push(i Mod size)
			i += 1
		Loop
		' index which dont have any next Larger.
		Do While stk.Count > 0
			index = stk.Pop()
			output(index) = -1
		Loop
		For Each val As Integer In output
			Console.Write(val & " ")
		Next val
		Console.WriteLine()
	End Sub

	Public Shared Sub Main15(ByVal args() As String)
		Dim arr() As Integer = {6, 3, 9, 8, 10, 2, 1, 15, 7}
		Dim size As Integer = arr.Length
		nextLargerElementCircular(arr, size)
	End Sub

	Public Shared Sub RottenFruitUtil(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer, ByVal currCol As Integer, ByVal currRow As Integer, ByVal traversed(,) As Integer, ByVal day As Integer) ' Range check
		If currCol < 0 OrElse currCol >= maxCol OrElse currRow < 0 OrElse currRow >= maxRow Then
			Return
		End If
		' Traversable and rot if not already rotten.
		If traversed(currCol, currRow) <= day OrElse arr(currCol, currRow) = 0 Then
			Return
		End If
		' Update rot time.
		traversed(currCol, currRow) = day
		' each line corresponding to 4 direction.
		RottenFruitUtil(arr, maxCol, maxRow, currCol - 1, currRow, traversed, day + 1)
		RottenFruitUtil(arr, maxCol, maxRow, currCol + 1, currRow, traversed, day + 1)
		RottenFruitUtil(arr, maxCol, maxRow, currCol, currRow + 1, traversed, day + 1)
		RottenFruitUtil(arr, maxCol, maxRow, currCol, currRow - 1, traversed, day + 1)
	End Sub

	Public Shared Function RottenFruit(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer) As Integer
		Dim traversed(maxCol - 1, maxRow - 1) As Integer
		For k As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				traversed(k, j) = Integer.MaxValue
			Next j
		Next k

		Dim i As Integer = 0
		Do While i < maxCol - 1
			Dim j As Integer = 0
			Do While j < maxRow - 1
				If arr(i, j) = 2 Then
					RottenFruitUtil(arr, maxCol, maxRow, i, j, traversed, 0)
				End If
				j += 1
			Loop
			i += 1
		Loop

		Dim maxDay As Integer = 0
		i = 0
		Do While i < maxCol - 1
			Dim j As Integer = 0
			Do While j < maxRow - 1
				If arr(i, j) = 1 Then
					If traversed(i, j) = Integer.MaxValue Then
						Return -1
					End If
					If maxDay < traversed(i, j) Then
						maxDay = traversed(i, j)
					End If
				End If
				j += 1
			Loop
			i += 1
		Loop
		Return maxDay
	End Function

	Public Shared Sub Main16(ByVal args() As String)
		Dim arr(,) As Integer = {
			{1, 0, 1, 1, 0},
			{2, 1, 0, 1, 0},
			{0, 0, 0, 2, 1},
			{0, 2, 0, 0, 1},
			{1, 1, 0, 0, 1}
		}
		Console.WriteLine(RottenFruit(arr, 5, 5))
	End Sub

	Public Shared Sub StepsOfKnightUtil(ByVal size As Integer, ByVal currCol As Integer, ByVal currRow As Integer, ByVal traversed(,) As Integer, ByVal dist As Integer)
		' Range check
		If currCol < 0 OrElse currCol >= size OrElse currRow < 0 OrElse currRow >= size Then
			Return
		End If

		' Traversable and rot if not already rotten.
		If traversed(currCol, currRow) <= dist Then
			Return
		End If

		' Update rot time.
		traversed(currCol, currRow) = dist
		' each line corresponding to 4 direction.
		StepsOfKnightUtil(size, currCol - 2, currRow - 1, traversed, dist + 1)
		StepsOfKnightUtil(size, currCol - 2, currRow + 1, traversed, dist + 1)
		StepsOfKnightUtil(size, currCol + 2, currRow - 1, traversed, dist + 1)
		StepsOfKnightUtil(size, currCol + 2, currRow + 1, traversed, dist + 1)
		StepsOfKnightUtil(size, currCol - 1, currRow - 2, traversed, dist + 1)
		StepsOfKnightUtil(size, currCol + 1, currRow - 2, traversed, dist + 1)
		StepsOfKnightUtil(size, currCol - 1, currRow + 2, traversed, dist + 1)
		StepsOfKnightUtil(size, currCol + 1, currRow + 2, traversed, dist + 1)
	End Sub

	Public Shared Function StepsOfKnight(ByVal size As Integer, ByVal srcX As Integer, ByVal srcY As Integer, ByVal dstX As Integer, ByVal dstY As Integer) As Integer
		Dim traversed(size - 1, size - 1) As Integer
		For i As Integer = 0 To size - 1
			For j As Integer = 0 To size - 1
				traversed(i, j) = Integer.MaxValue
			Next j
		Next i

		StepsOfKnightUtil(size, srcX - 1, srcY - 1, traversed, 0)
		Dim retval As Integer = traversed(dstX - 1, dstY - 1)
		Return retval
	End Function

	Public Shared Sub Main17(ByVal args() As String)
		Console.WriteLine(StepsOfKnight(20, 10, 10, 20, 20))
	End Sub

	Public Shared Sub DistNearestFillUtil(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer, ByVal currCol As Integer, ByVal currRow As Integer, ByVal traversed(,) As Integer, ByVal dist As Integer) ' Range check
		If currCol < 0 OrElse currCol >= maxCol OrElse currRow < 0 OrElse currRow >= maxRow Then
			Return
		End If
		' Traversable if their is a better distance.
		If traversed(currCol, currRow) <= dist Then
			Return
		End If
		' Update distance.
		traversed(currCol, currRow) = dist
		' each line corresponding to 4 direction.
		DistNearestFillUtil(arr, maxCol, maxRow, currCol - 1, currRow, traversed, dist + 1)
		DistNearestFillUtil(arr, maxCol, maxRow, currCol + 1, currRow, traversed, dist + 1)
		DistNearestFillUtil(arr, maxCol, maxRow, currCol, currRow + 1, traversed, dist + 1)
		DistNearestFillUtil(arr, maxCol, maxRow, currCol, currRow - 1, traversed, dist + 1)
	End Sub

	Public Shared Sub DistNearestFill(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer)
		Dim traversed(maxCol - 1, maxRow - 1) As Integer
		For k As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				traversed(k, j) = Integer.MaxValue
			Next j
		Next k
		Dim i As Integer = 0
		Do While i < maxCol
			Dim j As Integer = 0
			Do While j < maxRow
				If arr(i, j) = 1 Then
					DistNearestFillUtil(arr, maxCol, maxRow, i, j, traversed, 0)
				End If
				j += 1
			Loop
			i += 1
		Loop

		For l As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				Console.Write(" " & traversed(l, j))
			Next j
			Console.WriteLine()
		Next l
	End Sub

	Public Shared Sub Main18(ByVal args() As String)
		Dim arr(,) As Integer = {
			{1, 0, 1, 1, 0},
			{1, 1, 0, 1, 0},
			{0, 0, 0, 0, 1},
			{0, 0, 0, 0, 1},
			{0, 0, 0, 0, 1}
		}
		DistNearestFill(arr, 5, 5)
	End Sub

	Public Shared Function findLargestIslandUtil(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer, ByVal currCol As Integer, ByVal currRow As Integer, ByVal value As Integer, ByVal traversed(,) As Integer) As Integer
		If currCol < 0 OrElse currCol >= maxCol OrElse currRow < 0 OrElse currRow >= maxRow Then
			Return 0
		End If
		If traversed(currCol, currRow) = 1 OrElse arr(currCol, currRow) <> value Then
			Return 0
		End If
		traversed(currCol, currRow) = 1
		' each call corresponding to 8 direction.
		Return 1 + findLargestIslandUtil(arr, maxCol, maxRow, currCol - 1, currRow - 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol - 1, currRow, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol - 1, currRow + 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol, currRow - 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol, currRow + 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol + 1, currRow - 1, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol + 1, currRow, value, traversed) + findLargestIslandUtil(arr, maxCol, maxRow, currCol + 1, currRow + 1, value, traversed)
	End Function

	Public Shared Function findLargestIsland(ByVal arr(,) As Integer, ByVal maxCol As Integer, ByVal maxRow As Integer) As Integer
		Dim maxVal As Integer = 0
		Dim currVal As Integer = 0

		Dim traversed(maxCol - 1, maxRow - 1) As Integer
		For k As Integer = 0 To maxCol - 1
			For j As Integer = 0 To maxRow - 1
				traversed(k, j) = Integer.MaxValue
			Next j
		Next k
		Dim i As Integer = 0
		Do While i < maxCol
			Dim j As Integer = 0
			Do While j < maxRow
				If True Then
					currVal = findLargestIslandUtil(arr, maxCol, maxRow, i, j, arr(i, j), traversed)
					If currVal > maxVal Then
						maxVal = currVal
					End If
				End If
				j += 1
			Loop
			i += 1
		Loop
		Return maxVal
	End Function

	Public Shared Sub Main19(ByVal args() As String)
		Dim arr(,) As Integer = {
			{1, 0, 1, 1, 0},
			{1, 0, 0, 1, 0},
			{0, 1, 1, 1, 1},
			{0, 1, 0, 0, 0},
			{1, 1, 0, 0, 1}
		}
		Console.WriteLine("Largest Island : " & findLargestIsland(arr, 5, 5))
	End Sub

	Public Shared Function isKnown(ByVal relation(,) As Integer, ByVal a As Integer, ByVal b As Integer) As Boolean
		If relation(a, b) = 1 Then
			Return True
		End If
		Return False
	End Function

	Public Shared Function findCelebrity(ByVal relation(,) As Integer, ByVal count As Integer) As Integer
		Dim stk As New Stack(Of Integer)()
		Dim first As Integer = 0, second As Integer = 0
		For i As Integer = 0 To count - 1
			stk.Push(i)
		Next i
		first = stk.Pop()
		Do While stk.Count <> 0
			second = stk.Pop()
			If isKnown(relation, first, second) Then
				first = second
			End If
		Loop
		For i As Integer = 0 To count - 1
			If first <> i AndAlso isKnown(relation, first, i) Then
				Return -1
			End If
			If first <> i AndAlso isKnown(relation, i, first) = False Then
				Return -1
			End If
		Next i
		Return first
	End Function

	Public Shared Function findCelebrity2(ByVal relation(,) As Integer, ByVal count As Integer) As Integer
		Dim first As Integer = 0
		Dim second As Integer = 1

		Dim i As Integer = 0
		Do While i < (count - 1)
			If isKnown(relation, first, second) Then
				first = second
			End If
			second = second + 1
			i += 1
		Loop
		For k As Integer = 0 To count - 1
			If first <> k AndAlso isKnown(relation, first, k) Then
				Return -1
			End If
			If first <> k AndAlso isKnown(relation, k, first) = False Then
				Return -1
			End If
		Next k
		Return first
	End Function

	Public Shared Sub Main20(ByVal args() As String)
		Dim arr(,) As Integer = {
			{1, 0, 1, 1, 0},
			{1, 0, 0, 1, 0},
			{0, 0, 1, 1, 1},
			{0, 0, 0, 0, 0},
			{1, 1, 0, 1, 1}
		}

		Console.WriteLine("Celebrity : " & findCelebrity(arr, 5))
		Console.WriteLine("Celebrity : " & findCelebrity2(arr, 5))
	End Sub

	Public Shared Function IsMinHeap(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim i As Integer = 0
		Do While i <= (size - 2) \ 2
			If 2 * i + 1 < size Then
				If arr(i) > arr(2 * i + 1) Then
					Return 0
				End If
			End If
			If 2 * i + 2 < size Then
				If arr(i) > arr(2 * i + 2) Then
					Return 0
				End If
			End If
			i += 1
		Loop
		Return 1
	End Function

	Public Shared Function IsMaxHeap(ByVal arr() As Integer, ByVal size As Integer) As Integer
		Dim i As Integer = 0
		Do While i <= (size - 2) \ 2
			If 2 * i + 1 < size Then
				If arr(i) < arr(2 * i + 1) Then
					Return 0
				End If
			End If
			If 2 * i + 2 < size Then
				If arr(i) < arr(2 * i + 2) Then
					Return 0
				End If
			End If
			i += 1
		Loop
		Return 1
	End Function
	Public Shared Sub Main(ByVal args() As String)
		Main1(args)
		Main2(args)
		Main3(args)
		Main4(args)
		Main5(args)
		Main6(args)
		Main7(args)
		Main8(args)
		Main9(args)
		Main10(args)
		Main11(args)
		Main12(args)
		Main13(args)
		Main14(args)
		Main15(args)
		Main16(args)
		Main17(args)
		Main18(args)
		Main19(args)
		Main20(args)
	End Sub
End Class


'
'Given Expn:{()}[]
'Result after isParenthesisMatched:True
'
'Given Postfix Expn: 6 5 2 3 + 8 * + 3 + *
'Result after Evaluation: 288
'
'Infix Expn: 10+((3))*5/(16-4)
'Postfix Expn: 10 3 5 * 16 4 - / +
'
'Infix Expn: 10+((3))*5/(16-4)
'Prefix Expn:  +10 * 3 / 5  - 16 4
'
'StockSpanRange :  1 1 1 1 1 4 6 8 9
'StockSpanRange :  1 1 1 1 1 4 6 8 9
'
'GetMaxArea :: 20
'GetMaxArea :: 20
'
'5 4 3 2 1
'
'40 -6 16 13 -2
'
'-2 13 16 -6 40
'
'13 -2 16 -6 40
'
'1 2 3 4 5 6
'
'6 5 4 3 2 1
'
'5 6 4 3 2 1
'
'Given expn ((((A)))((((BBB()))))()()()())
'Max depth parenthesis is 6
'Max depth parenthesis is 6
'
'longestContBalParen 12
'
'Given expn : )(())(((
'reverse Parenthesis is : 3
'
'Given expn : (((a+b))+c)
'Duplicate Found : True
'
'Given expn (((a+(b))+(c+d)))
'Parenthesis Count : 1234435521
'
'Given expn (((a+b))+c)(((
'Parenthesis Count : 123321456
'
'21 -1 6 20 -1 -1
'21 -1 6 20 -1 -1
'
'3 3 -1 3 3 -1
'
'9 9 10 10 15 15 15 -1 9
'
'3
'
'8
'
'0 1 0 0 1
'0 0 1 0 1
'1 1 2 1 0
'2 2 2 1 0
'3 3 2 1 0
'
'Largest Island : 12
'
'Celebrity : 3
'Celebrity : 3
'

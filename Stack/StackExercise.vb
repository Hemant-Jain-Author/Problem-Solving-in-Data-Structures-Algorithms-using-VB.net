Imports System
Imports System.Collections.Generic
Public Module StackExercise
    Sub Function2()
        Console.WriteLine("Function2 line 1")
    End Sub

    Sub Function1()
        Console.WriteLine("Function1 line 1")
        Function2()
        Console.WriteLine("Function1 line 2")
    End Sub

    ' Testing code
    Sub Main1()
        Console.WriteLine("Main line 1")
        Function1()
        Console.WriteLine("Main line 2")
    End Sub
    '
    'Main line 1
    'Function1 line 1
    'Function2 line 1
    'Function1 line 2
    'Main line 2
    '

    Function IsBalancedParenthesis(ByVal expn As String) As Boolean
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

    ' Testing code.
    Sub Main2()
        Dim expn As String = "{()}[]"
        Dim value As Boolean = IsBalancedParenthesis(expn)
        Console.WriteLine("Result after isParenthesisMatched: " & value)
    End Sub

    '
    '	Result after isParenthesisMatched: True
    '

    Function PostfixEvaluate(ByVal expn As String) As Integer
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

    ' Testing code.
    Sub Main3()
        Dim expn As String = "6 5 2 3 + 8 * + 3 + *"
        Dim value As Integer = PostfixEvaluate(expn)
        Console.WriteLine("Given Postfix Expn: " & expn)
        Console.WriteLine("Result after Evaluation: " & value)
    End Sub

    '
    '	Given Postfix Expn: 6 5 2 3 + 8 * + 3 + *
    '	Result after Evaluation: 288
    '

    Function precedence(ByVal x As Char) As Integer
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

    Function InfixToPostfix(ByVal expn As String) As String
        Dim output As String = ""
        Dim outVr() As Char = InfixToPostfix(expn.ToCharArray())

        For Each ch As Char In outVr
            output = output & ch
        Next ch
        Return output
    End Function

    Function InfixToPostfix(ByVal expn() As Char) As Char()
        Dim stk As New Stack(Of Char)()

        Dim output As String = ""
        Dim outVr As Char

        For Each ch As Char In expn
            If ch <= "9"c AndAlso ch >= "0"c Then
                output = output & ch
            Else
                Select Case ch
                    Case "+"c, "-"c, "*"c, "/"c, "%"c, "^"c
                        While stk.Count > 0 AndAlso precedence(ch) <= precedence(stk.Peek())
                            outVr = stk.Pop()
                            output = output & " " & outVr
                        End While
                        stk.Push(ch)
                        output = output & " "
                    Case "("c
                        stk.Push(ch)
                    Case ")"c
                        outVr = stk.Pop()
                        While stk.Count > 0 AndAlso outVr <> "("c
                            output = output & " " & outVr & " "
                            outVr = stk.Pop()
                        End While
                End Select
            End If
        Next ch

        While stk.Count > 0
            outVr = stk.Pop()
            output = output & outVr & " "
        End While
        Return output.ToCharArray()
    End Function

    ' Testing code.
    Sub Main4()
        Dim expn As String = "10+((3))*5/(16-4)"
        Dim value As String = InfixToPostfix(expn)
        Console.WriteLine("Infix Expn: " & expn)
        Console.WriteLine("Postfix Expn: " & value)
    End Sub

    '
    '	Infix Expn: 10+((3))*5/(16-4)
    '	Postfix Expn: 10 3 5 * 16 4 - / +
    '

    Function InfixToPrefix(ByVal expn As String) As String
        Dim arr() As Char = expn.ToCharArray()
        ReverseString(arr)
        ReplaceParenthesis(arr)
        arr = InfixToPostfix(arr)
        ReverseString(arr)
        expn = New String(arr)
        Return expn
    End Function

    Sub ReplaceParenthesis(ByVal a() As Char)
        Dim lower As Integer = 0
        Dim upper As Integer = a.Length - 1
        While lower <= upper
            If a(lower) = "("c Then
                a(lower) = ")"c
            ElseIf a(lower) = ")"c Then
                a(lower) = "("c
            End If
            lower += 1
        End While
    End Sub

    Sub ReverseString(ByVal expn() As Char)
        Dim lower As Integer = 0
        Dim upper As Integer = expn.Length - 1
        Dim tempChar As Char
        While lower < upper
            tempChar = expn(lower)
            expn(lower) = expn(upper)
            expn(upper) = tempChar
            lower += 1
            upper -= 1
        End While
    End Sub

    ' Testing code.
    Sub Main5()
        Dim expn As String = "10+((3))*5/(16-4)"
        Dim value As String = InfixToPrefix(expn)
        Console.WriteLine("Infix Expn: " & expn)
        Console.WriteLine("Prefix Expn: " & value)
    End Sub

    '
    '	Infix Expn: 10+((3))*5/(16-4)
    '	Prefix Expn:  +10 * 3 / 5  - 16 4
    '

    Function StockSpanRange(ByVal arr() As Integer) As Integer()
        Dim SR(arr.Length - 1) As Integer
        SR(0) = 1
        For i As Integer = 1 To arr.Length - 1
            SR(i) = 1
            Dim j As Integer = i - 1
            While (j >= 0) AndAlso (arr(i) >= arr(j))
                SR(i) += 1
                j -= 1
            End While
        Next i
        Return SR
    End Function

    Function StockSpanRange2(ByVal arr() As Integer) As Integer()
        Dim stk As New Stack(Of Integer)()

        Dim SR(arr.Length - 1) As Integer
        stk.Push(0)
        SR(0) = 1
        For i As Integer = 1 To arr.Length - 1
            While stk.Count > 0 AndAlso arr(stk.Peek()) <= arr(i)
                stk.Pop()
            End While
            SR(i) = If(stk.Count = 0, (i + 1), (i - stk.Peek()))
            stk.Push(i)
        Next i
        Return SR
    End Function

    ' Testing code.
    Sub Main6()
        Dim arr() As Integer = {6, 5, 4, 3, 2, 4, 5, 7, 9}
        Dim value() As Integer = StockSpanRange(arr)
        Console.Write("StockSpanRange : ")
        For Each val As Integer In value
            Console.Write(val & " ")
        Next val
        Console.WriteLine()

        value = StockSpanRange2(arr)
        Console.Write("StockSpanRange : ")
        For Each val As Integer In value
            Console.Write(val & " ")
        Next val
        Console.WriteLine()
    End Sub

    '
    '	StockSpanRange : 1 1 1 1 1 4 6 8 9
    '	StockSpanRange : 1 1 1 1 1 4 6 8 9
    '

    Function GetMaxArea(ByVal arr() As Integer) As Integer
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

    Function GetMaxArea2(ByVal arr() As Integer) As Integer
        Dim size As Integer = arr.Length
        Dim stk As New Stack(Of Integer)()
        Dim maxArea As Integer = 0
        Dim top As Integer
        Dim topArea As Integer
        Dim i As Integer = 0
        While i < size
            While (i < size) AndAlso (stk.Count = 0 OrElse arr(stk.Peek()) <= arr(i))
                stk.Push(i)
                i += 1
            End While
            While stk.Count > 0 AndAlso (i = size OrElse arr(stk.Peek()) > arr(i))
                top = stk.Peek()
                stk.Pop()
                topArea = arr(top) * (If(stk.Count = 0, i, i - stk.Peek() - 1))
                If maxArea < topArea Then
                    maxArea = topArea
                End If
            End While
        End While
        Return maxArea
    End Function

    ' Testing code.
    Sub Main7()
        Dim arr() As Integer = {7, 6, 5, 4, 4, 1, 6, 3, 1}
        Dim value As Integer = GetMaxArea(arr)
        Console.WriteLine("GetMaxArea :: " & value)
        value = GetMaxArea2(arr)
        Console.WriteLine("GetMaxArea :: " & value)
    End Sub

    '
    '	GetMaxArea :: 20
    '	GetMaxArea :: 20
    '


    Sub StockAnalystAdd(ByVal stk As Stack(Of Integer), ByVal value As Integer)
        While stk.Count > 0 AndAlso stk.Peek() <= value
            stk.Pop()
        End While
        stk.Push(value)
    End Sub

    ' Testing code.
    Sub Main7a()
        Dim arr() As Integer = {20, 19, 10, 21, 40, 35, 39, 50, 45, 42}
        Dim stk As New Stack(Of Integer)()
        For i As Integer = arr.Length - 1 To 0 Step -1
            StockAnalystAdd(stk, arr(i))
        Next i
        Dim ele As Integer
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
    End Sub

    Sub SortedInsert(ByVal stk As Stack(Of Integer), ByVal element As Integer)
        Dim temp As Integer
        If stk.Count = 0 OrElse element > stk.Peek() Then
            stk.Push(element)
        Else
            temp = stk.Pop()
            SortedInsert(stk, element)
            stk.Push(temp)
        End If
    End Sub

    ' Testing code.
    Sub Main8()
        Dim stk As New Stack(Of Integer)()
        stk.Push(1)
        stk.Push(3)
        stk.Push(4)
        Dim ele As Integer
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()

        SortedInsert(stk, 2)
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
    End Sub
    '
    '4 3 1
    '4 3 2 1
    '

    Sub SortStack(ByVal stk As Stack(Of Integer))
        Dim temp As Integer
        If stk.Count > 0 Then
            temp = stk.Pop()
            SortStack(stk)
            SortedInsert(stk, temp)
        End If
    End Sub

    Sub SortStack2(ByVal stk As Stack(Of Integer))
        Dim temp As Integer
        Dim stk2 As New Stack(Of Integer)()
        While stk.Count > 0
            temp = stk.Pop()
            While (stk2.Count > 0) AndAlso (stk2.Peek() < temp)
                stk.Push(stk2.Pop())
            End While
            stk2.Push(temp)
        End While
        While stk2.Count > 0
            stk.Push(stk2.Pop())
        End While
    End Sub

    ' Testing code.
    Sub Main9()
        Dim stk As New Stack(Of Integer)()
        stk.Push(3)
        stk.Push(1)
        stk.Push(4)
        stk.Push(2)
        Dim ele As Integer
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
        SortStack(stk)
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()

        stk = New Stack(Of Integer)()
        stk.Push(3)
        stk.Push(1)
        stk.Push(4)
        stk.Push(2)
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
        SortStack2(stk)
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
    End Sub

    '
    '2 4 1 3
    '4 3 2 1
    '2 4 1 3
    '4 3 2 1
    '
    Sub BottomInsert(ByVal stk As Stack(Of Integer), ByVal element As Integer)
        Dim temp As Integer
        If stk.Count = 0 Then
            stk.Push(element)
        Else
            temp = stk.Pop()
            BottomInsert(stk, element)
            stk.Push(temp)
        End If
    End Sub

    ' Testing code.
    Sub Main10()
        Dim stk As New Stack(Of Integer)()
        stk.Push(1)
        stk.Push(2)
        stk.Push(3)
        Dim ele As Integer
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
        BottomInsert(stk, 4)
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
    End Sub

    '
    '3 2 1
    '3 2 1 4
    '

    Sub BottomInsert(Of T)(ByVal stk As Stack(Of T), ByVal value As T)
        If stk.Count = 0 Then
            stk.Push(value)
        Else

            Dim outVr As T = stk.Pop()
            BottomInsert(stk, value)
            stk.Push(outVr)
        End If
    End Sub

    Sub ReverseStack(Of T)(ByVal stk As Stack(Of T))
        If stk.Count = 0 Then
            Return
        Else

            Dim value As T = stk.Pop()
            ReverseStack(stk)
            BottomInsert(stk, value)
        End If
    End Sub

    Sub ReverseStack2(ByVal stk As Stack(Of Integer))
        Dim que As New Queue(Of Integer)()
        While stk.Count > 0
            que.Enqueue(stk.Pop())
        End While

        While que.Count <> 0
            stk.Push(que.Dequeue())
        End While
    End Sub

    Sub ReverseKElementInStack(ByVal stk As Stack(Of Integer), ByVal k As Integer)
        Dim que As New Queue(Of Integer)()
        Dim i As Integer = 0
        While stk.Count > 0 AndAlso i < k
            que.Enqueue(stk.Pop())
            i += 1
        End While
        While que.Count <> 0
            stk.Push(que.Dequeue())
        End While
    End Sub

    Sub ReverseQueue(ByVal que As Queue(Of Integer))
        Dim stk As New Stack(Of Integer)()
        While que.Count <> 0
            stk.Push(que.Dequeue())
        End While

        While stk.Count > 0
            que.Enqueue(stk.Pop())
        End While
    End Sub

    Sub ReverseKElementInQueue(ByVal que As Queue(Of Integer), ByVal k As Integer)
        Dim stk As New Stack(Of Integer)()
        Dim i As Integer = 0, diff As Integer, temp As Integer
        While que.Count > 0 AndAlso i < k
            stk.Push(que.Dequeue())
            i += 1
        End While
        While stk.Count > 0
            que.Enqueue(stk.Pop())
        End While
        diff = que.Count - k
        While diff > 0
            temp = que.Dequeue()
            que.Enqueue(temp)
            diff -= 1
        End While
    End Sub

    ' Testing code.
    Sub Main11()
        Dim stk As New Stack(Of Integer)()
        stk.Push(1)
        stk.Push(2)
        stk.Push(3)
        Dim ele As Integer
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
    End Sub

    ' 3 2 1

    ' Testing code.
    Sub Main12()
        Dim stk As New Stack(Of Integer)()
        stk.Push(1)
        stk.Push(2)
        stk.Push(3)
        stk.Push(4)
        Dim ele As Integer
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
        ReverseStack(stk)
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
        ReverseStack2(stk)
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
        ReverseKElementInStack(stk, 2)
        For Each ele In stk
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
    End Sub
    '
    '4 3 2 1
    '1 2 3 4
    '4 3 2 1
    '3 4 2 1
    '

    ' Testing code.
    Sub Main13()
        Dim que As New Queue(Of Integer)()
        que.Enqueue(1)
        que.Enqueue(2)
        que.Enqueue(3)
        Dim ele As Integer
        For Each ele In que
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()

        ReverseQueue(que)
        For Each ele In que
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
        ReverseKElementInQueue(que, 2)

        For Each ele In que
            Console.Write(ele & " ")
        Next ele
        Console.WriteLine()
    End Sub

    '
    '1 2 3
    '3 2 1
    '2 3 1
    '

    Function MaxDepthParenthesis(ByVal expn As String, ByVal size As Integer) As Integer
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

    Function MaxDepthParenthesis2(ByVal expn As String, ByVal size As Integer) As Integer
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

    ' Testing code.
    Sub Main14()
        Dim expn As String = "((((A)))((((BBB()))))()()()())"
        Dim size As Integer = expn.Length
        Console.WriteLine("Max depth parenthesis is " & MaxDepthParenthesis(expn, size))
        Console.WriteLine("Max depth parenthesis is " & MaxDepthParenthesis2(expn, size))
    End Sub

    '
    '	Max depth parenthesis is 6
    '	Max depth parenthesis is 6
    '

    Function LongestContBalParen(ByVal str As String, ByVal size As Integer) As Integer
        Dim stk As New Stack(Of Integer)()
        stk.Push(-1)
        Dim length As Integer = 0

        For i As Integer = 0 To size - 1
            If str.Chars(i) = "("c Then
                stk.Push(i)
            Else
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

    ' Testing code.
    Sub Main15()
        Dim expn As String = "())((()))(())()(()"
        Dim size As Integer = expn.Length
        Console.WriteLine("LongestContBalParen " & LongestContBalParen(expn, size))
    End Sub

    ' LongestContBalParen 12

    Function ReverseParenthesis(ByVal expn As String, ByVal size As Integer) As Integer
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
        While stk.Count <> 0
            If stk.Pop() = "("c Then
                openCount += 1
            Else
                closeCount += 1
            End If
        End While
        Dim reversal As Integer = CInt(Math.Truncate(Math.Ceiling(openCount / 2.0))) + CInt(Math.Truncate(Math.Ceiling(closeCount / 2.0)))
        Return reversal
    End Function

    ' Testing code.
    Sub Main16()
        Dim expn2 As String = ")(())((("
        Dim size As Integer = expn2.Length
        Dim value As Integer = ReverseParenthesis(expn2, size)
        Console.WriteLine("Reverse Parenthesis is : " & value)
    End Sub

    ' Reverse Parenthesis is : 3

    Function FindDuplicateParenthesis(ByVal expn As String, ByVal size As Integer) As Boolean
        Dim stk As New Stack(Of Char)()
        Dim ch As Char
        Dim count As Integer

        For i As Integer = 0 To size - 1
            ch = expn.Chars(i)
            If ch = ")"c Then
                count = 0
                While stk.Count <> 0 AndAlso stk.Peek() <> "("c
                    stk.Pop()
                    count += 1
                End While
                If count <= 1 Then
                    Return True
                End If
            Else
                stk.Push(ch)
            End If
        Next i
        Return False
    End Function

    ' Testing code.
    Sub Main17()
        Dim expn As String = "(((a+b))+c)"
        Dim size As Integer = expn.Length
        Dim value As Boolean = FindDuplicateParenthesis(expn, size)
        Console.WriteLine("Duplicate Found : " & value)
    End Sub

    ' Duplicate Found : True

    Sub PrintParenthesisNumber(ByVal expn As String, ByVal size As Integer)
        Dim ch As Char
        Dim stk As New Stack(Of Integer)()
        Dim output As String = ""
        Dim count As Integer = 1
        For i As Integer = 0 To size - 1
            ch = expn.Chars(i)
            If ch = "("c Then
                stk.Push(count)
                output &= count
                output &= " "
                count += 1
            ElseIf ch = ")"c Then
                output &= stk.Pop()
                output &= " "
            End If

        Next i
        Console.WriteLine("Parenthesis Count " & output)
    End Sub

    ' Testing code.
    Sub Main18()
        Dim expn1 As String = "(((a+(b))+(c+d)))"
        Dim expn2 As String = "(((a+b))+c)((("
        PrintParenthesisNumber(expn1, expn1.Length)
        PrintParenthesisNumber(expn2, expn2.Length)
    End Sub

    '
    '	Parenthesis Count 1 2 3 4 4 3 5 5 2 1
    '	Parenthesis Count 1 2 3 3 2 1 4 5 6
    '

    Sub NextLargerElement(ByVal arr() As Integer, ByVal size As Integer)
        Dim output(size - 1) As Integer
        Dim outIndex As Integer = 0
        Dim nextValue As Integer

        For i As Integer = 0 To size - 1
            nextValue = -1
            For j As Integer = i + 1 To size - 1
                If arr(i) < arr(j) Then
                    nextValue = arr(j)
                    Exit For
                End If
            Next j
            'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
            'ORIGINAL LINE: output[outIndex++] = next;
            output(outIndex) = nextValue
            outIndex += 1
        Next i
        For Each val As Integer In output
            Console.Write(val & " ")
        Next val
        Console.WriteLine()
    End Sub

    Sub NextLargerElement2(ByVal arr() As Integer, ByVal size As Integer)
        Dim stk As New Stack(Of Integer)()
        Dim output(size - 1) As Integer
        Dim index As Integer = 0
        Dim curr As Integer

        For i As Integer = 0 To size - 1
            curr = arr(i)
            ' stack always have values in decreasing order.
            While stk.Count > 0 AndAlso arr(stk.Peek()) <= curr
                index = stk.Pop()
                output(index) = curr
            End While
            stk.Push(i)
        Next i
        ' index which don't have any next Larger.
        While stk.Count > 0
            index = stk.Pop()
            output(index) = -1
        End While
        For Each val As Integer In output
            Console.Write(val & " ")
        Next val
        Console.WriteLine()
    End Sub

    Sub NextSmallerElement(ByVal arr() As Integer, ByVal size As Integer)
        Dim output(size - 1) As Integer
        For i As Integer = 0 To size - 1
            output(i) = -1
        Next i

        For i As Integer = 0 To size - 1
            For j As Integer = i + 1 To size - 1
                If arr(j) < arr(i) Then
                    output(i) = arr(j)
                    Exit For
                End If
            Next j
        Next i

        For Each val As Integer In output
            Console.Write(val & " ")
        Next val
        Console.WriteLine()
    End Sub


    Sub NextSmallerElement2(ByVal arr() As Integer, ByVal size As Integer)
        Dim stk As New Stack(Of Integer)()
        Dim output(size - 1) As Integer
        Dim curr, index As Integer
        For i As Integer = 0 To size - 1
            curr = arr(i)
            ' stack always have values in increasing order.
            While stk.Count > 0 AndAlso arr(stk.Peek()) > curr
                index = stk.Pop()
                output(index) = curr
            End While
            stk.Push(i)
        Next i
        ' index which don't have any next Smaller.
        While stk.Count > 0
            index = stk.Pop()
            output(index) = -1
        End While
        For Each val As Integer In output
            Console.Write(val & " ")
        Next val
        Console.WriteLine()
    End Sub

    ' Testing code.
    Sub Main19()
        Dim arr() As Integer = {13, 21, 3, 6, 20, 3}
        Dim size As Integer = arr.Length
        NextLargerElement(arr, size)
        NextLargerElement2(arr, size)
        NextSmallerElement(arr, size)
        NextSmallerElement2(arr, size)
    End Sub

    '
    '	21 -1 6 20 -1 -1
    '	21 -1 6 20 -1 -1
    '	3 3 -1 3 3 -1
    '	3 3 -1 3 3 -1
    '

    Sub NextLargerElementCircular(ByVal arr() As Integer, ByVal size As Integer)
        Dim output(size - 1) As Integer
        For i As Integer = 0 To size - 1
            output(i) = -1
        Next i
        For i As Integer = 0 To size - 1
            For j As Integer = 1 To size - 1
                If arr(i) < arr((i + j) Mod size) Then
                    output(i) = arr((i + j) Mod size)
                    Exit For
                End If
            Next j
        Next i

        For Each val As Integer In output
            Console.Write(val & " ")
        Next val
        Console.WriteLine()
    End Sub


    Sub NextLargerElementCircular2(ByVal arr() As Integer, ByVal size As Integer)
        Dim stk As New Stack(Of Integer)()
        Dim curr, index As Integer
        Dim output(size - 1) As Integer
        Dim i As Integer = 0
        While i < (2 * size - 1)
            curr = arr(i Mod size)
            ' stack always have values in decreasing order.
            While stk.Count > 0 AndAlso arr(stk.Peek()) <= curr
                index = stk.Pop()
                output(index) = curr
            End While
            stk.Push(i Mod size)
            i += 1
        End While
        ' index which don't have any next Larger.
        While stk.Count > 0
            index = stk.Pop()
            output(index) = -1
        End While
        For Each val As Integer In output
            Console.Write(val & " ")
        Next val
        Console.WriteLine()
    End Sub

    ' Testing code.
    Sub Main20()
        Dim arr() As Integer = {6, 3, 9, 8, 10, 2, 1, 15, 7}
        NextLargerElementCircular(arr, arr.Length)
        NextLargerElementCircular2(arr, arr.Length)
    End Sub

    ' 9 9 10 10 15 15 15 -1 9
    ' 9 9 10 10 15 15 15 -1 9

    Function IsKnown(ByVal relation(,) As Integer, ByVal a As Integer, ByVal b As Integer) As Boolean
        If relation(a, b) = 1 Then
            Return True
        End If
        Return False
    End Function

    Function FindCelebrity(ByVal relation(,) As Integer, ByVal count As Integer) As Integer
        Dim i, j As Integer
        Dim cel As Boolean = True
        For i = 0 To count - 1
            cel = True
            For j = 0 To count - 1
                If i <> j AndAlso (Not IsKnown(relation, j, i) OrElse IsKnown(relation, i, j)) Then
                    cel = False
                    Exit For
                End If
            Next j
            If cel = True Then
                Return i
            End If
        Next i
        Return -1
    End Function

    Function FindCelebrity2(ByVal relation(,) As Integer, ByVal count As Integer) As Integer
        Dim stk As New Stack(Of Integer)()
        Dim first As Integer = 0, second As Integer = 0
        For i As Integer = 0 To count - 1
            stk.Push(i)
        Next i
        first = stk.Pop()
        While stk.Count <> 0
            second = stk.Pop()
            If IsKnown(relation, first, second) Then
                first = second
            End If
        End While
        For i As Integer = 0 To count - 1
            If first <> i AndAlso IsKnown(relation, first, i) Then
                Return -1
            End If
            If first <> i AndAlso IsKnown(relation, i, first) = False Then
                Return -1
            End If
        Next i
        Return first
    End Function

    Function FindCelebrity3(ByVal relation(,) As Integer, ByVal count As Integer) As Integer
        Dim first As Integer = 0
        Dim second As Integer = 1

        Dim i As Integer = 0
        While i < (count - 1)
            If IsKnown(relation, first, second) Then
                first = second
            End If
            second = second + 1
            i += 1
        End While
        For i = 0 To count - 1
            If first <> i AndAlso IsKnown(relation, first, i) Then
                Return -1
            End If
            If first <> i AndAlso IsKnown(relation, i, first) = False Then
                Return -1
            End If
        Next i
        Return first
    End Function

    ' Testing code.
    Sub Main21()
        Dim arr(,) As Integer = {
            {1, 0, 1, 1, 0},
            {1, 0, 0, 1, 0},
            {0, 0, 1, 1, 1},
            {0, 0, 0, 0, 0},
            {1, 1, 0, 1, 1}
        }

        Console.WriteLine("Celebrity : " & FindCelebrity3(arr, 5))
        Console.WriteLine("Celebrity : " & FindCelebrity(arr, 5))
        Console.WriteLine("Celebrity : " & FindCelebrity2(arr, 5))
    End Sub

    '
    '	Celebrity : 3
    '	Celebrity : 3
    '	Celebrity : 3
    '
    '

    Function IsMinHeap(ByVal arr() As Integer, ByVal size As Integer) As Integer
        Dim i As Integer = 0
        While i <= (size - 2) \ 2
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
        End While
        Return 1
    End Function

    Function IsMaxHeap(ByVal arr() As Integer, ByVal size As Integer) As Integer
        Dim i As Integer = 0
        While i <= (size - 2) \ 2
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
        End While
        Return 1
    End Function

    Sub Main(ByVal args() As String)
        Main1()
        Main2()
        Main3()
        Main4()
        Main5()
        Main6()
        Main7()
        Main7a()
        Main8()
        Main9()
        Main10()
        Main11()
        Main12()
        Main13()
        Main14()
        Main15()
        Main16()
        Main17()
        Main18()
        Main19()
        Main20()
        Main21()
    End Sub
End Module
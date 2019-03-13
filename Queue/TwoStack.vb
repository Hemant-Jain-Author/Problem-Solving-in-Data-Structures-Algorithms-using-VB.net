Imports System

Public Class TwoStack
	Private ReadOnly MAX_SIZE As Integer = 50
	Friend top1 As Integer
	Friend top2 As Integer
	Friend data() As Integer

	Public Sub New()
		top1 = -1
		top2 = MAX_SIZE
		data = New Integer(MAX_SIZE - 1){}
	End Sub

	Public Shared Sub Main(ByVal args() As String)
		Dim st As New TwoStack()
		For i As Integer = 0 To 9
			st.StackPush1(i)
		Next i
		For j As Integer = 0 To 9
			st.StackPush2(j + 10)
		Next j
		For i As Integer = 0 To 9
			Console.WriteLine("stack one pop value is : " & st.StackPop1())
			Console.WriteLine("stack two pop value is : " & st.StackPop2())
		Next i
	End Sub

	Public Overridable Sub StackPush1(ByVal value As Integer)
		If top1 < top2 - 1 Then
			top1 += 1
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: data[++top1] = value;
			data(top1) = value
		Else
			Console.Write("Stack is Full!")
		End If
	End Sub

	Public Overridable Sub StackPush2(ByVal value As Integer)
		If top1 < top2 - 1 Then
			top2 -= 1
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: data[--top2] = value;
			data(top2) = value
		Else
			Console.Write("Stack is Full!")
		End If
	End Sub

	Public Overridable Function StackPop1() As Integer
		If top1 >= 0 Then
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: int value = data[top1--];
			Dim value As Integer = data(top1)
			top1 -= 1
			Return value
		Else
			Console.Write("Stack Empty!")
		End If
		Return -999
	End Function

	Public Overridable Function StackPop2() As Integer
		If top2 < MAX_SIZE Then
'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
'ORIGINAL LINE: int value = data[top2++];
			Dim value As Integer = data(top2)
			top2 += 1
			Return value
		Else
			Console.Write("Stack Empty!")
		End If
		Return -999
	End Function
End Class

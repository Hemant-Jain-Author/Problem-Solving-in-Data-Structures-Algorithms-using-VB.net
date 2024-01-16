Imports System

Public Class TwoStack
	Private ReadOnly MAX_SIZE As Integer = 50
	Private top1 As Integer
	Private top2 As Integer
	Private data() As Integer

	Public Sub New()
		top1 = -1
		top2 = MAX_SIZE
		data = New Integer(MAX_SIZE - 1){}
	End Sub

	Public Sub Push1(ByVal value As Integer)
		If top1 < top2 - 1 Then
			top1 += 1
			data(top1) = value
		Else
			Console.Write("Stack is Full!")
		End If
	End Sub

	Public Sub Push2(ByVal value As Integer)
		If top1 < top2 - 1 Then
			top2 -= 1
			data(top2) = value
		Else
			Console.Write("Stack is Full!")
		End If
	End Sub

	Public Function Pop1() As Integer
		If top1 >= 0 Then
			Dim value As Integer = data(top1)
			top1 -= 1
			Return value
		Else
			Console.Write("Stack Empty!")
		End If
		Return -999
	End Function

	Public Function Pop2() As Integer
		If top2 < MAX_SIZE Then
			Dim value As Integer = data(top2)
			top2 += 1
			Return value
		Else
			Console.Write("Stack Empty!")
		End If
		Return -999
	End Function
	
	Public Shared Sub Main(ByVal args() As String)
		Dim st As New TwoStack()
		st.Push1(1)
		st.Push1(2)
		st.Push1(3)
		st.Push2(11)
		st.Push2(22)
		st.Push2(33)
		Console.WriteLine("stk1 pop: " & st.Pop1())
		Console.WriteLine("stk1 pop: " & st.Pop1())
		Console.WriteLine("stk2 pop: " & st.Pop2())
		Console.WriteLine("stk2 pop: " & st.Pop2())
	End Sub
End Class

'
'stk1 pop: 3
'stk1 pop: 2
'stk2 pop: 33
'stk2 pop: 22
'

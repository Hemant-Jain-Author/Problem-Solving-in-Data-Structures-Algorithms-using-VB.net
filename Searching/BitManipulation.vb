Imports System

Public Module BitManipulation
Function AndEx(ByVal a As Integer, ByVal b As Integer) As Integer
    Return a And b
End Function

Function OrEx(ByVal a As Integer, ByVal b As Integer) As Integer
    Return a Or b
End Function

Function XorEx(ByVal a As Integer, ByVal b As Integer) As Integer
    Return a Xor b
End Function

Function LeftShiftEx(ByVal a As Integer) As Integer ' multiply by 2
    Return a << 1
End Function

Function RightShiftEx(ByVal a As Integer) As Integer ' divide by 2
    Return a >> 1
End Function

Function BitReversalEx(ByVal a As Integer) As Integer
    Return Not a
End Function

Function TwosComplementEx(ByVal a As Integer) As Integer
    Return -a
End Function

Function KthBitCheck(ByVal a As Integer, ByVal k As Integer) As Boolean
    Return (a And 1 << (k - 1)) > 0
End Function

Function KthBitSet(ByVal a As Integer, ByVal k As Integer) As Integer
    Return (a Or 1 << (k - 1))
End Function

Function KthBitReset(ByVal a As Integer, ByVal k As Integer) As Integer
    Return (a And Not (1 << (k - 1)))
End Function

Function KthBitToggle(ByVal a As Integer, ByVal k As Integer) As Integer
    Return (a Xor (1 << (k - 1)))
End Function

Function RightMostBit(ByVal a As Integer) As Integer
    Return a And -a
End Function

Function ResetRightMostBit(ByVal a As Integer) As Integer
    Return a And (a - 1)
End Function

Function IsPowerOf2(ByVal a As Integer) As Boolean
    If (a And (a - 1)) = 0 Then
        Return True
    Else
        Return False
    End If
End Function

Function CountBits(ByVal a As Integer) As Integer
    Dim count As Integer = 0
    While a > 0
        count += 1
        a = a And (a - 1) ' reset least significant bit.
    End While
    Return count
End Function

Sub Main(ByVal args() As String)
    Dim a As Integer = 4
    Dim b As Integer = 8

    Console.WriteLine(AndEx(a, b))
    Console.WriteLine(OrEx(a, b))
    Console.WriteLine(XorEx(a, b))
    Console.WriteLine(LeftShiftEx(a)) ' multiply by 2
    Console.WriteLine(RightShiftEx(a)) ' divide by 2
    Console.WriteLine(BitReversalEx(a))
    Console.WriteLine(TwosComplementEx(a))
    Console.WriteLine(KthBitCheck(a, 3))
    Console.WriteLine(KthBitSet(a, 2))
    Console.WriteLine(KthBitReset(a, 3))
    Console.WriteLine(KthBitToggle(a, 3))
    Console.WriteLine(RightMostBit(a))
    Console.WriteLine(ResetRightMostBit(a))
    Console.WriteLine(IsPowerOf2(a))

    For i As Integer = 0 To 9
        Console.WriteLine(i & " bit count : " & CountBits(i))
    Next i
End Sub
End Module

'
'0
'12
'12
'8
'2
'-5
'-4
'True
'6
'0
'0
'4
'0
'True
'

'
'0 bit count : 0
'1 bit count : 1
'2 bit count : 1
'3 bit count : 2
'4 bit count : 1
'5 bit count : 2
'6 bit count : 2
'7 bit count : 3
'8 bit count : 1
'9 bit count : 2
'
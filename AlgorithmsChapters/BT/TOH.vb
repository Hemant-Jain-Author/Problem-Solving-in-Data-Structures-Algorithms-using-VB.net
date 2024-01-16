Imports System

Public Module TOH
    Sub TOHUtil(ByVal num As Integer, ByVal from As Char, ByVal [to] As Char, ByVal temp As Char)
        If num < 1 Then
            Return
        End If

        TOHUtil(num - 1, from, temp, [to])
        Console.WriteLine("Move disk " & num & " from peg " & from & " to peg " & [to])
        TOHUtil(num - 1, temp, [to], from)
    End Sub

    Sub TOHSteps(ByVal num As Integer)
        Console.WriteLine("Moves involved in the Tower of Hanoi are :")
        TOHUtil(num, "A"c, "C"c, "B"c)
    End Sub

    ' Testing code.
    Sub Main(ByVal args As String())
        TOH.TOHSteps(3)
    End Sub
End Module

'
' Moves involved in the Tower of Hanoi are :
' Move disk 1 from peg A to peg C
' Move disk 2 from peg A to peg B
' Move disk 1 from peg C to peg B
' Move disk 3 from peg A to peg C
' Move disk 1 from peg B to peg A
' Move disk 2 from peg B to peg C
' Move disk 1 from peg A to peg C
'
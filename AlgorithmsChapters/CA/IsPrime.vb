Imports System

Public Module IsPrime
    Function TestPrime(ByVal n As Integer) As Boolean
        Dim answer As Boolean = If((n > 1), True, False)
        Dim i As Integer = 2

        While i * i <= n

            If n Mod i = 0 Then
                answer = False
                Exit While
            End If

            i += 1
        End While

        Return answer
    End Function

    Sub Main(ByVal args As String())
        Console.WriteLine(IsPrime.TestPrime(7))
    End Sub
End Module

' True

Imports System

Public Module CoinChange
    Function MinCoins(ByVal coins As Integer(), ByVal n As Integer, ByVal val As Integer) As Integer
        If val <= 0 Then
            Return 0
        End If

        Dim count As Integer = 0
        Array.Sort(coins)
        Dim i As Integer = n - 1
        While i >= 0 AndAlso val > 0
            If coins(i) <= val Then
                count += 1
                val -= coins(i)
            Else
                i -= 1
            End If
        End While
        Return If(val = 0, count, -1)
    End Function

Function MinCoins2(ByVal coins As Integer(), ByVal n As Integer, ByVal val As Integer) As Integer
    If val = 0 Then
        Return 0
    End If

    Dim count As Integer = Integer.MaxValue
    For i As Integer = 0 To n - 1
        If coins(i) <= val Then
            Dim subCount As Integer = MinCoins2(coins, n, val - coins(i))
            If subCount >= 0 Then
                count = Math.Min(count, subCount + 1)
            End If
        End If
    Next
    Return If(count <> Integer.MaxValue, count, -1)
End Function

Function MinCoinsTD(ByVal coins As Integer(), ByVal n As Integer, ByVal val As Integer) As Integer
    Dim count As Integer() = New Integer(val) {}
    For i As Integer = 0 To val
        count(i)= Integer.MaxValue
    Next i
    count(0) = 0 ' zero val need zero coins.
    Return MinCoinsTD(count, coins, n, val)
End Function

Private Shared Function MinCoinsTD(ByVal count As Integer(), ByVal coins As Integer(), ByVal n As Integer, ByVal val As Integer) As Integer
    ' Base Case
    If count(val) <> Integer.MaxValue Then
        Return count(val)
    End If

    ' Recursion
    For i As Integer = 0 To n - 1
        If coins(i) <= val Then ' check validity of a sub-problem.
            Dim subCount As Integer = MinCoinsTD(count, coins, n, val - coins(i))
            If subCount <> Integer.MaxValue Then
                count(val) = Math.Min(count(val), subCount + 1)
            End If
        End If
    Next

    Return count(val)
End Function


Function MinCoinsBU(ByVal coins As Integer(), ByVal n As Integer, ByVal val As Integer) As Integer
    Dim count As Integer() = New Integer(val + 1 - 1) {}
    For i As Integer = 0 To val
        count(i)= Integer.MaxValue
    Next i
    count(0) = 0 ' Base value.

    For i As Integer = 1 To val
        For j As Integer = 0 To n - 1
            If coins(j) <= i AndAlso count(i - coins(j)) <> Integer.MaxValue AndAlso count(i) > count(i - coins(j)) + 1 Then
                count(i) = count(i - coins(j)) + 1
            End If
        Next
    Next

    Return If((count(val) <> Integer.MaxValue), count(val), -1)
End Function

Function MinCoinsBU2(ByVal coins As Integer(), ByVal n As Integer, ByVal val As Integer) As Integer
    Dim count As Integer() = New Integer(val + 1 - 1) {}
    Dim cvalue As Integer() = New Integer(val + 1 - 1) {}
    For i As Integer = 0 To val
        count(i)= Integer.MaxValue
        cvalue(i)= Integer.MaxValue
    Next i
    count(0) = 0

    For i As Integer = 1 To val
        For j As Integer = 0 To n - 1
            If coins(j) <= i AndAlso count(i - coins(j)) <> Integer.MaxValue AndAlso count(i) > count(i - coins(j)) + 1 Then
                count(i) = count(i - coins(j)) + 1
                cvalue(i) = coins(j)
            End If
        Next
    Next

    If count(val) = Integer.MaxValue Then Return -1
    printCoins(cvalue, val)
    Return count(val)
End Function

Private Shared Sub printCoinsUtil(ByVal cvalue As Integer(), ByVal val As Integer)
    If val > 0 Then
        printCoinsUtil(cvalue, val - cvalue(val))
        Console.Write(cvalue(val))
        Console.Write(" ")
    End If
End Sub

Private Shared Sub printCoins(ByVal cvalue As Integer(), ByVal val As Integer)
    Console.Write("Coins are : ")
    printCoinsUtil(cvalue, val)
    Console.WriteLine()
End Sub

' Testing code.
Sub Main()
    Dim coins As Integer() = New Integer() {5, 6}
    Dim value As Integer = 16
    Dim n As Integer = coins.Length
    Console.WriteLine("Count is:" & MinCoins(coins, n, value))
    Console.WriteLine("Count is:" & MinCoins2(coins, n, value))
    Console.WriteLine("Count is:" & MinCoinsBU(coins, n, value))
    Console.WriteLine("Count is:" & MinCoinsBU2(coins, n, value))
    Console.WriteLine("Count is:" & MinCoinsTD(coins, n, value))
End Sub

End Module

' Count is:-1
' Count is:3
' Count is:3
' Coins are : 6 5 5 
' Count is:3
' Count is:3
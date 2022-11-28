Imports System

Public Module Knapsack
    Function MaxCost01Knapsack(ByVal wt As Integer(), ByVal cost As Integer(), ByVal capacity As Integer) As Integer
        Return MaxCost01KnapsackUtil(wt, cost, wt.Length, capacity)
    End Function

    Private Shared Function MaxCost01KnapsackUtil(ByVal wt As Integer(), ByVal cost As Integer(), ByVal n As Integer, ByVal capacity As Integer) As Integer
        ' Base Case
        If n = 0 OrElse capacity = 0 Then Return 0

        ' Return the maximum of two cases:
        ' (1) nth item is included
        ' (2) nth item is not included
        Dim first As Integer = 0
        If wt(n - 1) <= capacity Then first = cost(n - 1) + MaxCost01KnapsackUtil(wt, cost, n - 1, capacity - wt(n - 1))
        Dim second As Integer = MaxCost01KnapsackUtil(wt, cost, n - 1, capacity)
        Return Math.Max(first, second)
    End Function

    Function MaxCost01KnapsackTD(ByVal wt As Integer(), ByVal cost As Integer(), ByVal capacity As Integer) As Integer
        Dim n As Integer = wt.Length
        Dim dp As Integer(,) = New Integer(capacity + 1 - 1, n + 1 - 1) {}
        Return MaxCost01KnapsackTD(dp, wt, cost, n, capacity)
    End Function

    Private Shared Function MaxCost01KnapsackTD(ByVal dp As Integer(,), ByVal wt As Integer(), ByVal cost As Integer(), ByVal i As Integer, ByVal w As Integer) As Integer
        If w = 0 OrElse i = 0 Then Return 0
        If dp(w, i) <> 0 Then Return dp(w, i)

        ' Their are two cases:
        ' (1) ith item is included
        ' (2) ith item is not included
        Dim first As Integer = 0
        If wt(i - 1) <= w Then first = MaxCost01KnapsackTD(dp, wt, cost, i - 1, w - wt(i - 1)) + cost(i - 1)

        Dim second As Integer = MaxCost01KnapsackTD(dp, wt, cost, i - 1, w)
        dp(w, i) = Math.Max(first, second)
        Return dp(w, i)
    End Function

    Function MaxCost01KnapsackBU(ByVal wt As Integer(), ByVal cost As Integer(), ByVal capacity As Integer) As Integer
        Dim n As Integer = wt.Length
        Dim dp As Integer(,) = New Integer(capacity + 1 - 1, n + 1 - 1) {}

        ' Build table dp(, ) in bottom up approach.
        ' Weights considered against capacity.
        For w As Integer = 1 To capacity
            For i As Integer = 1 To n
                ' Their are two cases:
                ' (1) ith item is included
                ' (2) ith item is not included
                Dim first As Integer = 0
                If wt(i - 1) <= w Then first = dp(w - wt(i - 1), i - 1) + cost(i - 1)

                Dim second As Integer = dp(w, i - 1)
                dp(w, i) = Math.Max(first, second)
            Next
        Next
        PrintItems(dp, wt, cost, n, capacity)
        Return dp(capacity, n) ' Number of weights considered and final capacity.
    End Function

    Private Shared Sub PrintItems(ByVal dp As Integer(,), ByVal wt As Integer(), ByVal cost As Integer(), ByVal n As Integer, ByVal capacity As Integer)
        Dim totalCost As Integer = dp(capacity, n)
        Console.Write("Selected items are:")
        For i As Integer = n - 1 To 1 Step -1
            If totalCost <> dp(capacity, i - 1) Then
                Console.Write(" (wt:" & wt(i) & ", cost:" & cost(i) & ")")
                capacity -= wt(i)
                totalCost -= cost(i)
            End If
        Next
        Console.WriteLine()
    End Sub

    Function KS01UnboundBU(ByVal wt As Integer(), ByVal cost As Integer(), ByVal capacity As Integer) As Integer
        Dim n As Integer = wt.Length
        Dim dp As Integer() = New Integer(capacity + 1 - 1) {}

		' Build table dp[] in bottom up approach.
		' Weights considered against capacity.
        For w As Integer = 1 To capacity
            For i As Integer = 1 To n
				' Their are two cases:
				' (1) ith item is included 
				' (2) ith item is not included
				If wt(i - 1) <= w Then
                    dp(w) = Math.Max(dp(w), dp(w - wt(i - 1)) + cost(i - 1))
                End If
            Next
        Next

        Return dp(capacity)
    End Function

    Sub Main(ByVal args As String())
        Dim wt As Integer() = New Integer() {10, 40, 20, 30}
        Dim cost As Integer() = New Integer() {60, 40, 90, 120}
        Dim capacity As Integer = 50
        Dim maxCost As Double = MaxCost01Knapsack(wt, cost, capacity)
        Console.WriteLine("Maximum cost obtained = " & maxCost)
        maxCost = MaxCost01KnapsackBU(wt, cost, capacity)
        Console.WriteLine("Maximum cost obtained = " & maxCost)
        maxCost = MaxCost01KnapsackTD(wt, cost, capacity)
        Console.WriteLine("Maximum cost obtained = " & maxCost)
    End Sub
End Module

﻿Imports System

Public Module LargestBitonicSubseq
    Function LBS(ByVal arr() As Integer) As Integer
        Dim n As Integer = arr.Length
        Dim lis(n - 1) As Integer
        Dim lds(n - 1) As Integer
        For i As Integer = 0 To (n - 1) ' Initialize LIS and LDS values for all indexes as 1.
            lis(i)= 1
            lds(i)= 1
        Next i

        Dim max As Integer = 0

        ' Populating LIS values in bottom up manner.
        For i As Integer = 0 To n - 1
            For j As Integer = 0 To i - 1
                If arr(j) < arr(i) AndAlso lis(i) < lis(j) + 1 Then
                    lis(i) = lis(j) + 1
                End If
            Next j
        Next i

        ' Populating LDS values in bottom up manner.
        For i As Integer = n - 1 To 1 Step -1
            For j As Integer = n - 1 To i + 1 Step -1
                If arr(j) < arr(i) AndAlso lds(i) < lds(j) + 1 Then
                    lds(i) = lds(j) + 1
                End If
            Next j
        Next i
        For i As Integer = 0 To n - 1
            max = Math.Max(max, lis(i) + lds(i) - 1)
        Next i

        Return max
    End Function

    ' Testing code.
    Sub Main(ByVal args() As String)
        Dim arr() As Integer = {1, 6, 3, 11, 1, 9, 5, 12, 3, 14, 6, 17, 3, 19, 2, 19}
        Console.WriteLine("Length of LBS is " & LBS(arr))
    End Sub
End Module
'
'Length of LBS is 8
'
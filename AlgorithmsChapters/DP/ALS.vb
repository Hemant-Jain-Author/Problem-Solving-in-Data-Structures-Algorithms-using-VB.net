Imports System

Public Module ALS
    Function FastestWayBU2(ByVal a As Integer(,), ByVal t As Integer(,), ByVal e As Integer(), ByVal x As Integer(), ByVal n As Integer) As Integer
        Dim f1 As Integer() = New Integer(n - 1) {}
        Dim f2 As Integer() = New Integer(n - 1) {}
        f1(0) = e(0) + a(0, 0)
        f2(0) = e(1) + a(1, 0)

        For i As Integer = 1 To n - 1
            f1(i) = Math.Min(f1(i - 1) + a(0, i), f2(i - 1) + t(1, i - 1) + a(0, i))
            f2(i) = Math.Min(f2(i - 1) + a(1, i), f1(i - 1) + t(0, i - 1) + a(1, i))
        Next

        Return Math.Min(f1(n - 1) + x(0), f2(n - 1) + x(1))
    End Function

    Function FastestWayBU(ByVal a As Integer(,), ByVal t As Integer(,), ByVal e As Integer(), ByVal x As Integer(), ByVal n As Integer) As Integer
        Dim f As Integer(,) = New Integer(n - 1, n - 1) {}
        f(0, 0) = e(0) + a(0, 0)
        f(1, 0) = e(1) + a(1, 0)

        For i As Integer = 1 To n - 1
            f(0, i) = Math.Min(f(0, i - 1) + a(0, i), f(1, i - 1) + t(1, i - 1) + a(0, i))
            f(1, i) = Math.Min(f(1, i - 1) + a(1, i), f(0, i - 1) + t(0, i - 1) + a(1, i))
        Next

        Return Math.Min(f(0, n - 1) + x(0), f(1, n - 1) + x(1))
    End Function

    Function FastestWayTD(ByVal a As Integer(,), ByVal t As Integer(,), ByVal e As Integer(), ByVal x As Integer(), ByVal n As Integer) As Integer
        Dim f As Integer(,) = New Integer(n - 1, n - 1) {}
        f(0, 0) = e(0) + a(0, 0)
        f(1, 0) = e(1) + a(1, 0)
        FastestWayTD(f, a, t, n - 1)
        Return Math.Min(f(0, n - 1) + x(0), f(1, n - 1) + x(1))
    End Function

    Sub FastestWayTD(ByVal f As Integer(,), ByVal a As Integer(,), ByVal t As Integer(,), ByVal i As Integer)
        If i = 0 Then
            Return
        End If

        FastestWayTD(f, a, t, i - 1)
        f(0, i) = Math.Min(f(0, i - 1) + a(0, i), f(1, i - 1) + t(1, i - 1) + a(0, i))
        f(1, i) = Math.Min(f(1, i - 1) + a(1, i), f(0, i - 1) + t(0, i - 1) + a(1, i))
    End Sub

    Sub Main(ByVal args As String())
        Dim a As Integer(,) = New Integer(,) {
        {7, 9, 3, 4, 8, 4},
        {8, 5, 6, 4, 5, 7}}
        Dim t As Integer(,) = New Integer(,) {
        {2, 3, 1, 3, 4},
        {2, 1, 2, 2, 1}}
        Dim e As Integer() = New Integer() {2, 4}
        Dim x As Integer() = New Integer() {3, 2}
        Dim n As Integer = 6
        Console.WriteLine(FastestWayBU2(a, t, e, x, n))
        Console.WriteLine(FastestWayBU(a, t, e, x, n))
        Console.WriteLine(FastestWayTD(a, t, e, x, n))
    End Sub
End Module


'
'38
'38
'38
'
Imports System

Module Module1
    Public Function bruteForceSearch(ByVal text As String, ByVal pattern As String) As Integer
        Return bruteForceSearch(text.ToCharArray(), pattern.ToCharArray())
    End Function

    Private Function bruteForceSearch(ByVal text() As Char, ByVal pattern() As Char) As Integer
        Dim i As Integer = 0, j As Integer = 0
        Dim n As Integer = text.Length
        Dim m As Integer = pattern.Length

        Do While i <= n - m
            j = 0
            Do While j < m AndAlso pattern(j) = text(i + j)
                j += 1
            Loop
            If j = m Then
                Return (i)
            End If
            i += 1
        Loop
        Return -1
    End Function

    Public Function robinKarp(ByVal text As String, ByVal pattern As String) As Integer
        Return robinKarp(text.ToCharArray(), pattern.ToCharArray())
    End Function

    Private Function robinKarp(ByVal text() As Char, ByVal pattern() As Char) As Integer
        Dim n As Integer = text.Length
        Dim m As Integer = pattern.Length
        Dim i, j As Integer
        Dim prime As Integer = 101
        Dim powm As Integer = 1
        Dim TextHash As Integer = 0, PatternHash As Integer = 0
        If m = 0 OrElse m > n Then
            Return -1
        End If

        i = 0
        Do While i < m - 1
            powm = (powm << 1) Mod prime
            i += 1
        Loop

        For i = 0 To m - 1
            PatternHash = ((PatternHash << 1) + AscW(pattern(i))) Mod prime
            TextHash = ((TextHash << 1) + AscW(text(i))) Mod prime
        Next i

        i = 0
        Do While i <= (n - m)
            If TextHash = PatternHash Then
                For j = 0 To m - 1
                    If text(i + j) <> pattern(j) Then
                        Exit For
                    End If
                Next j
                If j = m Then
                    Return i
                End If
            End If
            TextHash = (((TextHash - AscW(text(i)) * powm) << 1) + AscW(text(i + m))) Mod prime
            If TextHash < 0 Then
                TextHash = (TextHash + prime)
            End If
            i += 1
        Loop
        Return -1
    End Function

    Private Sub KMPPreprocess(ByVal pattern() As Char, ByVal ShiftArr() As Integer)
        Dim m As Integer = pattern.Length
        Dim i As Integer = 0, j As Integer = -1
        ShiftArr(i) = -1
        Do While i < m
            Do While j >= 0 AndAlso pattern(i) <> pattern(j)
                j = ShiftArr(j)
            Loop
            i += 1
            j += 1
            ShiftArr(i) = j
        Loop
    End Sub

    Public Function KMP(ByVal text As String, ByVal pattern As String) As Integer
        Return KMP(text.ToCharArray(), pattern.ToCharArray())
    End Function

    Private Function KMP(ByVal text() As Char, ByVal pattern() As Char) As Integer
        Dim i As Integer = 0, j As Integer = 0
        Dim n As Integer = text.Length
        Dim m As Integer = pattern.Length
        Dim ShiftArr(m) As Integer
        KMPPreprocess(pattern, ShiftArr)

        Do While i < n
            Do While j >= 0 AndAlso text(i) <> pattern(j)
                j = ShiftArr(j)
            Loop
            i += 1
            j += 1
            If j = m Then
                Return (i - m)
            End If
        Loop
        Return -1
    End Function

    Public Function KMPFindCount(ByVal text() As Char, ByVal pattern() As Char) As Integer
        Dim i As Integer = 0, j As Integer = 0, count As Integer = 0
        Dim n As Integer = text.Length
        Dim m As Integer = pattern.Length
        Dim ShiftArr(m) As Integer
        KMPPreprocess(pattern, ShiftArr)

        Do While i < n
            Do While j >= 0 AndAlso text(i) <> pattern(j)
                j = ShiftArr(j)
            Loop
            i += 1
            j += 1
            If j = m Then
                count += 1
                j = ShiftArr(j)
            End If
        Loop
        Return count
    End Function

    Public Sub Main(ByVal args() As String)
        Dim st1 As String = "hello, world!"
        Dim st2 As String = "world"
        'INSTANT VB NOTE: The variable algo was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:

        Console.WriteLine("BruteForceSearch return : " & bruteForceSearch(st1, st2))
        Console.WriteLine("RobinKarp return : " & robinKarp(st1, st2))
        Console.WriteLine("KMP return : " & KMP(st1, st2))
    End Sub
End Module

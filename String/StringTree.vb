Imports System

Public Class StringTree
    Private root As Node = Nothing

    Private Class Node
        Friend value As String
        Friend count As Integer
        Friend lChild As Node
        Friend rChild As Node
    End Class

    ' Other Methods.
    Public Sub print()
        print(root)
    End Sub

    Private Sub print(ByVal curr As Node) ' pre order
        If curr IsNot Nothing Then
            Console.Write(" value is ::" & curr.value)
            Console.WriteLine(" count is :: " & curr.count)
            print(curr.lChild)
            print(curr.rChild)
        End If
    End Sub

    Public Sub add(ByVal value As String)
        root = add(value, root)
    End Sub

    Private Function add(ByVal value As String, ByVal curr As Node) As Node
        If curr Is Nothing Then
            curr = New Node()
            curr.value = value
            'INSTANT VB WARNING: An assignment within expression was extracted from the following statement:
            'ORIGINAL LINE: curr.lChild = curr.rChild = null;
            curr.rChild = Nothing
            curr.lChild = curr.rChild
            curr.count = 1
        Else
            Dim compare As Integer = curr.value.CompareTo(value)
            If compare = 0 Then
                curr.count += 1
            ElseIf compare = 1 Then
                curr.lChild = add(value, curr.lChild)
            Else
                curr.rChild = add(value, curr.rChild)
            End If
        End If
        Return curr
    End Function

    Public Function find(ByVal value As String) As Boolean
        Dim ret As Boolean = find(root, value)
        Console.WriteLine("Find " & value & " Return " & ret)
        Return ret
    End Function

    Private Function find(ByVal curr As Node, ByVal value As String) As Boolean
        If curr Is Nothing Then
            Return False
        End If
        Dim compare As Integer = curr.value.CompareTo(value)
        If compare = 0 Then
            Return True
        Else
            If compare = 1 Then
                Return find(curr.lChild, value)
            Else
                Return find(curr.rChild, value)
            End If
        End If
    End Function

    Public Function frequency(ByVal value As String) As Integer
        Return frequency(root, value)
    End Function

    Private Function frequency(ByVal curr As Node, ByVal value As String) As Integer
        If curr Is Nothing Then
            Return 0
        End If

        Dim compare As Integer = curr.value.CompareTo(value)
        If compare = 0 Then
            Return curr.count
        Else
            If compare > 0 Then
                Return frequency(curr.lChild, value)
            Else
                Return frequency(curr.rChild, value)
            End If
        End If
    End Function

    Public Sub freeTree()
        root = Nothing
    End Sub

End Class

Module Module1
    Public Sub Main(ByVal args() As String)
        Dim tt As New StringTree()
        tt.add("banana")
        tt.add("apple")
        tt.add("mango")
        tt.add("banana")
        tt.add("apple")
        tt.add("mango")
        Console.WriteLine(ControlChars.Lf & "Search results for apple, banana, grapes and mango :" & ControlChars.Lf)
        tt.find("apple")
        tt.find("banana")
        tt.find("banan")
        tt.find("applkhjkhkj")
        tt.find("grapes")
        tt.find("mango")
        tt.print()
        Console.WriteLine("frequency returned :: " & tt.frequency("apple"))
        Console.WriteLine("frequency returned :: " & tt.frequency("banana"))
        Console.WriteLine("frequency returned :: " & tt.frequency("mango"))
        Console.WriteLine("frequency returned :: " & tt.frequency("hemant"))
    End Sub
End Module
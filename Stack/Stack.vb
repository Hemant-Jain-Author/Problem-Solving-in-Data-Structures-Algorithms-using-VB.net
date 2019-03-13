Imports System
Imports System.Collections

Public Class Stack
    Private capacity As Integer = 1000
    Private data() As Integer
    Private top As Integer = -1

    Public Sub New()
        data = New Integer(capacity - 1) {}
    End Sub

    Public Sub New(ByVal size As Integer)
        data = New Integer(size - 1) {}
        capacity = size
    End Sub
    ' Other methods 

    Public Function size() As Integer
        Return (top + 1)
    End Function

    Public ReadOnly Property Empty() As Boolean
        Get
            Return (top = -1)
        End Get
    End Property

    Public Sub Push(ByVal value As Integer)
        If size() = data.Length Then
            Throw New System.InvalidOperationException("StackOvarflowException")
        End If
        top += 1
        data(top) = value
    End Sub

    Public Function Peek() As Integer
        If Empty Then
            Throw New System.InvalidOperationException("StackEmptyException")
        End If
        Return data(top)
    End Function

    Public Function Pop() As Integer
        If Empty Then
            Throw New System.InvalidOperationException("StackEmptyException")
        End If
        Dim topVal As Integer = data(top)
        top -= 1
        Return topVal
    End Function

    Public Sub Print()
        For i As Integer = top To 0 Step -1
            Console.Write(data(i) & " ")
        Next i
        Console.WriteLine("")
    End Sub
End Class

Module Module1
    Public Sub Main(ByVal args() As String)
        Dim s As New Stack()
        s.Push(1)
        s.Push(2)
        s.Push(3)
        s.Print()
        Console.WriteLine(s.Pop())
        s.Print()
    End Sub
End Module
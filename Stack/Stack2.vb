Imports System

Public Class Stack2
    Private data() As Integer
    Private top As Integer = -1
    Private minCapacity As Integer
    Private capacity As Integer

    Public Sub New()
        Me.New(1000)
    End Sub

    Public Sub New(ByVal size As Integer)
        data = New Integer(size - 1) {}
        minCapacity = size
        capacity = minCapacity
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
        If size() = capacity Then
            Console.WriteLine("size dubbelled")
            Dim newData((capacity * 2) - 1) As Integer
            Array.Copy(data, 0, newData, 0, capacity)
            data = newData
            capacity = capacity * 2
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
        If size() = capacity \ 2 AndAlso capacity > minCapacity Then
            Console.WriteLine("size halfed")
            capacity = capacity \ 2
            Dim newData(capacity - 1) As Integer
            Array.Copy(data, 0, newData, 0, capacity)
            data = newData
        End If
        Return topVal
    End Function

    Public Sub Print()
        For i As Integer = top To 0 Step -1
            Console.Write(" " & data(i))
        Next i
    End Sub
End Class


Module Module1
    Public Sub Main(ByVal args() As String)
        Dim s As New Stack2()
        s.Push(1)
        s.Push(2)
        s.Push(3)
        s.Print()
        Console.WriteLine(s.Pop())
        s.Print()
    End Sub
End Module
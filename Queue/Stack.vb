Imports System
Imports System.Collections.Generic

Public Class Stack
    Private que1 As Queue(Of Integer) = New Queue(Of Integer)()
    Private que2 As Queue(Of Integer) = New Queue(Of Integer)()
    Private size As Integer = 0

    Public Sub Push(ByVal value As Integer)
        que1.Enqueue(value)
        size += 1
    End Sub

    Public Function Pop() As Integer
        Dim value As Integer = 0, s As Integer = size

        While s > 0
            value = que1.Peek()
            que1.Dequeue()

            If s > 1 Then
                que2.Enqueue(value)
            End If

            s -= 1
        End While

        Dim temp As Queue(Of Integer) = que1
        que1 = que2
        que2 = temp
        size -= 1
        Return value
    End Function

    Public Function Pop2() As Integer
        Dim value As Integer = 0, s As Integer = size

        While s > 0
            value = que1.Peek()
            que1.Dequeue()

            If s > 1 Then
                que1.Enqueue(value)
            End If

            s -= 1
        End While

        size -= 1
        Return value
    End Function

    Public Shared Sub Main(ByVal args As String())
        Dim s As Stack = New Stack()
        s.Push(1)
        s.Push(2)
        s.Push(3)
        Console.WriteLine("Stack pop : " & s.Pop() & " ")
        Console.WriteLine("Stack pop : " & s.Pop() & " ")
    End Sub
End Class

' Stack pop : 3 
' Stack pop : 2 
Imports System

Public Class QueueLL
    Private tail As Node = Nothing
    Private count As Integer = 0

    Private Class Node
        Friend value As Integer
        Friend nextPtr As Node

        Friend Sub New(ByVal v As Integer, ByVal n As Node)
            value = v
            nextPtr = n
        End Sub
    End Class

    Public Function Size() As Integer
        Return count
    End Function

    Public Function IsEmpty() As Boolean
        Return count = 0
    End Function

    Public Function Peek() As Integer
        If IsEmpty() Then
            Throw New System.InvalidOperationException("StackEmptyException")
        End If

        Dim value As Integer

        If tail Is tail.nextPtr Then
            value = tail.value
        Else
            value = tail.nextPtr.value
        End If

        Return value
    End Function

    Public Sub Add(ByVal value As Integer)
        Dim temp As Node = New Node(value, Nothing)

        If tail Is Nothing Then
            tail = temp
            tail.nextPtr = tail
        Else
            temp.nextPtr = tail.nextPtr
            tail.nextPtr = temp
            tail = temp
        End If

        count += 1
    End Sub

    Public Function Remove() As Integer
        If count = 0 Then
            Throw New System.InvalidOperationException("StackEmptyException")
        End If

        Dim value As Integer = 0

        If tail Is tail.nextPtr Then
            value = tail.value
            tail = Nothing
        Else
            value = tail.nextPtr.value
            tail.nextPtr = tail.nextPtr.nextPtr
        End If
        count -= 1
        Return value
    End Function

    Public Sub Print()
        If count = 0 Then
            Console.Write("Queue is empty.")
            Return
        End If

        Dim temp As Node = tail.nextPtr
        Console.Write("Queue is : ")

        For i As Integer = 0 To count - 1
            Console.Write(temp.value & " ")
            temp = temp.nextPtr
        Next

        Console.WriteLine()
    End Sub

    Public Shared Sub Main(ByVal args As String())
        Dim que As QueueLL = New QueueLL()
        que.Add(1)
        que.Add(2)
        que.Add(3)
        Console.WriteLine("IsEmpty : " & que.IsEmpty())
        Console.WriteLine("Size : " & que.Size())
        Console.WriteLine("Queue remove : " & que.Remove())
        Console.WriteLine("Queue remove : " & que.Remove())
    End Sub
End Class

' IsEmpty : False
' Size : 3
' Queue remove : 1
' Queue remove : 2

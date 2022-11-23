Imports System

Public Class Queue
    Private capacity As Integer
    Private data As Integer()
    Private count As Integer = 0
    Private front As Integer = 0
    Private back As Integer = 0

    Public Sub New(ByVal Optional n As Integer = 1000)
        capacity = n
        data = New Integer(n - 1) {}
    End Sub


    Public Function Add(ByVal value As Integer) As Boolean
        If count >= capacity Then
            Console.WriteLine("Queue is full.")
            Return False
        Else
            count += 1
            data(back) = value
            back += 1
			back = back Mod capacity
        End If

        Return True
    End Function

    Public Function Remove() As Integer
        Dim value As Integer

        If count <= 0 Then
            Console.WriteLine("Queue is empty.")
            Return -999
        Else
            count -= 1
            front += 1
			front = front Mod capacity
        End If

        Return value
    End Function

    Public Function IsEmpty() As Boolean
        Return count = 0
    End Function

    Public Function Size() As Integer
        Return count
    End Function

    Public Sub Print()
        If count = 0 Then
            Console.Write("Queue is empty.")
            Return
        End If

        Dim temp As Integer = front
        Dim s As Integer = count
        Console.Write("Queue is : ")

        While s > 0
            s -= 1
            Console.Write(data(temp) & " ")
            temp = (System.Threading.Interlocked.Increment(temp)) Mod capacity
        End While

        Console.WriteLine()
    End Sub

    Public Shared Sub Main(ByVal args As String())
        Dim que As Queue = New Queue()
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
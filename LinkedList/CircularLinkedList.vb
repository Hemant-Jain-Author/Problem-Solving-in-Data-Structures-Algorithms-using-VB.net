
Imports System

Public Class CircularLinkedList
Private tail As Node
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
        Throw New System.InvalidOperationException("EmptyListException")
    End If
    Return tail.nextPtr.value
End Function

' Other methods

Public Sub AddTail(ByVal value As Integer)
    Dim temp As New Node(value, Nothing)
    If IsEmpty() Then
        tail = temp
        temp.nextPtr = temp
    Else
        temp.nextPtr = tail.nextPtr
        tail.nextPtr = temp
        tail = temp
    End If
    count += 1
End Sub

Public Sub AddHead(ByVal value As Integer)
    Dim temp As New Node(value, Nothing)
    If IsEmpty() Then
        tail = temp
        temp.nextPtr = temp
    Else
        temp.nextPtr = tail.nextPtr
        tail.nextPtr = temp
    End If
    count += 1
End Sub

Public Function RemoveHead() As Integer
    If IsEmpty() Then
        Throw New System.InvalidOperationException("EmptyListException")
    End If
    Dim value As Integer = tail.nextPtr.value
    If tail Is tail.nextPtr Then
        tail = Nothing
    Else
        tail.nextPtr = tail.nextPtr.nextPtr
    End If

    count -= 1
    Return value
End Function

Public Function DeleteNode(ByVal key As Integer) As Boolean
    If IsEmpty() Then
        Return False
    End If
    Dim prev As Node = tail
    Dim curr As Node = tail.nextPtr
    Dim head As Node = tail.nextPtr

    If curr.value = key Then ' head and single node case.
        If curr Is curr.nextPtr Then ' single node case
            tail = Nothing
        Else ' head case
            tail.nextPtr = tail.nextPtr.nextPtr
        End If
        Return True
    End If

    prev = curr
    curr = curr.nextPtr

    While curr IsNot head
        If curr.value = key Then
            If curr Is tail Then
                tail = prev
            End If
            prev.nextPtr = curr.nextPtr
            Return True
        End If
        prev = curr
        curr = curr.nextPtr
    End While

    Return False
End Function

Public Function CopyListReversed() As CircularLinkedList
    Dim cl As New CircularLinkedList()
    If tail Is Nothing Then
        Return cl
    End If
    Dim curr As Node = tail.nextPtr
    Dim head As Node = curr

    If curr IsNot Nothing Then
        cl.AddHead(curr.value)
        curr = curr.nextPtr
    End If
    While curr IsNot head
        cl.AddHead(curr.value)
        curr = curr.nextPtr
    End While
    Return cl
End Function

Public Function CopyList() As CircularLinkedList
    Dim cl As New CircularLinkedList()
    If tail Is Nothing Then
        Return cl
    End If
    Dim curr As Node = tail.nextPtr
    Dim head As Node = curr

    If curr IsNot Nothing Then
        cl.AddTail(curr.value)
        curr = curr.nextPtr
    End If
    While curr IsNot head
        cl.AddTail(curr.value)
        curr = curr.nextPtr
    End While
    Return cl
End Function

Public Function Search(ByVal data As Integer) As Boolean
    Dim temp As Node = tail
    For i As Integer = 0 To count - 1
        If temp.value = data Then
            Return True
        End If
        temp = temp.nextPtr
    Next i
    Return False
End Function

Public Sub DeleteList()
    tail = Nothing
    count = 0
End Sub

Public Sub Print()
    If IsEmpty() Then
        Console.WriteLine("Empty List.")
        Return
    End If
    Dim temp As Node = tail.nextPtr
    While temp IsNot tail
        Console.Write(temp.value & " ")
        temp = temp.nextPtr
    End While
    Console.WriteLine(temp.value)
End Sub

Public Shared Sub Main1()
    Dim ll As New CircularLinkedList()
    ll.AddHead(1)
    ll.AddHead(2)
    ll.AddHead(3)
    ll.Print()
    Console.WriteLine(ll.Size())
    Console.WriteLine(ll.IsEmpty())
    Console.WriteLine(ll.Peek())
    Console.WriteLine(ll.Search(3))
End Sub

'
'3 2 1
'3
'False
'3
'True
'

Public Shared Sub Main2()
    Dim ll As New CircularLinkedList()
    ll.AddTail(1)
    ll.AddTail(2)
    ll.AddTail(3)
    ll.Print()
End Sub

'
'	1 2 3
'

Public Shared Sub Main3()
    Dim ll As New CircularLinkedList()
    ll.AddHead(1)
    ll.AddHead(2)
    ll.AddHead(3)
    ll.Print()
    ll.RemoveHead()
    ll.Print()
    ll.DeleteNode(2)
    ll.Print()
    ll.DeleteList()
    ll.Print()
End Sub

'
'3 2 1
'2 1
'1
'Empty List.
'


Public Shared Sub Main4()
    Dim ll As New CircularLinkedList()
    ll.AddHead(1)
    ll.AddHead(2)
    ll.AddHead(3)
    ll.Print()
    Dim ll2 As CircularLinkedList = ll.CopyList()
    ll2.Print()
    Dim ll3 As CircularLinkedList = ll.CopyListReversed()
    ll3.Print()
End Sub

'
'	3 2 1
'	3 2 1
'	1 2 3
'

Public Shared Sub Main5()
    Dim ll As New CircularLinkedList()
    ll.AddHead(1)
    ll.AddHead(2)
    ll.AddHead(3)
    ll.Print()
    ll.DeleteNode(2)
    ll.Print()
End Sub

'
'	3 2 1
'	3 1
'

Public Shared Sub Main(ByVal args() As String)
    Main1()
    Main2()
    Main3()
    Main4()
    Main5()
End Sub
End Class
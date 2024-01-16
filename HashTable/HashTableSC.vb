Imports System

Public Class HashTableSC
    Private tableSize As Integer
    Private listArray As Node()

    Private Class Node
        Friend key As Integer
        Friend value As Integer
        Friend nextPtr As Node

        Public Sub New(ByVal k As Integer, ByVal v As Integer, ByVal n As Node)
            key = k
            value = v
            nextPtr = n
        End Sub
    End Class

    Public Sub New()
        tableSize = 512
        listArray = New Node(tableSize - 1) {}
		For i As Integer = 0 To tableSize - 1
			listArray(i) = Nothing
		Next i
    End Sub

    Private Function ComputeHash(ByVal key As Integer) As Integer ' division method
        Dim hashValue As Integer = key
        Return hashValue Mod tableSize
    End Function

    Public Sub Add(ByVal key As Integer, ByVal value As Integer)
        Dim index As Integer = ComputeHash(key)
        listArray(index) = New Node(key, value, listArray(index))
    End Sub

    Public Sub Add(ByVal value As Integer)
        Add(value, value)
    End Sub

    Public Function Remove(ByVal key As Integer) As Boolean
        Dim index As Integer = ComputeHash(key)
        Dim nextNode As Node, head As Node = listArray(index)

        If head IsNot Nothing AndAlso head.key = key Then
            listArray(index) = head.nextPtr
            Return True
        End If

        While head IsNot Nothing
            nextNode = head.nextPtr

            If nextNode IsNot Nothing AndAlso nextNode.key = key Then
                head.nextPtr = nextNode.nextPtr
                Return True
            Else
                head = nextNode
            End If
        End While

        Return False
    End Function

    Public Sub Print()
        Console.Write("Hash Table contains ::")

        For i As Integer = 0 To tableSize - 1
            Dim head As Node = listArray(i)

            While head IsNot Nothing
                Console.Write("(" & head.key & "=>" & head.value & ") ")
                head = head.nextPtr
            End While
        Next

        Console.WriteLine()
    End Sub

    Public Function Find(ByVal key As Integer) As Boolean
        Dim index As Integer = ComputeHash(key)
        Dim head As Node = listArray(index)

        While head IsNot Nothing
            If head.key = key Then
                Return True
            End If
            head = head.nextPtr
        End While

        Return False
    End Function

    Public Function GetVal(ByVal key As Integer) As Integer
        Dim index As Integer = ComputeHash(key)
        Dim head As Node = listArray(index)
        While head IsNot Nothing
            If head.key = key Then
                Return head.value
            End If
            head = head.nextPtr
        End While

        Return -1
    End Function

    Public Shared Sub Main(ByVal args As String())
        Dim ht As HashTableSC = New HashTableSC()
        ht.Add(1, 10)
        ht.Add(2, 20)
        ht.Add(3, 30)
        ht.Print()
        Console.WriteLine("Find key 2 : " & ht.Find(2))
        Console.WriteLine("Value at  key 2 : " & ht.GetVal(2))
        ht.Remove(2)
        Console.WriteLine("Find key 2 : " & ht.Find(2))
        ht.Print()
    End Sub
End Class

' Hash Table contains ::(1=>10) (2=>20) (3=>30) 
' Find key 2 : True
' Value at  key 2 : 20
' Find key 2 : False
' Hash Table contains ::(1=>10) (3=>30) 

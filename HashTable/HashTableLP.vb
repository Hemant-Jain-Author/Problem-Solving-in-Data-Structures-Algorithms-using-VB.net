Imports System

Public Class HashTableLP
    Private Shared EMPTY_VALUE As Integer = -1
    Private Shared DELETED_VALUE As Integer = -2
    Private Shared FILLED_VALUE As Integer = 0
    Private tableSize As Integer
    Private key As Integer()
    Private value As Integer()
    Private flag As Integer()

    Public Sub New(ByVal tSize As Integer)
        tableSize = tSize
        key = New Integer(tSize) {}
        value = New Integer(tSize) {}
        flag = New Integer(tSize) {}
        For i As Integer = 0 To tSize
			flag(i) = EMPTY_VALUE
		Next i    
    End Sub

    ' Other Methods

    Private Function ComputeHash(ByVal key As Integer) As Integer
        Return key Mod tableSize
    End Function

    Private Function ResolverFun(ByVal index As Integer) As Integer
        Return index
    End Function

    Private Function ResolverFun2(ByVal index As Integer) As Integer
        Return index * index
    End Function

    Public Function Add(ByVal ky As Integer, ByVal val As Integer) As Boolean
        Dim hashValue As Integer = ComputeHash(ky)

        For i As Integer = 0 To tableSize - 1

            If flag(hashValue) = EMPTY_VALUE OrElse flag(hashValue) = DELETED_VALUE Then
                key(hashValue) = ky
                value(hashValue) = val
                flag(hashValue) = FILLED_VALUE
                Return True
            End If

            hashValue += ResolverFun(i)
            hashValue = hashValue Mod tableSize
        Next

        Return False
    End Function

    Public Function Add(ByVal val As Integer) As Boolean
        Return Add(val, val)
    End Function

    Public Function Find(ByVal ky As Integer) As Boolean
        Dim hashValue As Integer = ComputeHash(ky)

        For i As Integer = 0 To tableSize - 1

            If flag(hashValue) = EMPTY_VALUE Then
                Return False
            End If

            If flag(hashValue) = FILLED_VALUE AndAlso key(hashValue) = ky Then
                Return True
            End If

            hashValue += ResolverFun(i)
            hashValue = hashValue Mod tableSize
        Next

        Return False
    End Function

    Public Function Get(ByVal ky As Integer) As Integer
        Dim hashValue As Integer = ComputeHash(ky)

        For i As Integer = 0 To tableSize - 1

            If flag(hashValue) = EMPTY_VALUE Then
                Return -1
            End If

            If flag(hashValue) = FILLED_VALUE AndAlso key(hashValue) = ky Then
                Return value(hashValue)
            End If

            hashValue += ResolverFun(i)
            hashValue = hashValue Mod tableSize
        Next

        Return -1
    End Function

    Public Function Remove(ByVal ky As Integer) As Boolean
        Dim hashValue As Integer = ComputeHash(ky)

        For i As Integer = 0 To tableSize - 1

            If flag(hashValue) = EMPTY_VALUE Then
                Return False
            End If

            If flag(hashValue) = FILLED_VALUE AndAlso key(hashValue) = ky Then
                flag(hashValue) = DELETED_VALUE
                Return True
            End If

            hashValue += ResolverFun(i)
            hashValue = hashValue Mod tableSize
        Next

        Return False
    End Function

    Public Sub Print()
        Console.Write("Hash Table contains :: ")

        For i As Integer = 0 To tableSize - 1

            If flag(i) = FILLED_VALUE Then
                Console.Write("(" & key(i) & "=>" & value(i) & ") ")
            End If
        Next

        Console.WriteLine()
    End Sub

    Public Shared Sub Main(ByVal args As String())
        Dim ht As HashTableLP = New HashTableLP(1000)
        ht.Add(1, 10)
        ht.Add(2, 20)
        ht.Add(3, 30)
        ht.Print()
        Console.WriteLine("Find key 2 : " & ht.Find(2))
        Console.WriteLine("Value at key 2 : " & ht.Get(2))
        ht.Remove(2)
        ht.Print()
        Console.WriteLine("Find key 2 : " & ht.Find(2))
    End Sub
End Class

Imports System
Imports System.Collections.Generic

Public Class TreeMapDemo
Public Shared Sub Main(ByVal args() As String)
    ' create a tree map.
    Dim tm As New SortedDictionary(Of String, Integer)()
    ' Put elements into the map
    tm("Apple") = 40
    tm("Banana") = 10
    tm("Mango") = 20

    Console.WriteLine("Size :: " & tm.Count)
    For Each key As String In tm.Keys
        Console.WriteLine(key & " cost :" & tm(key))
    Next key
    Console.WriteLine("Apple present ::" & tm.ContainsKey("Apple"))
    Console.WriteLine("Grapes present :: " & tm.ContainsKey("Grapes"))
End Sub
End Class

'
'Size :: 3
'Apple cost :40
'Banana cost :10
'Mango cost :20
'Apple present ::True
'Grapes present :: False
'
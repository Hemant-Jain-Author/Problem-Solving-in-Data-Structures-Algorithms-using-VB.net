Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Module Module1
	Public Sub Main(ByVal args() As String)
		Dim al As New List(Of Integer)()
		al.Add(1) ' add 1 to the end of the list
		al.Add(2) ' add 2 to the end of the list
		al.Add(3) ' add 3 to the end of the list
		al.Add(4) ' add 4 to the end of the list
		Console.Write("Contents of List after adding 1,2,3,4:")
		al.ForEach(AddressOf Console.Write)

		Console.WriteLine(ControlChars.Lf & "Contents of List at index 0:" & al(0))
		Console.WriteLine("List Size:" & al.Count) ' List size printed
		Console.WriteLine("List IsEmpty:" & (al.Count = 0))

		al.RemoveAt(al.Count - 1) ' last element of List is removed.
		Console.WriteLine(ControlChars.Lf & "List Size after element removed:" & al.Count)

		al.Clear() ' all the elements of List are removed.
		Console.WriteLine(ControlChars.Lf & "List IsEmpty after clear:" & (al.Count = 0))
	End Sub


	'
	' Contents of List after adding 1,2,3,4:1234
	'Contents of List at index 0:1
	'List Size:4
	'List IsEmpty:False
	'
	'List Size after element removed:3
	'
	'List IsEmpty after clear:True
	'

End Module
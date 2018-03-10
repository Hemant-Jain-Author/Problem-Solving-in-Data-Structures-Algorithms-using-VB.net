Public Class CircularLinkedListDemo
	Public Shared Sub Main(ByVal args() As String)
		Dim ll As New CircularLinkedList()
		ll.addHead(1)
		ll.addHead(2)
		ll.addHead(3)
		ll.addHead(1)
		ll.addHead(2)
		ll.addHead(3)
		ll.print()
	End Sub
End Class

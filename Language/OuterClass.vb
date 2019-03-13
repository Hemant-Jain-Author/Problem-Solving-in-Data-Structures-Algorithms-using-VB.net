Public Class OuterClass

	Public Module NestedClass

		' NestedClass fields and methods.
	End Module

	' OuterClass fields and methods.
End Class

Public Class LinkedList
	Private Class Node
		Friend value As Integer
		Friend [next] As Node
		' Nested Class Node other fields and methods.
	End Class

	Private head As Node
	' Outer Class LinkedList other fields and methods.
End Class

Public Class Tree
	Private Class Node
		Private value As Integer
		Private lChild As Node
		Private rChild As Node
		' Nested Class Node other fields and methods.	
	End Class

	Private root As Node
	' Outer Class Tree other fields and methods.
End Class

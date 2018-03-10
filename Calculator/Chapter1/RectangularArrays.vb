Friend Module RectangularArrays
	Friend Function ReturnRectangularIntArray(ByVal size1 As Integer, ByVal size2 As Integer) As Integer()()
		Dim newArray(size1 - 1)() As Integer
		For array1 As Integer = 0 To size1 - 1
			newArray(array1) = New Integer(size2 - 1){}
		Next array1

		Return newArray
	End Function
End Module
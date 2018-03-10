Imports System

Public Class ArrayDemo

	Friend numbers() As Integer
	Public Sub New()
		numbers = New Integer(99){}
	End Sub
	Public Overridable Sub addValue(ByVal index As Integer, ByVal data As Integer)
		numbers(index) = data
	End Sub

	Public Overridable Function getValue(ByVal index As Integer) As Integer
		Return numbers(index)
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim d As New ArrayDemo()
		d.addValue(0, 1)
		d.addValue(1, 2)
		Console.WriteLine(d.getValue(0))
		Console.WriteLine(d.getValue(1))
	End Sub
End Class

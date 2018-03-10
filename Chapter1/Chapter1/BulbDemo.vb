Imports System

Friend Class Bulb2
	'Class Variables 
	Private Shared TotalBulbCount As Integer = 0

	'Instance Variables 
	Private isOn_variable As Boolean = False

	'Constructor
	Public Sub New()
		TotalBulbCount += 1
	End Sub

	'Class Method
	Public Shared ReadOnly Property BulbCount() As Integer
		Get
			Return TotalBulbCount
		End Get
	End Property

	'Instance Method
	Public Overridable Sub turnOn()
		isOn_variable = True
	End Sub

	'Instance Method
	Public Overridable Sub turnOff()
		isOn_variable = False
	End Sub
	'Instance Method
	Public Overridable ReadOnly Property IsOn() As Boolean
		Get
			Return isOn_variable
		End Get
	End Property
End Class

Public Class BulbDemo2
    Public Shared Sub Main121(ByVal args() As String)
        Dim b As New Bulb2()
        Dim c As New Bulb2()
        Console.WriteLine("Bulb Count :" & Bulb2.BulbCount)
    End Sub
End Class




Friend Class Bulb4
    Friend Enum BulbSize
        SMALL
        MEDIUM
        LARGE
    End Enum 'Enums
    Friend size As BulbSize
    'Other bulb class fields and methods.
End Class


Public Class BulbDemo4
    Public Shared Sub Main3232(ByVal args() As String)
        Dim b As New Bulb4()
        b.size = Bulb4.BulbSize.MEDIUM
        Console.WriteLine("Bulb Size :" & b.size.ToString())
    End Sub
End Class
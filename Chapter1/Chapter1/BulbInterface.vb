Public Interface BulbInterface
	Sub turnOn()
	Sub turnOff()
	ReadOnly Property IsOn() As Boolean
End Interface

'implements BulbInterface
Public Class Bulb
	Implements BulbInterface

	'Instance Variables 
	Private isOn_variable As Boolean = False

	'Instance Method
	Public Overridable Sub turnOn() Implements BulbInterface.turnOn
		isOn_variable = True
	End Sub

	'Instance Method
	Public Overridable Sub turnOff() Implements BulbInterface.turnOff
		isOn_variable = False
	End Sub

	'Instance Method
	Public Overridable ReadOnly Property IsOn() As Boolean Implements BulbInterface.IsOn
		Get
			Return isOn_variable
		End Get
	End Property
End Class


Public Class AdvanceBulb
	Inherits Bulb
	Implements BulbInterface

	'Instance Variables
	Private intensity As Integer

	'Instance Method
	Public Overridable Property Intersity() As Integer
		Get
			Return Intersity
		End Get
		Set(ByVal value As Integer)
			intensity = value
		End Set
	End Property
End Class

Public Class BulbDemo
    Public Shared Sub Main7676(ByVal args() As String)
        Dim b As New Bulb()
        Console.WriteLine("Bulb isOn :" & b.IsOn)
        b.turnOn()
        Console.WriteLine("Bulb isOn :" & b.IsOn)
    End Sub
End Class
Public Interface BulbInterface
	Sub turnOn()
	Sub turnOff()
	ReadOnly Property IsOn() As Boolean
End Interface

'implements BulbInterface
Public Class Bulb
	Implements BulbInterface

	'Instance Variables 
'INSTANT VB NOTE: The field isOn was renamed since Visual Basic does not allow fields to have the same name as methods:
	Private isOn_Renamed As Boolean = False

	'Instance Method
	Public Overridable Sub turnOn() Implements BulbInterface.turnOn
		isOn_Renamed = True
	End Sub

	'Instance Method
	Public Overridable Sub turnOff() Implements BulbInterface.turnOff
		isOn_Renamed = False
	End Sub

	'Instance Method
	Public Overridable ReadOnly Property IsOn() As Boolean Implements BulbInterface.IsOn
		Get
			Return isOn_Renamed
		End Get
	End Property
End Class





Public Class AdvanceBulb
	Inherits Bulb

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

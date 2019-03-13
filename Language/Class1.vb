Public Class Bulb3
	Private isOn As Boolean = False

	Public Overridable Sub turnOn()
		isOn = True
	End Sub

	Public Overridable Sub turnOff()
		isOn = False
	End Sub
End Class

﻿Imports System

Friend Class Bulb2
	'Class Variables 
	Private Shared TotalBulbCount As Integer = 0

	'Instance Variables 
'INSTANT VB NOTE: The field isOn was renamed since Visual Basic does not allow fields to have the same name as methods:
	Private isOn_Renamed As Boolean = False

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
		isOn_Renamed = True
	End Sub

	'Instance Method
	Public Overridable Sub turnOff()
		isOn_Renamed = False
	End Sub
	'Instance Method
	Public Overridable ReadOnly Property IsOn() As Boolean
		Get
			Return isOn_Renamed
		End Get
	End Property
End Class



Public Class BulbDemo
	Public Shared Sub Main(ByVal args() As String)
		Dim b As New Bulb2()
		Dim c As New Bulb2()
		Console.WriteLine("Bulb Count :" & Bulb2.BulbCount)
	End Sub
End Class
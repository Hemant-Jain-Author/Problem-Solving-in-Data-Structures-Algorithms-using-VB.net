Imports System

'Abstract Class
Public MustInherit Class Shape
	'Abstract Method
	Public MustOverride Function area() As Double

	'Abstract Method
	Public MustOverride Function perimeter() As Double
End Class

Public Class Rectangle
	Inherits Shape

'INSTANT VB NOTE: The field width was renamed since Visual Basic does not allow fields to have the same name as methods:
'INSTANT VB NOTE: The field length was renamed since Visual Basic does not allow fields to have the same name as methods:
	Private width_Renamed, length_Renamed As Double

	Public Sub New()
		Me.New(1, 1)
	End Sub

	Public Sub New(ByVal w As Double, ByVal l As Double)
		width_Renamed = w
		length_Renamed = l
	End Sub

	Public Overridable WriteOnly Property Width() As Double
		Set(ByVal value As Double)
			width_Renamed = value
		End Set
	End Property

	Public Overridable WriteOnly Property Length() As Double
		Set(ByVal value As Double)
			length_Renamed = value
		End Set
	End Property

	Public Overrides Function area() As Double
		' Area = width * length
		Return width_Renamed * length_Renamed
	End Function

	Public Overrides Function perimeter() As Double
		' Perimeter = 2(width + length)
		Return 2 * (width_Renamed + length_Renamed)
	End Function
End Class

Public Class Circle
	Inherits Shape

'INSTANT VB NOTE: The field radius was renamed since Visual Basic does not allow fields to have the same name as methods:
	Private radius_Renamed As Double

	Public Sub New()
		Me.New(1)
	End Sub

	Public Sub New(ByVal r As Double)
		radius_Renamed = r
	End Sub

	Public Overridable WriteOnly Property Radius() As Double
		Set(ByVal value As Double)
			radius_Renamed = value
		End Set
	End Property

	Public Overrides Function area() As Double
		' Area = πr^2
		Return Math.PI * Math.Pow(radius_Renamed, 2)
	End Function

	Public Overrides Function perimeter() As Double
		' Perimeter = 2πr
		Return 2 * Math.PI * radius_Renamed
	End Function
End Class

Public Class ShapeDemo
	Public Shared Sub Main(ByVal args() As String)

		Dim width As Double = 2, length As Double = 3
		Dim rectangle As Shape = New Rectangle(width, length)
		Console.WriteLine("Rectangle width: " & width & " and length: " & length & " Area: " & rectangle.area() & " Perimeter: " & rectangle.perimeter())

		Dim radius As Double = 10
		Dim circle As Shape = New Circle(radius)
		Console.WriteLine("Circle radius: " & radius & " Area: " & circle.area() & " Perimeter: " & circle.perimeter())

	End Sub
End Class

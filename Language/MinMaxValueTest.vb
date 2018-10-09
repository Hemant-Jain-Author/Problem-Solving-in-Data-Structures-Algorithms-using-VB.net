Imports System

Public Class MinMaxValueTest

	Public Shared Sub Main33(ByVal args() As String)

		Dim maxByte As SByte = SByte.MaxValue
		Dim minByte As SByte = SByte.MinValue

		Dim maxShort As Short = Short.MaxValue
		Dim minShort As Short = Short.MinValue

		Dim maxInteger As Integer = Integer.MaxValue
		Dim minInteger As Integer = Integer.MinValue

		Dim maxLong As Long = Long.MaxValue
		Dim minLong As Long = Long.MinValue

		Dim maxFloat As Single = Single.MaxValue
		Dim minFloat As Single = Single.Epsilon

		Dim maxDouble As Double = Double.MaxValue
		Dim minDouble As Double = Double.Epsilon

		Console.WriteLine("Range of byte :: " & minByte & " to " & maxByte & ".")
		Console.WriteLine("Range of short :: " & minShort & " to " & maxShort & ".")
		Console.WriteLine("Range of integer :: " & minInteger & " to " & maxInteger & ".")
		Console.WriteLine("Range of long :: " & minLong & " to " & maxLong & ".")
		Console.WriteLine("Range of float :: " & minFloat & " to " & maxFloat & ".")
		Console.WriteLine("Range of double :: " & minDouble & " to " & maxDouble & ".")
	End Sub
End Class
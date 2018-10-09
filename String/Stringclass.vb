Imports System

Public Class Stringclass

	Public Sub New()
		'string text = "Hello, World!";

		Dim str1 As String = "hello"
		Dim str2 As String = "hello"
		Dim str3 As String = "Hello"

		Console.WriteLine("str1 equals str2 :" & str1.Equals(str2))
		Console.WriteLine("str1 equals str3 :" & str1.Equals(str3))

	End Sub

	Sub demo()
		Dim str1 As String = "hello"
		Dim str2 As String = "hello"
		Dim str3 As String = "Hello"

		Console.WriteLine("str1 equals str2 :" & str1.Equals(str2))
		Console.WriteLine("str1 equals str3 :" & str1.Equals(str3))

	End Sub


	Public Shared Sub Main(ByVal args() As String)
		Dim text As String = "Hello, World!"
		Console.WriteLine(text.Chars(7))

		Dim array() As Char = text.ToCharArray()

		Console.WriteLine(text.Chars(7))

		Dim arr() As Char = {"H"c, "e"c, "l"c, "l"c, "o"c, ","c, " "c, "W"c, "o"c, "r"c, "l"c, "d"c, "!"c}


		Dim hello As New String(arr)

		Dim first As String = "Hello, "
		Dim second As String = "World!"
		'String helloworld = first + second;
		Dim helloworld As String = first & second

	End Sub
End Class

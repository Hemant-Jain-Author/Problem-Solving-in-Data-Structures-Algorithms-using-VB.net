Imports System

Public Class Stringclass

	Public Shared Sub Main(ByVal args() As String)
		Dim str1 As String = "hello"
		Dim str2 As String = "hello"
		Dim str3 As String = "Hello"
		Console.WriteLine("str1 equals str2 :" & str1.Equals(str2))
		Console.WriteLine("str1 equals str3 :" & str1.Equals(str3))

	End Sub
End Class
'
'str1 equals str2 :True
'str1 equals str3 :False
'

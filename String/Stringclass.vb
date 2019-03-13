Imports System

Module Module1
    Public Sub main1()
        'string text = "Hello, World!";

        Dim str1 As String = "hello"
        Dim str2 As String = "hello"
        Dim str3 As String = "Hello"

        Console.WriteLine("str1 equals str2 :" & str1.Equals(str2))
        Console.WriteLine("str1 equals str3 :" & str1.Equals(str3))

    End Sub

    Friend Sub main2()
        Dim str1 As String = "hello"
        Dim str2 As String = "hello"
        Dim str3 As String = "Hello"

        Console.WriteLine("str1 equals str2 :" & str1.Equals(str2))
        Console.WriteLine("str1 equals str3 :" & str1.Equals(str3))

    End Sub


    Friend Sub main3()
        'string str;
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

    Sub Main()
        main1()
        main2()
        main3()

    End Sub
End Module


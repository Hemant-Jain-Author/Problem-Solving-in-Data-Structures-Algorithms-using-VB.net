Imports System

Public Class Introduction
	'public static void Main(string[] args)
	'{
	'	twoDArrayExample();
	'}

	'public static void twoDArrayExample()
	'{
	'	//ORIGINAL LINE: int[][] arr = new int[4][2];
	'	int[][] arr = TwoDArrays.Init(4, 2);
	'	int count = 0;
	'	for (int i = 0; i < 4; i++)
	'	{
	'		for (int j = 0; j < 2; j++)
	'		{
	'			arr[i][j] = count++;
	'		}
	'	}

	'	print2DArray(arr, 4, 2);
	'}

	Public Shared Sub print2DArray(ByVal arr()() As Integer, ByVal row As Integer, ByVal col As Integer)
		For i As Integer = 0 To row - 1
			For j As Integer = 0 To col - 1
				Console.WriteLine(" " & arr(i)(j))
			Next j
		Next i
	End Sub
	Public Shared Function TwoDArraysInit(ByVal size1 As Integer, ByVal size2 As Integer) As Integer()()
		Dim newArray(size1 - 1)() As Integer
		For array1 As Integer = 0 To size1 - 1
			newArray(array1) = New Integer(size2 - 1){}
		Next array1

		Return newArray
	End Function
End Class


Friend Module TwoDArrays
	Friend Function TwoDArraysInit(ByVal size1 As Integer, ByVal size2 As Integer) As Integer()()
		Dim newArray(size1 - 1)() As Integer
		For array1 As Integer = 0 To size1 - 1
			newArray(array1) = New Integer(size2 - 1){}
		Next array1

		Return newArray
	End Function
End Module

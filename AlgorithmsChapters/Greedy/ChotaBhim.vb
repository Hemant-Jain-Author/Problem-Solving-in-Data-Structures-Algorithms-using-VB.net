Imports System

Public Class ChotaBhim
	Public Shared Function TotalQuantity(ByVal cups() As Integer, ByVal size As Integer) As Integer
		Dim time As Integer = 60
		Array.Sort(cups)
		Dim total As Integer = 0
		Dim index, temp As Integer
		Do While time > 0
			total += cups(0)
			cups(0) = CInt(Math.Truncate(Math.Ceiling(cups(0) / 2.0)))
			index = 0
			temp = cups(0)
			Do While index < size - 1 AndAlso temp < cups(index + 1)
				cups(index) = cups(index + 1)
				index += 1
			Loop
			cups(index) = temp
			time -= 1
		Loop
		Console.WriteLine("Total : " & total)
		Return total
	End Function

	Public Shared Function TotalQuantity2(ByVal cups() As Integer, ByVal size As Integer) As Integer
		Dim time As Integer = 60
		Dim pq As New PriorityQueue(Of Integer)(False)
		Dim i As Integer = 0
		For i = 0 To size - 1
			pq.Add(cups(i))
		Next i

		Dim total As Integer = 0
		Dim value As Integer
		Do While time > 0
			value = pq.Remove()
			total += value
			value = CInt(Math.Truncate(Math.Ceiling(value / 2.0)))
			pq.Add(value)
			time -= 1
		Loop
		Console.WriteLine("Total : " & total)
		Return total
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim cups() As Integer = {2, 1, 7, 4, 2}
		ChotaBhim.TotalQuantity(cups, cups.Length)
		Dim cups2() As Integer = {2, 1, 7, 4, 2}
		ChotaBhim.TotalQuantity2(cups2, cups.Length)
	End Sub

'	
'	 * Total : 76 
'	 * Total : 76 
'	 
End Class


Imports System

Public Class JoinRopes
	Public Shared Function Join(ByVal ropes() As Integer, ByVal size As Integer) As Integer
		Array.Sort(ropes)
		Dim i As Integer = 0
		Dim j As Integer = size - 1
		Do While i < j
			Dim temp As Integer = ropes(i)
			ropes(i) = ropes(j)
			ropes(j) = temp
			i += 1
			j -= 1
		Loop
		Dim total As Integer = 0
		Dim value As Integer = 0
		Dim index As Integer
		Dim length As Integer = size

		Do While length >= 2
			value = ropes(length - 1) + ropes(length - 2)
			total += value
			index = length - 2
			Do While index > 0 AndAlso ropes(index - 1) < value
				ropes(index) = ropes(index - 1)
				index -= 1
			Loop
			ropes(index) = value
			length -= 1
		Loop
		Console.WriteLine("Total : " & total)
		Return total
	End Function

	Public Shared Function Join2(ByVal ropes() As Integer, ByVal size As Integer) As Integer
		Dim pq As New PriorityQueue(Of Integer)()
		Dim i As Integer = 0
		For i = 0 To size - 1
			pq.Add(ropes(i))
		Next i

		Dim total As Integer = 0
		Dim value As Integer = 0
		Do While pq.Size() > 1
			value = pq.Remove()
			value += pq.Remove()
			pq.Add(value)
			total += value
		Loop
		Console.WriteLine("Total : " & total)
		Return total
	End Function

	Public Shared Sub Main(ByVal args() As String)
		Dim ropes() As Integer = {4, 3, 2, 6}
		JoinRopes.Join(ropes, ropes.Length)
		Dim rope2() As Integer = {4, 3, 2, 6}
		JoinRopes.Join2(rope2, rope2.Length)
	End Sub

'	
'	 * Total : 29 
'	 * Total : 29
'	 
End Class

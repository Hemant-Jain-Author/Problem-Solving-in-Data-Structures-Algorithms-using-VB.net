Imports System.Collections.Generic

Public Class Space
	Private temp As Integer
End Class

Public Class parkingLot
	Private unreservedMap As IDictionary(Of Integer, Space)
	Private reservedMap As IDictionary(Of Integer, Space)

	Public Overridable Function reserveSpace(ByVal sp As Space) As Boolean



		'It will find if there is space in the 
		'unreserved map 
		'If yes, then we will pick that element and 
		'put into the reserved map with the current time value.
	End Function

	Public Overridable Function unreserveSpace(ByVal sp As Space) As Integer
		' It will find the entry in reserve map 
		' if yes then we will pick that 
		' Element and put into the unreserved map. 
		' And return the charge units with the current time value.
	End Function
End Class
Friend Class Machine

End Class
Friend Class Person

End Class
Public Class system
	Private personIdToMachineIdMap As Dictionary(Of Integer, Integer)
	Private machineIdToMachineMap As Dictionary(Of Integer, Machine)

	Private Function getMachine(ByVal machineId As Integer) As Machine
		Return machineIdToMachineMap(machineId)
	End Function

	Private Function getPerson(ByVal personId As Integer) As Person
		Dim machienId As Integer = personIdToMachineIdMap(personId)
		Dim m As Machine = machineIdToMachineMap(machienId)
		Return m.getPersonWithId(personId)
	End Function
End Class

Friend Class fibdemo
	Private Function fibonacci(ByVal n As Integer) As Integer
		If n <= 1 Then
			Return n
		End If
		Return fibonacci(n - 1) + fibonacci(n - 2)
	End Function

	Private Function fibo(ByVal n As Integer) As Integer
		Dim first As Integer = 0, second As Integer = 1
		Dim temp As Integer = 0, i As Integer

		If n = 0 Then
			Return first
		ElseIf n = 1 Then
			Return second
		End If

		For i = 2 To n
			temp = first + second
			first = second
			second = temp
		Next i
		Return temp
	End Function


End Class

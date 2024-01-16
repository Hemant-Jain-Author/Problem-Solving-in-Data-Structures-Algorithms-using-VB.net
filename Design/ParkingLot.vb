Imports System.Collections.Generic

Public Class ParkingLot
	Private unreservedMap As IDictionary(Of Integer, Space)
	Private reservedMap As IDictionary(Of Integer, Space)

	public virtual Boolean ReserveSpace(Space)
	If True Then
		'It will find if there is space in the 
		'unreserved map 
		'If yes, then we will pick that element and 
		'put into the reserved map with the current time value.
	End If

'	public virtual int UnReserveSpace(Space)
'	{
'		' It will find the entry in reserve map 
'		' if yes then we will pick that 
'		' Element and put into the unreserved map. 
'		' And return the charge units with the current time value.
'	}
End Class

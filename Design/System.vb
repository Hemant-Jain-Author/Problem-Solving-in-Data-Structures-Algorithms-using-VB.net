Public Class System
	Private personIdToMachineIdMap As map(Of Integer, Integer)
	Private machineIdToMachineMap As map(Of Integer, Machine)

	Machine GetMachine(Integer machineId)

'INSTANT VB TODO TASK: Local functions are not converted by Instant VB:
'	Person GetPerson(int personId)
'	{
'		int machineId = personIdToMachineIdMap[personId];
'		Machine m = machineIdToMachineMap[machineId];
'		Return m.getPersonWithId(personId);
'	}
End Class

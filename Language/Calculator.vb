Imports System

Public Class Calculator
'INSTANT VB NOTE: The field value was renamed since Visual Basic does not allow fields to have the same name as methods:
	Private value_Renamed As Integer

	Public Sub New()
		value_Renamed = 0
	End Sub

	Public Sub New(ByVal arr As Integer)
		value_Renamed = arr
	End Sub

	Public Overridable Sub reset()
		value_Renamed = 0
	End Sub
	Public Overridable ReadOnly Property Value() As Integer
		Get
			Return value_Renamed
		End Get
	End Property

	Public Overridable Sub add(ByVal data As Integer)
		value_Renamed = value_Renamed + data
	End Sub

	Public Overridable Sub increment()
		value_Renamed += 1
	End Sub

	Public Overridable Sub subtract(ByVal data As Integer)
		value_Renamed = value_Renamed - data
	End Sub

	Public Overridable Sub decrement()
		value_Renamed -= 1
	End Sub
End Class





'public HelloWorld() {
'}

'Calculator c;
'c = new Calculator();
'c.increment();
'c.increment();
'System.out.print("value stored in c is:");
'System.out.println(c.getValue());
'bedReset(c);
'System.out.print("value stored in c is:");
'System.out.println(c.getValue());
'goodReset(c);
'System.out.print("value stored in c is:");
'System.out.println(c.getValue());
'stringPrint("Hello, World!");
'stringPrint("Hello,"," World!");


'public static void bedReset(Calculator c){
'	c = new Calculator();
'}
'
'public static void goodReset(Calculator c){
'	c.reset();
'}
'
'public static void stringPrint(String s){
'	System.out.println(s);
'}
'
'public static void stringPrint(String s1, String s2){
'	String s= s1+s2;
'	System.out.println(s);
'}

Imports System

Public Module StockBuySell
	Function maxProfit(ByVal arr() As Integer) As Integer
		Dim buyProfit As Integer = -arr(0) ' Buy stock profit
		Dim sellProfit As Integer = 0 ' Sell stock profit
		Dim n As Integer = arr.Length
		For i As Integer = 1 To n - 1
			Dim newBuyProfit As Integer = If(sellProfit - arr(i) > buyProfit, sellProfit - arr(i), buyProfit)
			Dim newSellProfit As Integer = If(buyProfit + arr(i) > sellProfit, buyProfit + arr(i), sellProfit)
			buyProfit = newBuyProfit
			sellProfit = newSellProfit
		Next i
		Return sellProfit
	End Function

	Function maxProfitTC(ByVal arr() As Integer, ByVal t As Integer) As Integer
		Dim buyProfit As Integer = -arr(0)
		Dim sellProfit As Integer = 0
		Dim n As Integer = arr.Length
		For i As Integer = 1 To n - 1
			Dim newBuyProfit As Integer = If((sellProfit - arr(i)) > buyProfit, (sellProfit - arr(i)), buyProfit)
			Dim newSellProfit As Integer = If((buyProfit + arr(i) - t) > sellProfit, (buyProfit + arr(i) - t), sellProfit)
			buyProfit = newBuyProfit
			sellProfit = newSellProfit
		Next i
		Return sellProfit
	End Function

	Function maxProfit2(ByVal arr() As Integer) As Integer
		Dim n As Integer = arr.Length
		Dim dp(n - 1, 1) As Integer
		dp(0, 0) = -arr(0) ' Buy stock profit
		dp(0, 1) = 0 ' Sell stock profit

		For i As Integer = 1 To n - 1
			dp(i, 0) = If(dp(i - 1, 1) - arr(i) > dp(i - 1, 0), dp(i - 1, 1) - arr(i), dp(i - 1, 0))
			dp(i, 1) = If(dp(i - 1, 0) + arr(i) > dp(i - 1, 1), dp(i - 1, 0) + arr(i), dp(i - 1, 1))
		Next i
		Return dp(n - 1, 1)
	End Function

	Function maxProfitTC2(ByVal arr() As Integer, ByVal t As Integer) As Integer
		Dim n As Integer = arr.Length
		Dim dp(n - 1, 1) As Integer
		dp(0, 0) = -arr(0)
		dp(0, 1) = 0

		For i As Integer = 1 To n - 1
			dp(i, 0) = If((dp(i - 1, 1) - arr(i)) > dp(i - 1, 0), (dp(i - 1, 1) - arr(i)), dp(i - 1, 0))
			dp(i, 1) = If((dp(i - 1, 0) + arr(i) - t) > dp(i - 1, 1), (dp(i - 1, 0) + arr(i) - t), dp(i - 1, 1))
		Next i
		Return dp(n - 1, 1)
	End Function

	' Testing code.
	Sub Main(ByVal args() As String)
		Dim arr() As Integer = {10, 12, 9, 23, 25, 55, 49, 70}
		Console.WriteLine("Total profit: " & maxProfit(arr))
		Console.WriteLine("Total profit: " & maxProfit2(arr))
		Console.WriteLine("Total profit: " & maxProfitTC(arr, 2))
		Console.WriteLine("Total profit: " & maxProfitTC2(arr, 2))
	End Sub
End Module

'
'Total profit: 69
'Total profit: 69
'Total profit: 63
'Total profit: 63
'
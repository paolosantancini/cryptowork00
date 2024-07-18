Option Strict On

Module Main

    Sub Main()

        Dim userA As New Btcservice
        'Dim apiobj As New Apiget
        Dim response As String

        'Dim f1 As New Form1

        'f1.Show()



        ' Getting wallet info
        Console.Write("Wallet info request - insert bitcoin wallet address: ")
        response = userA.getWalletInfo(Console.ReadLine())
        Console.WriteLine(response)

        ' Getting tx info
        Console.Write("Transaction info request - insert bitcoin tx hash: ")
        response = userA.getTxInfo(Console.ReadLine())
        Console.WriteLine(response)

        ' Getting block info
        Console.Write("Block info request - insert bitcoin block hash: ")
        response = userA.getBlockInfo(Console.ReadLine())
        Console.WriteLine(response)

        Console.ReadLine()

    End Sub

End Module

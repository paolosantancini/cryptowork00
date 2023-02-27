Option Strict On

Public Class Btcservice

    Private apiobj As New Apiget

    Sub New()

    End Sub

    Public Function getWalletInfo(ByVal address As String) As String
        Dim wallet As String

        wallet = apiobj.execRequest("address/" + address)

        Return wallet
    End Function

    Public Function getBlockInfo(ByVal blockhash As String) As String
        Dim block As String

        block = apiobj.execRequest("block/" + blockhash)
        block += Chr(10) + apiobj.execRequest("block/" + blockhash + "/txids")

        Return block
    End Function

    Public Function getTxInfo(ByVal txhash As String) As String
        Dim tx As String

        tx = apiobj.execRequest("tx/" + txhash)

        Return tx
    End Function

End Class

Option Strict On

Imports System.Net
Imports System.IO
Imports System.Security

Public Class Apiget

    Private client As New WebClient()
    Private endpoint As String


    Sub New()
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
        endpoint = "https://mempool.space/api/"
    End Sub

    Public Function execRequest(ByVal postreq As String) As String

        Dim srdr As Stream = client.OpenRead((endpoint + postreq))
        Dim strdr As New StreamReader(srdr)

        Return strdr.ReadToEnd()
    End Function

End Class

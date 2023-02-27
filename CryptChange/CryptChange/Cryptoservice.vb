Option Strict On

Imports System.Security.Cryptography
Imports System.Text

Public Class Cryptoservice

    Private rsa As New RSACryptoServiceProvider() ' cryptographic library
    Private pubK As String ' Public key
    Private privK As String ' Private key
    Private signed_msg(), enc_payload() As Byte

    Private Shared ReadOnly _instance As New Lazy(Of Cryptoservice)(Function() New Cryptoservice(), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication)

    ' Constructor
    Private Sub New()
        ' Creating key pair
        pubK = rsa.ToXmlString(False)
        privK = rsa.ToXmlString(True)
    End Sub

    ' Singleton pattern
    Public Shared ReadOnly Property Instance() As Cryptoservice
        Get
            Return _instance.Value
        End Get
    End Property

    ' Key Pair Method
    Public Function getPubK() As String

        Return pubK
    End Function

    ' Encrypting message by RSA method
    Public Function encMessage(ByVal pubK As String, ByVal message As String) As Byte()

        rsa.FromXmlString(pubK)

        enc_payload = rsa.Encrypt(Encoding.UTF8.GetBytes(message), False)

        Return (enc_payload)
    End Function

    ' Decrypting message by RSA method
    Public Function decMessage(ByVal enc_msg As Byte()) As String
        Dim dec_payload As Byte()
        Dim plain_msg As String

        ' import private key
        rsa.FromXmlString(privK)

        dec_payload = rsa.Decrypt(enc_msg, False)
        plain_msg = Encoding.UTF8.GetString(dec_payload)

        Return (plain_msg)
    End Function

    ' Sign message method
    Public Function singMessage(ByVal msg As String) As Byte()

        ' import private key
        rsa.FromXmlString(privK)

        signed_msg = rsa.SignData(Encoding.UTF8.GetBytes(msg), SHA256.Create())

        Return signed_msg
    End Function

    ' Verify signed message method
    Public Function verifyMessage(ByVal pubK As String, ByVal message As String, ByVal digest() As Byte) As Boolean

        ' import public key
        rsa.FromXmlString(pubK)

        Return rsa.VerifyData(Encoding.UTF8.GetBytes(message), SHA256.Create(), digest)
    End Function

End Class

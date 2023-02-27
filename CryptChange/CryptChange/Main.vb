Option Strict On

Module Main

    Sub Main()

        Dim message As String ' plain text message
        Dim chypher() As Byte ' encrypt's message chypher
        Dim digest() As Byte ' cryptogrphic digest
        Dim userb_pubk As String
        Dim usera_pubk As String

        Console.Write("Insert message to encrypt: ")
        message = Console.ReadLine

        Dim userA As Cryptoservice = Cryptoservice.Instance
        Dim userB As Cryptoservice = Cryptoservice.Instance

        ' userA request userB public key
        userb_pubk = userB.getPubK

        Console.WriteLine("User B public key: " + userb_pubk)

        ' userA encrypt message by userB public key
        chypher = userA.encMessage(userb_pubk, message)
        Console.WriteLine("User A encrypted message to B digest: " + Convert.ToBase64String(chypher))

        ' userB decrypt message by own private key
        Console.WriteLine("User B decrypting message A: " + userB.decMessage(chypher))

        ' userA sign own message to B
        digest = userA.singMessage(message)
        Console.WriteLine("User A message sign digest: " + Convert.ToBase64String(digest))

        ' userB verify userA signed message
        usera_pubk = userA.getPubK
        Console.WriteLine("User B verify user A message sign: " + userB.verifyMessage(usera_pubk, message, digest).ToString)

        Console.ReadLine()

    End Sub

End Module

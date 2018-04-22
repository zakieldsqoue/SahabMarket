using System;
using System.Xml;
using System.Text;
using System.Security.Cryptography;
using System.IO;

/// 
/// Summary description for converter
/// 
public class StringEncription
{
	public StringEncription()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public static string Decrypt( string TextToBeDecrypted , string Key )
	{
		RijndaelManaged RijndaelCipher = new RijndaelManaged();

		string DecryptedData;

		try
		{
			byte[] EncryptedData = Convert.FromBase64String( TextToBeDecrypted );

			byte[] Salt = Encoding.ASCII.GetBytes( Key.Length.ToString() );
			//Making of the key for decryption
			PasswordDeriveBytes SecretKey = new PasswordDeriveBytes( Key , Salt );
			//Creates a symmetric Rijndael decryptor object.
			ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor( SecretKey.GetBytes( 32 ) , SecretKey.GetBytes( 16 ) );

			MemoryStream memoryStream = new MemoryStream( EncryptedData );
			//Defines the cryptographics stream for decryption.THe stream contains decrpted data
			CryptoStream cryptoStream = new CryptoStream( memoryStream , Decryptor , CryptoStreamMode.Read );

			byte[] PlainText = new byte[ EncryptedData.Length ];
			int DecryptedCount = cryptoStream.Read( PlainText , 0 , PlainText.Length );
			memoryStream.Close();
			cryptoStream.Close();

			//Converting to string
			DecryptedData = Encoding.Unicode.GetString( PlainText , 0 , DecryptedCount );
		}
		catch
		{
			DecryptedData = TextToBeDecrypted;
		}
		return DecryptedData;
	}

	public static string Encrypt( string TextToBeEncrypted , string Key )
	{
		RijndaelManaged RijndaelCipher = new RijndaelManaged();
		byte[] PlainText = System.Text.Encoding.Unicode.GetBytes( TextToBeEncrypted );
		byte[] Salt = Encoding.ASCII.GetBytes( Key.Length.ToString() );
		PasswordDeriveBytes SecretKey = new PasswordDeriveBytes( Key , Salt );
		//Creates a symmetric encryptor object. 
		ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor( SecretKey.GetBytes( 32 ) , SecretKey.GetBytes( 16 ) );
		MemoryStream memoryStream = new MemoryStream();
		//Defines a stream that links data streams to cryptographic transformations
		CryptoStream cryptoStream = new CryptoStream( memoryStream , Encryptor , CryptoStreamMode.Write );
		cryptoStream.Write( PlainText , 0 , PlainText.Length );
		//Writes the final state and clears the buffer
		cryptoStream.FlushFinalBlock();
		byte[] CipherBytes = memoryStream.ToArray();
		memoryStream.Close();
		cryptoStream.Close();
		string EncryptedData = Convert.ToBase64String( CipherBytes );

		return EncryptedData;
	}
}
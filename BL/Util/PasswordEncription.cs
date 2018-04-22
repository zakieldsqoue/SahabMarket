using System;
using System.Xml;
using System.Text;
using System.Security.Cryptography;
using System.IO;

/// 
/// Summary description for converter
/// 
public class PasswordEncription
{
	private static string Key = "Fady_1&Milad_2&Abo-Zeid_3&Sief_4+AYA_5";

	public PasswordEncription()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public static string Decrypt( string TextToBeDecrypted )
	{
		return StringEncription.Decrypt( TextToBeDecrypted , Key );
	}

	public static string Encrypt( string TextToBeEncrypted )
	{
		return StringEncription.Encrypt( TextToBeEncrypted , Key );
	}
}
using System.Security.Cryptography;
using System.Text;

namespace GymManager.Common;

public class Cryptography
{
    /// <summary>
    ///     Calculate MD5 hash sum.
    /// </summary>
    /// <param name="inputBytes"></param>
    /// <returns></returns>
    public static string MD5Hash(byte[] inputBytes)
    {
        // step 1, calculate MD5 hash from input
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        var sb = new StringBuilder();
        for (var i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("X2"));
        return sb.ToString();
    }

    /// <summary>
    ///     Calculate MD5 Hash.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string MD5Hash(string input)
    {
        // step 1, calculate MD5 hash from input
        var md5 = MD5.Create();
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        var sb = new StringBuilder();
        for (var i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("x2"));
        return sb.ToString();
    }

    public static string XorEncryptDecrypt(string plainText, int encryptionKey)
    {
        var inputStringBuild = new StringBuilder(plainText);
        var outStringBuild = new StringBuilder(plainText.Length);
        char Textch;
        for (var iCount = 0; iCount < plainText.Length; iCount++)
        {
            Textch = inputStringBuild[iCount];
            Textch = (char)(Textch ^ encryptionKey);
            outStringBuild.Append(Textch);
        }

        return outStringBuild.ToString();
    }
}
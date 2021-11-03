using System;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Utils
{
    public class Hashing
    {
        public static string GetHashString(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}

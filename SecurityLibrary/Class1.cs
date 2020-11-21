using System;
using System.Text;
using System.Security.Cryptography;

//Security Library and hashing algorithm - Kaitlyn Allen
namespace SecurityLibrary
{
    public class HashFunctions
    {
        public string HashAlg(string value, string salt)
        {
            using (var sha = new SHA512CryptoServiceProvider())
            {
                var hashedString= sha.ComputeHash(Encoding.Default.GetBytes(value + salt));
                return Convert.ToBase64String(hashedString);
            }
        }

    }
}

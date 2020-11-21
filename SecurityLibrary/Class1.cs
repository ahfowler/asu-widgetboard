using System;
using System.Text;
using System.Security.Cryptography;
using System.Text;

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

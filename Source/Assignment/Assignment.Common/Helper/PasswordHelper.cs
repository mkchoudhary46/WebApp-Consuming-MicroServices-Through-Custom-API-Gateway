using System;
using System.Security.Cryptography;
using System.Text;

namespace Assignment.Common.Helper
{
    public static class PasswordHelper
    {
        public static string GenerateRandomSalt(int size = 16)
        {
            var rng = new RNGCryptoServiceProvider();
            var bytes = new Byte[size];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public static String Sha256_UnicodeHash(String value)
        {
            var sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.Unicode;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}

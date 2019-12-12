using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static string HashWithSHA256(this string value)
        {
            string hashed = string.Empty;
            using (var sha256 = SHA256.Create())
            {
                hashed = Convert.ToBase64String(sha256.ComputeHash((Encoding.UTF8.GetBytes(value))));
            };

            return hashed;
        }
    }
}

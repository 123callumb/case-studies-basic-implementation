using System;
using System.Security.Cryptography;

namespace Services.HashManagement.Implementation
{
    public static class HashHelper
    {
        private static readonly int SaltSize = 16;
        private static readonly int KeySize = 24;
        private static readonly int HashIterations = 9001;

        /// <summary>
        /// Hash a string with crytpo libs
        /// </summary>
        /// <param name="value">string value to hash</param>
        /// <returns>hashed string</returns>
        public static string Hash(this string value)
        {
            var rndSalt = new byte[SaltSize];
            new RNGCryptoServiceProvider().GetBytes(rndSalt);
            var rfc2898 = new Rfc2898DeriveBytes(value, rndSalt, HashIterations);
            byte[] hash = rfc2898.GetBytes(KeySize);
            return $"{Convert.ToBase64String(rndSalt)}|{HashIterations}|{Convert.ToBase64String(hash)}";
        }
        /// <summary>
        /// Compare a hased value with a non hashed value, used for seeing if passwords are
        /// correct as it is not possible to has the value and see if it exists in the db.
        /// The password hash must first be brough back.
        /// </summary>
        /// <param name="hash">Hashed string</param>
        /// <param name="value">Value to compare</param>
        /// <returns>Will return true if the hash is equal to the value and false if not</returns>
        public static bool CompareHashToValue(string hash, string value)
        {
            var hashParts = hash.Split('|', 3);
            if (hashParts.Length == 3)
            {
                var salt = Convert.FromBase64String(hashParts[0]);
                var iterations = Int32.Parse(hashParts[1]);
                var oHash = hashParts[2];

                var rfc2898 = new Rfc2898DeriveBytes(value, salt, iterations);
                byte[] testHash = rfc2898.GetBytes(KeySize);

                return Convert.ToBase64String(testHash) == oHash;
            }
            else
                return false;
        }
    }
}

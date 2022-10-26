using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{
    public class PasswordService : IPasswordService
    {
        private int _length = 12;
        public string GeneratePassword()
        {
            var key = new byte[_length];
            using (var generator = RandomNumberGenerator.Create())
                generator.GetBytes(key);
            return ToBase62String(key);
        }

        private string ToBase62String(byte[] key)
        {
            const string alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            BigInteger dividend = new BigInteger(key);
            var builder = new StringBuilder();
            while (dividend != 0)
            {
                dividend = BigInteger.DivRem(dividend, alphabet.Length, out BigInteger remainder);
                builder.Insert(0, alphabet[Math.Abs(((int)remainder))]);
            }
            return builder.ToString();
        }
    }
}

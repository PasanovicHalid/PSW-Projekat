using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Generators
{
    public class PasswordGenerator
    {
        private int _passwordLength = 12;

        private int _passwordResetKeyLength = 64;

        private RandomStringGenerator _randomStringGenerator = new RandomStringGenerator();

        public string GeneratePassword()
        {
            return _randomStringGenerator.GenerateBase62(_passwordLength);
        }

        public string GeneratePasswordResetKey()
        {
            return _randomStringGenerator.GenerateBase64(_passwordResetKeyLength);
        }
    }
}

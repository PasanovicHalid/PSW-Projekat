using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service.Generators
{
    public class APIKeyGenerator
    {
        private int _length = 64;
        private RandomStringGenerator _randomStringGenerator = new RandomStringGenerator();

        public string GenerateKey()
        {
            return _randomStringGenerator.GenerateBase64(_length);
        }
    }
}

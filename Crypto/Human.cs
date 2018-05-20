using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Crypto
{
    public class Human
    {
        public const int KEY_SIZE = 2048;
        private RSAParameters secretKey;
        public RSAParameters PublicKey { get; set; }

        public Human()
        {
            using (var rsa = new RSACryptoServiceProvider(KEY_SIZE))
            {
                PublicKey = rsa.ExportParameters(false);
                secretKey = rsa.ExportParameters(true);
            }
        }

        public string Encrypt(string message, RSAParameters publicKey)
        {
            var dataBytes = Encoding.UTF8.GetBytes(message);

            using (var rsa = new RSACryptoServiceProvider(KEY_SIZE))
            {
                rsa.ImportParameters(publicKey);
                var encryptedData = rsa.Encrypt(dataBytes, true);
                return Convert.ToBase64String(encryptedData);
            }
        }

        public string Decrypt(string data)
        {
            var dataBytes = Convert.FromBase64String(data);
            using (var rsa = new RSACryptoServiceProvider(KEY_SIZE))
            {
                rsa.ImportParameters(secretKey);
                var decryptedData = rsa.Decrypt(dataBytes, true);
                return Encoding.UTF8.GetString(decryptedData);
            }
        }
    }
}

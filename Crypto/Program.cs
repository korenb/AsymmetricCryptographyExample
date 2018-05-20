using System;
using System.Security.Cryptography;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            var roman = new Human();
            var egor = new Human();

            var message = "Ваше сообщение здесь";

            Console.WriteLine("Есть сообщение: {0}", message);
            var encrypted = roman.Encrypt(message, egor.PublicKey);
            Console.WriteLine("\nРома шифрует сообщение с помощью публичного ключа Егора: ");
            Console.WriteLine(Environment.NewLine + encrypted);
            var decrypted = egor.Decrypt(encrypted);
            Console.WriteLine("\nЕгор расшифровывает сообщение: {0}", decrypted);

            Console.ReadKey();
        }
    }
}

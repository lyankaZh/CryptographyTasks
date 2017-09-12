using System;
using System.Linq;
using System.Text;

namespace RSATask
{
    public static class RSA
    {
        private const int p = 3;
        private const int q = 11;
        private const int n = p * q;
        private const int E = 7;
        private const int D = 3;

        public static string Encrypt(string originalMessage)
        {
            var encryptedMessage = new StringBuilder();

            foreach (var symbol in originalMessage)
            {
                if (TableOfReplace.Table.ContainsKey(symbol))
                {
                    var code = Math.Pow(TableOfReplace.Table[symbol], E) % n;
                    encryptedMessage.Append($"{code} ");
                }
                else
                {
                    encryptedMessage.Append($"{symbol} ");
                }
            }

            return encryptedMessage.Remove(encryptedMessage.Length - 1, 1).ToString();
        }

        public static int HashFunction(string message)
        {
            return message.Where(x => TableOfReplace.Table.ContainsKey(x)).Sum(symbol => TableOfReplace.Table[symbol] % n) % n;
        }

        public static double GetDigitalSignature(string message)
        {
            var hashValue = HashFunction(message);
            return Math.Pow(hashValue, E) % n;
        }

        public static bool IsMessageGenuine(string messageToCheck, int signature)
        {
            var hashOfMessageToCheck = HashFunction(messageToCheck);

            return (int) Math.Pow(signature, D) % n == hashOfMessageToCheck;
        }

        public static string Decrypt(string ecnryptedMessage)
        {
            var splitedEncryptedText = ecnryptedMessage.Split(' ');
            var originalMessage = new StringBuilder();

            foreach (var symbol in splitedEncryptedText)
            {
                if (symbol.All(char.IsDigit))
                {
                    var numberOfLetter = Math.Pow(int.Parse(symbol), D) % n;
                    originalMessage.Append(TableOfReplace.Table.Where(x => x.Value == (int)numberOfLetter).Select(x => x.Key)
                        .Single());
                }
                else
                {
                    originalMessage.Append(symbol);
                }
            }

            return originalMessage.ToString();
        }
    }
}

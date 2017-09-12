using System;
using System.Collections.Generic;

namespace HammaCipherTask
{
    public class HammaCipherManager
    {
        private readonly string _orinalTextFileName = "original.txt";
        private readonly string _encryptedTextFileName = "encrypted.txt";
        private readonly string _decryptedTextFileName = "decrypted.txt";

        public void DemonstrateWork()
        {
            var fileManager = new FileManager();

            var key = AskKey();
            
            DemostrateEncrypting(fileManager, key);

            Console.WriteLine("Your text has been encrypted" + Environment.NewLine);

            Console.WriteLine("Enter key to decrypt message");
            key = AskKey();

            DemonstrateDecrypting(fileManager, key);
        }

        private static List<int> AskKey()
        {
            var key = new List<int>();
            for (var i = 0; i < 3; i++)
            {
                string userInput;
                int keyPart;
                do
                {
                    Console.WriteLine(
                        $"Please, input {i} part of key (integer number in range [0, {HammaCipher.TotalAmountOfLettersInTable - 1}]): ");
                    userInput = Console.ReadLine();
                } while (!int.TryParse(userInput, out keyPart) || keyPart < 0 || keyPart >= HammaCipher.TotalAmountOfLettersInTable);

                key.Add(keyPart);
            }

            return key;
        }
        private void DemostrateEncrypting(FileManager fileManager, List<int> key)
        {
            var originalText = fileManager.Read(_orinalTextFileName);

            var encryptedText = HammaCipher.Encrypt(originalText, key);

            fileManager.Write(encryptedText, _encryptedTextFileName);
        }

        private void DemonstrateDecrypting(FileManager fileManager, List<int> key)
        {
            var encryptedText = fileManager.Read(_encryptedTextFileName);

            var originalText = HammaCipher.Decrypt(encryptedText, key);

            Console.WriteLine(originalText);
            fileManager.Write(originalText, _decryptedTextFileName);
        }
    }
}

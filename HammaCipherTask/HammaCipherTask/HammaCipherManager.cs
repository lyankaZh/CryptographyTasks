using System;
using System.Collections.Generic;

namespace HammaCipherTask
{
    public class HammaCipherManager
    {
        private readonly string _orinalTextFileName = "original.txt";
        private readonly string _encryptedTextFileName = "encrypted.txt";

        public void DemonstrateWork()
        {
            var fileManager = new FileManager();

            var key = new List<int>();

            for (int i = 0; i < 3; i++)
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
            DemostrateEncrypting(fileManager, key);

            Console.WriteLine("Your text has been encrypted" + Environment.NewLine);
            Console.WriteLine("Press enter to see your decrypted text");
            Console.ReadLine();

            DemonstrateDecrypting(fileManager, key);
        }

        private void DemostrateEncrypting(FileManager fileManager, List<int> key)
        {
            var originalText = fileManager.Read(_orinalTextFileName);

            var encryptedText = HammaCipher.Encrypt(originalText, key);

            fileManager.Write(encryptedText, _encryptedTextFileName);
        }

        private void DemonstrateDecrypting(FileManager fileManager, List<int> key)
        {
            //var encryptedText = fileManager.Read(_encryptedTextFileName);

            //var originalText = CaesarCipher.Decrypt(encryptedText, offset);

            //Console.WriteLine(originalText);
        }
    }
}

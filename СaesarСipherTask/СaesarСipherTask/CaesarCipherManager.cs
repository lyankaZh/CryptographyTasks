using System;

namespace СaesarСipherTask
{
    public class CaesarCipherManager
    {

        private readonly string _orinalTextFileName = "original.txt";
        private readonly string _encryptedTextFileName = "encrypted.txt";

        public void DemonstrateWork()
        {
            var fileManager = new FileManager();

            string userInput;
            int offset;

            do
            {
                Console.WriteLine("Please, input offset (integer number): ");
                userInput = Console.ReadLine();
            } while (!int.TryParse(userInput, out offset));

            DemostrateEncrypting(fileManager, offset);

            Console.WriteLine("Your text has been encrypted" + Environment.NewLine);
            Console.WriteLine("Press enter to see your decrypted text");
            Console.ReadLine();

            DemonstrateDecrypting(fileManager, offset);

            DemonstrateCryptoanalysis(fileManager);
        }

        private void DemonstrateCryptoanalysis(FileManager fileManager)
        {
            string ecnryptedText = fileManager.Read(_encryptedTextFileName);
            CryptoAnalysis analysis = new CryptoAnalysis(ecnryptedText);

            var offsets = analysis.FindOffsets();
            Console.WriteLine(Environment.NewLine + "Cryptoanalysis in work:..." + Environment.NewLine);
            foreach (var offset in offsets)
            {
                Console.WriteLine($"Offset: {offset}");
                Console.WriteLine("Your message:");
                var decryptedMessage = CaesarCipher.Decrypt(ecnryptedText, offset);
                Console.WriteLine(decryptedMessage + Environment.NewLine);

                Console.WriteLine("Are you satisfied? (y/n)");
                var readLine = Console.ReadLine();
                if (readLine != null && readLine.ToLower().StartsWith("y"))
                {
                    Console.WriteLine("Thank you for using this program!");
                    return;
                }
            }

            Console.WriteLine("Sorry, your text cant be encrypted");
        }

        private void DemostrateEncrypting(FileManager fileManager, int offset)
        {
            var originalText = fileManager.Read(_orinalTextFileName);

            var encryptedText = CaesarCipher.Encrypt(originalText, offset);

            fileManager.Write(encryptedText, _encryptedTextFileName);
        }

        private void DemonstrateDecrypting(FileManager fileManager, int offset)
        {
            var encryptedText = fileManager.Read(_encryptedTextFileName);

            var originalText = CaesarCipher.Decrypt(encryptedText, offset);

            Console.WriteLine(originalText);
        }
    }
}

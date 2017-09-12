using System;

namespace RSATask
{
    public class RSAManager
    {
        private readonly string _orinalTextFileName = "original.txt";
        private readonly string _encryptedTextFileName = "encrypted.txt";
        private readonly string _digitalSignatureFileName = "signature.txt";

        public void DemonstrateWork()
        {
            var fileManager = new FileManager();

            DemostrateEncrypting(fileManager);

            Console.WriteLine("Your text has been encrypted" + Environment.NewLine);

            Console.WriteLine("Press enter to add digital signature");
            Console.ReadLine();

            DemonstrateDigitalSignature(fileManager);

            Console.WriteLine("Digital signature has been added" + Environment.NewLine);

            Console.WriteLine("Press enter to decrypt message");
            Console.ReadLine();

            DemonstrateDecrypting(fileManager);
        }

        private void DemostrateEncrypting(FileManager fileManager)
        {
            var originalText = fileManager.Read(_orinalTextFileName);

            var encryptedText = RSA.Encrypt(originalText);

            fileManager.Write(encryptedText, _encryptedTextFileName);
        }

        private void DemonstrateDecrypting(FileManager fileManager)
        {
            var encryptedText = fileManager.Read(_encryptedTextFileName);

            var originalText = RSA.Decrypt(encryptedText);

            Console.WriteLine(originalText);

            int digitalSignature;

            var canBeParsed = int.TryParse(fileManager.Read(_digitalSignatureFileName), out digitalSignature);

            Console.WriteLine(Environment.NewLine + "Conlusion about message");
            if (canBeParsed && RSA.IsMessageGenuine(originalText, digitalSignature))
            {
                Console.WriteLine("Message is genuine");
            }
            else
            {
                Console.WriteLine("Message is  not genuine");
            }
        }

        public void DemonstrateDigitalSignature(FileManager fileManager)
        {
            var originalText = fileManager.Read(_orinalTextFileName);

            var digitalSignature = RSA.GetDigitalSignature(originalText);

            fileManager.Write(digitalSignature, _digitalSignatureFileName);
        }
    }
}

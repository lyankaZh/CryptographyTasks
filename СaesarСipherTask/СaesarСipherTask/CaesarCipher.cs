using System;
using System.Text;

namespace СaesarСipherTask
{
    public static class CaesarCipher
    {
        private const int LowerLetterLowerBound = 97;
        private const int LowerLetterUpperBound = 122;
        private const int UpperLetterLowerBound = 65;
        private const int UpperLetterUpperBound = 90;
        private const int AmountOfLetters = 26;


        public static string Encrypt(string originalText, int offset)
        {
            offset = offset % AmountOfLetters;
            var encryptedText = new StringBuilder();

            foreach (var symbol in originalText)
            {
                if (char.IsLetter(symbol))
                {
                    encryptedText.Append(char.IsLower(symbol)
                        ? GetEncryptedCharValue((x, y) => x + y, offset, symbol, LowerLetterLowerBound, LowerLetterUpperBound)
                        : GetEncryptedCharValue((x, y) => x + y, offset, symbol, UpperLetterLowerBound, UpperLetterUpperBound));
                }
                else
                {
                    encryptedText.Append(symbol);
                }
            }

            return encryptedText.ToString();
        }

        private static char GetEncryptedCharValue(Func<int, int, int> operation, 
            int offset, char symbol, int lowerBound, int upperBound)
        {
            if (operation(symbol, offset) > upperBound)
            {
                return (char)(operation(symbol, offset) - AmountOfLetters);
            }
            if (operation(symbol, offset) < lowerBound)
            {
                return (char)(operation(symbol, offset) + AmountOfLetters);
            }

            return (char)operation(symbol, offset);
        }

        public static string Decrypt(string encryptedText, int offset)
        {
            offset = offset % AmountOfLetters;
            var originalText = new StringBuilder();
            foreach (var symbol in encryptedText)
            {
                if (char.IsLetter(symbol))
                {
                    originalText.Append(char.IsLower(symbol)
                        ? GetEncryptedCharValue((x, y) => x - y, offset, symbol, LowerLetterLowerBound, LowerLetterUpperBound)
                        : GetEncryptedCharValue((x, y) => x - y, offset, symbol, UpperLetterLowerBound, UpperLetterUpperBound));
                }
                else
                {
                    originalText.Append(symbol);
                }
            }

            return originalText.ToString();
        }
    }
}

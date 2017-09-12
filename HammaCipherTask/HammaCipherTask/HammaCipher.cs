using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HammaCipherTask
{
    public static class HammaCipher
    {
        private const int LowerLetterLowerBound = 97;
        private const int UpperLetterLowerBound = 65;
        private const int AmountOfLetters = 26;
        public const int TotalAmountOfLettersInTable = 53;
        private const int AmountOfNumbersInKey = 3;

        private static readonly Dictionary<char, int> TableOfReplace;

        static HammaCipher()
        {
            TableOfReplace = FormTableOfReplace();
        }

        private static Dictionary<char, int> FormTableOfReplace()
        {
            var tableOfReplace = new Dictionary<char, int>();
            var number = 0;
            for (var i = LowerLetterLowerBound; i < LowerLetterLowerBound + AmountOfLetters; i++)
            {
                tableOfReplace.Add((char)i, number);
                number++;
            }

            for (var i = UpperLetterLowerBound; i < UpperLetterLowerBound + AmountOfLetters; i++)
            {
                tableOfReplace.Add((char)i, number);
                number++;
            }

            tableOfReplace.Add(' ', number);
            return tableOfReplace;
        }

        public static List<int> GetSequnceBasedOnKey(List<int> key, int amountOfLettersInEncryptedText)
        {
            if (key.Count < AmountOfNumbersInKey)
            {
                throw new ArgumentException("Incorrect amount of key parts");
            }

            var sequence = new List<int>();

            for (var i = 0; i < AmountOfNumbersInKey; i++)
            {
                sequence.Add(key[i]);
            }

            for (var i = AmountOfNumbersInKey; i < amountOfLettersInEncryptedText + 1; i++)
            {
                sequence.Add((sequence[i - 1] + sequence[i - 3]) % TotalAmountOfLettersInTable);
            }

            return sequence;
        }

        public static List<int> GetRandomHamma(List<int> sequenceBasedOnKeys)
        {
            var randomHamma = new List<int>();

            for (var i = 0; i < sequenceBasedOnKeys.Count - 1; i++)
            {
                randomHamma.Add((sequenceBasedOnKeys[i] + sequenceBasedOnKeys[i + 1]) % TotalAmountOfLettersInTable);
            }

            return randomHamma;
        }

        public static string Encrypt(string originalText, List<int> key)
        {
            var sequenceBasedOnKeys = GetSequnceBasedOnKey(key, originalText.Length);
            var randomHamma = GetRandomHamma(sequenceBasedOnKeys);
            var encryptedText = new StringBuilder();

            var index = 0;
            foreach (var symbol in originalText)
            {
                if (TableOfReplace.ContainsKey(symbol))
                {
                    encryptedText.Append((TableOfReplace[symbol] + randomHamma[index])%TotalAmountOfLettersInTable);
                    encryptedText.Append(' ');
                }
                else
                {
                    encryptedText.Append(symbol);
                    encryptedText.Append(' ');
                }

                index++;
            }

            return encryptedText.ToString();
        }

        public static string Decrypt(string encryptedText, List<int> key)
        {
            var splitedEncryptedText = encryptedText.Substring(0, encryptedText.Length - 1).Split(' ');
            var sequenceBasedOnKeys = GetSequnceBasedOnKey(key, splitedEncryptedText.Length);
            var randomHamma = GetRandomHamma(sequenceBasedOnKeys);
            var originalText = new StringBuilder();

            var index = 0;
            foreach (var symbol in splitedEncryptedText)
            {
                if (symbol.All(char.IsDigit))
                {
                    var numberOfLetter = (int.Parse(symbol) + TotalAmountOfLettersInTable - randomHamma[index]) %
                                         TotalAmountOfLettersInTable;
                    originalText.Append(TableOfReplace.Where(x => x.Value == numberOfLetter).Select(x => x.Key)
                        .Single());
                }
                else
                {
                    originalText.Append(symbol);
                }

                index++;
            }

            return originalText.ToString();
        }
    }
}

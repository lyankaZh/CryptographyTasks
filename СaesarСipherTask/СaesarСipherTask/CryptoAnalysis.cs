using System;
using System.Collections.Generic;
using System.Linq;

namespace СaesarСipherTask
{
    public class CryptoAnalysis
    {
        private readonly List<char> _theMostPopularLetters = new List<char> { 'e', 't', 'a', 'o', 'i' };
        private readonly List<char> _theMostPopularEncryptedLetters;

        public CryptoAnalysis(string text)
        {
            var frequencyTable = FindRelativeFrequency(text);
            _theMostPopularEncryptedLetters = FindTheMostFrequentSymbols(frequencyTable);
        }

        private Dictionary<char, double> FindRelativeFrequency(string encryptedText)
        {
            var frequencyTable = new Dictionary<char, double>();

            foreach (var symbol in encryptedText.ToLower())
            {
                if (char.IsLetter(symbol))
                {
                    if (frequencyTable.ContainsKey(symbol))
                    {
                        frequencyTable[symbol]++;
                    }
                    else
                    {
                        frequencyTable.Add(symbol, 1);
                    }
                }
            }

            var length = encryptedText.Length;
            var keys = frequencyTable.Keys.ToList();

            foreach (var key in keys)
            {
                frequencyTable[key] = frequencyTable[key] / length;
            }

            return frequencyTable;
        }

        private List<char> FindTheMostFrequentSymbols(Dictionary<char, double> frequencyTable)
        {
            var maxValue = frequencyTable.Max(x => x.Value);

            var charsWithMaxValues = frequencyTable.Where(x => Math.Abs(x.Value - maxValue) < 0.00001).Select(x => x.Key).ToList();

            return charsWithMaxValues;
        }

        public IEnumerable<int> FindOffsets()
        {
            return (from popularLetterInAlphabet in _theMostPopularLetters
                    from popularEncryptedLetter in _theMostPopularEncryptedLetters
                    select popularEncryptedLetter - popularLetterInAlphabet).ToList();
        }
    }
}

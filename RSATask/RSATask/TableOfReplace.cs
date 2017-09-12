using System.Collections.Generic;

namespace RSATask
{
    public class TableOfReplace
    {
        private const int LowerLetterLowerBound = 97;
        private const int UpperLetterLowerBound = 65;
        private const int AmountOfLetters = 26;

        public static Dictionary<char, int> Table;

        static TableOfReplace()
        {
            Table = FormTableOfReplace();
        }

        private static Dictionary<char, int> FormTableOfReplace()
        {
            var tableOfReplace = new Dictionary<char, int>();
            var number = 0;
            tableOfReplace.Add(' ', number);
            number++;

            for (var i = LowerLetterLowerBound; i < LowerLetterLowerBound + AmountOfLetters; i++)
            {
                tableOfReplace.Add((char)i, number);
                number++;
            }

            //for (var i = UpperLetterLowerBound; i < UpperLetterLowerBound + AmountOfLetters; i++)
            //{
            //    tableOfReplace.Add((char)i, number);
            //    number++;
            //}

            return tableOfReplace;
        }
    }
}

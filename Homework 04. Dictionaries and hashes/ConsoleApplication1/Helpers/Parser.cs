namespace Bots.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   internal static class Parser
    {
        public static List<string> ParseWordsFromText(string text)
        {
            List<string> resultList = new List<string>();

            var currentString = String.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                var currentChar = (char)text[i];
                if ((currentChar >= 65 && currentChar <= 90 || currentChar >= 97 && currentChar <= 122))
                {
                    currentString += text[i];
                }
                else
                {
                    if (!String.IsNullOrEmpty(currentString))
                    {
                        resultList.Add(currentString.ToLower());
                    }

                    currentString = String.Empty;
                }
            }

            return resultList;
        }

        public static Command ParseCommand(string command)
        {
            var personName = string.Empty;
            var currentIndex = 0;
            while (command[currentIndex] != '(')
            {

                currentIndex++;
            }

            currentIndex++;

            while (command[currentIndex] != ')')
            {
                personName += command[currentIndex];
                currentIndex++;
            }

            personName = personName.Trim();

            var test = personName.Split(',').ToArray();

            switch (test.Length)
            {
                case 1: return new Command(test[0], null);
                case 2: return new Command(test[0], test[1].Trim());
                default: return new Command(null, null);
            }
        }
    }
}

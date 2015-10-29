namespace Problem_07.FindTheUniqueNumbersCount
{
    using System;
    using System.Collections.Generic;

   public class DoWhatTheOtherTasksHaveBeenDoing
    {
        static void Main()
        {
            var numbers = RamDbImporter.ImportNumbers();
            var sequences = new Dictionary<int,int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (sequences.ContainsKey(numbers[i]))
                {
                    sequences[numbers[i]]++;
                }
                else
                {
                    sequences[numbers[i]] = 1;
                }
            }

            foreach (var set in sequences)
            {
                Console.WriteLine(set.Key + ": " + set.Value + " times");
            }

            Console.ReadKey();
        }
    }
}

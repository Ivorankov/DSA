namespace Problem_03.LongestSubsequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class SequenceFinder
    {
        static void Main()
        {
            Console.WriteLine("Please enter some numbers in one line separated by space: ");
            var userInput = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            var sequences = new Dictionary<int, int>();

            DiagTimer.Start();
            for (int i = 0; i < userInput.Count; i++)
            {
                if (sequences.ContainsKey(userInput[i]))
                {
                    sequences[userInput[i]]++;
                }
                else
                {
                    sequences[userInput[i]] = 1;
                }

            }

            var maxSequenceNumberWithSet = sequences.First();
            foreach (var nextSequenceNumber in sequences)
            {
                if (nextSequenceNumber.Value > maxSequenceNumberWithSet.Value)
                {
                    maxSequenceNumberWithSet = nextSequenceNumber;
                }
            }

            DiagTimer.StopAndShowResult();
            Console.WriteLine("Top sequence is with number: " + maxSequenceNumberWithSet.Key + " it's contained: " + maxSequenceNumberWithSet.Value + " times.(DIC*)");

            DiagTimer.Start();
            var maxSequenceNumbeWithLinq = userInput.GroupBy(i => i)
                                .OrderByDescending(grp => grp.Count())
                                .Select(grp => "Top sequence is with number: " + grp.Key + " it's contained: " + grp.Count() + " times.(LINQ)")
                                .First();

            DiagTimer.StopAndShowResult();
            Console.WriteLine(maxSequenceNumbeWithLinq);

            //Its time for the actual task solution
            var thisIsLessFun = new List<int>();
            for (int i = 0; i < maxSequenceNumberWithSet.Value; i++)
            {
                thisIsLessFun.Add(maxSequenceNumberWithSet.Key);
            }

            Console.ReadKey();
        }
    }
}

namespace Problem_06.RemoveNumbersWithOddCount
{
    using System;
    using System.Collections.Generic;

    public class OddBallBully
    {
        static void Main()
        {
            var numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 }; // Result: {5, 3, 3, 5}

            var sequences = new Dictionary<int, int>();

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

            foreach (var nextSequenceNumber in sequences)
            {
                if (nextSequenceNumber.Value % 2 != 0)
                {
                    numbers.RemoveAll(x => x == nextSequenceNumber.Key);
                }
            }

            numbers.ForEach(x => Console.Write(x + " "));
            Console.ReadKey();

        }
    }
}

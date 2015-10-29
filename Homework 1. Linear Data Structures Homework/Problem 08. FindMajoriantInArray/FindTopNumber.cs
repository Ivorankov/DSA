namespace Problem_08.FindMajoriantInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindTopNumber
    {
        static void Main()
        {

            var numbers = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 }; //Result: 3
            var moreNumbers = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var majorCandidate = FindTopNumberInArray(numbers);
            var majorCandidate2 = FindTopNumberInArray(moreNumbers);

            CheckIfIsMajor(majorCandidate, numbers);
            CheckIfIsMajor(majorCandidate2, numbers);

            Console.ReadKey();
        }

        private static void CheckIfIsMajor(KeyValuePair<int, int> majorCandidate, int[] numbers)
        {
            if (majorCandidate.Value >= (numbers.Length/2) + 1)
            {
                Console.WriteLine("Found em: " + majorCandidate.Key);
            }
            else
            {
                Console.WriteLine("An error occured");
            }
        }

        private static KeyValuePair<int, int> FindTopNumberInArray(int[] numbers)
        {
            var sequences = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
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

            var majorCandidate = sequences.First();

            foreach (var set in sequences)
            {
                if (majorCandidate.Value < set.Value)
                {
                    majorCandidate = set;
                }
            }
            return majorCandidate;
        }
    }
}

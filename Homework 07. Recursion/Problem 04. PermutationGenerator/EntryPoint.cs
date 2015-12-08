namespace Problem_04.PermutationGenerator
{
    using System;
    using System.Collections.Generic;

   internal class EntryPoint
    {
        static void Main()
        {
            var k = 3;
            var n = 3;

            var numbers = new List<int>() {1, 2, 3, 4};
            var permutationCollection = GenericPermutationGenerator.GeneratePermutations(numbers);

            foreach (var set in permutationCollection)
            {
                set.ForEach(x => Console.Write(x + " "));
                Console.WriteLine();
            }

        }
    }
}

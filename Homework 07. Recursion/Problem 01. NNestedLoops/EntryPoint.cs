namespace Problem_01.NNestedLoops
{
    using System;
    using System.Collections.Generic;

    internal class EntryPoint
    {
        private static int loopTo = 2;
        private static int[] numberSet;
        private static List<int[]> resultNumber = new List<int[]>(); 

        static void Main()
        {
            CombineNumbers(2, new int[2], 2);
            foreach (var set in resultNumber)
            {
                Console.WriteLine(set[0] + " "+ set[1]);
            }

            Console.ReadKey();
        }

        private static void CombineNumbers(int numberOfNestedLoops, int[] numberSet, int loopTo)
        {
            if (0 == loopTo)
            {
                var numberSets = new int[2] {numberSet[0], numberSet[1]};
                if (!resultNumber.Contains(numberSet))
                {
                    resultNumber.Add(new int[2] { numberSet[0], numberSet[1] }); 
                }
             
                return;
            }

            for (int i = 1; i <= numberOfNestedLoops; i++)
            {
                numberSet[loopTo - 1] = i;
                CombineNumbers(numberOfNestedLoops, numberSet, loopTo - 1);
            }
        } 
    }
}

namespace Problem_03.CombinationsWithoutDuplicates
{
    using System;

    internal class EntryPoint
    {
        static void Main()
        {
            var k = 2;
            var n = 4;

            GenerateCombinations(new int[k], 0, 1, n);

            Console.ReadKey();
        }


        static void GenerateCombinations(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                Console.Write("(" + String.Join(", ", arr) + ") ");
            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(arr, index + 1, i + 1, endNum);
                }
            }
        }
    }
}

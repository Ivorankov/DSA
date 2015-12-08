namespace Problem_05.OrderedKElementSubsets
{
    using System;

    internal class EntryPoint
    {
        static string[] inputStrings = new string[]{"hi", "a", "b"};

        static void Main()
        {
            var k = 2;
            var n = 3;

            GenerateCombinations(new string[k], 0, n);

            Console.ReadKey();
        }


        static void GenerateCombinations(string[] arr, int index, int endNum)
        {
            if (index >= arr.Length)
            {
                Console.Write("(" + String.Join(", ", arr) + ") ");
            }
            else
            {
                for (int i = 0; i < endNum; i++)
                {
                    arr[index] = inputStrings[i];
                    GenerateCombinations(arr, index + 1, endNum);
                }
            }
        }
    }
}

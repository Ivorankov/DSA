namespace Problem_06.StringSubsets
{
    using System;

    internal class EntryPoint
    {
        static string[] inputStrings = new string[] { "test", "rock", "fun" };

        static void Main()
        {
            var k = 2;
            var n = 3;
            //Not much of a task is it
            GenerateCombinations(new string[k], 0, 0, n);

            Console.ReadKey();
        }


        static void GenerateCombinations(string[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                Console.Write("(" + String.Join(", ", arr) + ") ");
            }
            else
            {
                for (int i = startNum; i < endNum; i++)
                {
                    arr[index] = inputStrings[i];
                    GenerateCombinations(arr, index + 1, i + 1, endNum);
                }
            }
        }
    }
}

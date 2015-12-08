namespace Problem_02.Zig_Zag_Numbers
{
    using System;

    class EntryPoint
    {
        private static int numbers;

        static bool[] used;

        static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var k = int.Parse(input[1]);
            numbers = 0;
            used = new bool[n];
            GenerateCombinations(new int[k], 0, 0, n - 1);
            Console.WriteLine(numbers);
        }

        private static void GenerateCombinations(int[] arr, int index, int startNum, int endNum)
        {
            if (index >= arr.Length)
            {
                if (IsZigZag(arr))
                {
                    numbers++;
                }

            }
            else
            {
                for (int i = startNum; i <= endNum; i++)
                {
                    if (!used[i])
                    {
                        arr[index] = i;
                        used[i] = true;
                        GenerateCombinations(arr, index + 1, 0, endNum);
                        used[i] = false;
                    }

                }
            }
        }

        private static bool IsZigZag(int[] array)
        {
            if (array.Length == 1)
            {
                return true;
            }
            else if (array.Length == 2)
            {
                return array[0] > array[1];
            }
            else
            {
                for (int i = 1; i < array.Length - 1; i += 1)
                {
                    var whenEven = i % 2 == 0 && !(array[i - 1] < array[i] && array[i] > array[i + 1]);
                    var whenOdd = i % 2 == 1 && !(array[i - 1] > array[i] && array[i] < array[i + 1]);

                    if (whenEven || whenOdd)
                    {
                        return false;
                    }

                }

            }

            return true;
        }
    }
}


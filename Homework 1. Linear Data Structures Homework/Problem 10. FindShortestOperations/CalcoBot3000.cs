namespace Problem_10.FindShortestOperations
{
    using System;
    using System.Collections.Generic;

    public class CalcoBot3000
    {
        static void Main()
        {
            var M = 16;
            var N = 5;

            int numberOfOperations;
            var numbers = BeSmart(M, N, out numberOfOperations);
            foreach (var item in numbers)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("I did that in: " + numberOfOperations + " operations");

            Console.ReadKey();
        }

        private static Queue<int> BeSmart(int numberFrom, int numberTo, out int numberOfOperations)
        {
            var queue = new Queue<int>();
            queue.Enqueue(numberFrom);
            var currentNumber = numberFrom;
            numberOfOperations = 0;
            while (currentNumber > numberTo)
            {
                if (currentNumber / 2 >= numberTo)
                {
                    currentNumber /= 2;
                }
                else if (currentNumber - 2 >= numberTo)
                {
                    currentNumber -= 2;
                }
                else if (currentNumber - 1 >= numberTo)
                {
                    currentNumber--;
                }

                queue.Enqueue(currentNumber);
                numberOfOperations++;
            }

            return queue;
        }
    }
}

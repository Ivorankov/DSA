namespace Problem_03.Tribonacci
{
    using System;
    using System.Linq;

    class Program
    {
        //Problem 01 in BgCoder
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            long t1 = input[0];
            long t2 = input[1];
            long t3 = input[2];
            long n = input[3];
            long newElement = 0;
            if (n == 4)
            {
                Console.WriteLine(t1 + t2 + t3);
            }
            else
            {
                for (int i = 4; i <= n; i++)
                {
                    newElement = t1 + t2 + t3;
                    t1 = t2;
                    t2 = t3;
                    t3 = newElement;
                }

                Console.WriteLine(newElement);
            }
        }
    }
}

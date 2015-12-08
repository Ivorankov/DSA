namespace Problem_04.SuperSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

   internal class Program
    {
        //Problem 02 in BgCoder
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var k = input[0];
            var n = input[1];

            Console.WriteLine(SuperSum(k, n));
        }

        private static long SuperSum(int k, int n)
        {
            long res = 0;
            if(k == 0)
            {
                return n;
            }

            for (int i = 1; i <= n; i++)
            {
                res += SuperSum(k - 1, i);
            }

            return res;
        }
    }
}

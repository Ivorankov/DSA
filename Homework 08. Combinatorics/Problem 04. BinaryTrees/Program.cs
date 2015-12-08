namespace Problem_04.BinaryTrees
{
    using System;
    using System.Numerics;

    class Program
    {
        private static long[] memo;

        static void Main()
        {
            var input = Console.ReadLine();
            var groups = new int[26];
            foreach (var item in input)
            {
                groups[item - 'A']++;
            }

            var n = input.Length;
            memo = new long[n + 1];
            var factor = new long[n + 1];
            factor[0] = 1;

            for (int i = 0; i < n; i++)
            {
                factor[i + 1] = factor[i] * (i + 1);
            }

            long res = factor[n];
            foreach (var item in groups)
            {
                res /= factor[item];
            }

            BigInteger output = res;
            output *= TreeCount(n);

            Console.Write(output);
        }

        private static long TreeCount(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (memo[n] > 0)
            {
                return memo[n];
            }

            long res = 0;
            for (int i = 0; i < n; i++)
            {
                res += TreeCount(i) * TreeCount(n - 1 - i);
            }

            memo[n] = res;
            return res;
        }
    }
}
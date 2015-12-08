namespace Problem_05.Brackets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        //Problem 03 in BgCoder
        static void Main()
        {
            var input = Console.ReadLine();

            var DP = new long[128, 128];
            var N = input.Length;

            for (int i = 0; i < 128; i++)
            {
                for (int j = 0; j < 128; j++)
                {
                    DP[i, j] = 0;
                }

            }
            DP[0, 0] = 1;

            for (int i = 1; i <= N; i++)
            {
                if (input[i - 1] == '(')
                {
                    DP[i,0] = 0;
                }
                else
                {
                    DP[i, 0] = DP[i - 1 , 1];
                }

                for (int j = 1; j <= N; j++)
                {
                    if (input[i - 1] == '(')
                    {
                        DP[i, j] = DP[i - 1, j - 1];
                    }
                    else if (input[i - 1] == ')')
                    {
                        DP[i, j] = DP[i - 1, j + 1];
                    }
                    else
                    {
                        DP[i, j] = DP[i - 1, j - 1] + DP[i - 1, j + 1];
                    }
                }
            }

            Console.WriteLine(DP[N, 0]);
        }
    }
}

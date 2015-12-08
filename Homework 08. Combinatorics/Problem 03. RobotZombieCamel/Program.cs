using System;
using System.Collections.Generic;

namespace Problem_03.RobotZombieCamel
{
    class Program
    {
        private const ulong Modue = ulong.MaxValue;

        static void Main()
        {
            var n = int.Parse(Console.ReadLine().Trim());
            var obelixs = new List<int>();
            ulong result = 0;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Trim();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    var currentInput = Console.ReadLine().Split(' ');

                    var x = Math.Abs(int.Parse(currentInput[0]));
                    var y = Math.Abs(int.Parse(currentInput[1]));

                    obelixs.Add(x + y);
                }

            }

            obelixs.ForEach(x => result += (ulong)x);

            Console.WriteLine(result % Modue);
        }
    }
}

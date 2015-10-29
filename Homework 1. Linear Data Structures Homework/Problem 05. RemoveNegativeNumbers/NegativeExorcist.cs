namespace Problem_05.RemoveNegativeNumbers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class NegativeExorcist
    {
        static void Main()
        {
            var numbers = new List<int> {0, 1, -1, 2, 2, -2, -100, 10, 5, 5, -11, 2, 2, 2, -13};

            numbers = numbers.Where(x => x >= 0).ToList();

            numbers.ForEach(x => Console.Write(x + " "));
        }
    }
}

namespace ConsoleApplication1
{
    using System;

    class EntryPoint
    {
        static void Main()
        {
            var input = Console.ReadLine();

            var unknownDigits = 0;
            long result = 1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '*')
                {
                    result *= 2;
                }
            }

            Console.WriteLine(result);
        }
    }
}

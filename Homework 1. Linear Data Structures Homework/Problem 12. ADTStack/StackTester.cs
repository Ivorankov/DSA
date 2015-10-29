namespace Problem_11.ADTStack
{
    using System;

    public class StackTester
    {
        static void Main()
        {
            var test = new ADTStack<string>();

            test.Push("Alfa");
            test.Push("Beta");
            test.Push("Gama");
            test.Push("Delta");
            test.Push("Alfa");
            test.Push("Beta");
            test.Push("Gama");
            test.Push("Delta");
            test.Push("Alfa");
            test.Push("Beta");
            test.Push("Gama");
            test.Push("Delta");

            var count = test.Count;
            Console.WriteLine(count);

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(test.Peek());
                test.Pop();
            }

            count = test.Count;
            Console.WriteLine(count);

            Console.ReadKey();
        }
    }
}

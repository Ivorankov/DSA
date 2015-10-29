namespace Problem_12.ADTQueue
{
    using System;

    public class QueueTester
    {
        static void Main()
        {
            var test = new ADTQueue<string>();

            test.Enqueue("Alfa");
            test.Enqueue("Beta");
            test.Enqueue("Gama");
            test.Enqueue("Delta");

            var count = test.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(test.Peek());
                test.Dequeue();
            }

            Console.ReadKey();
        }
    }
}

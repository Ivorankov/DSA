namespace Problem_01.PriorityQueue
{
    using System;

    class EntryPoint
    {
       
        static void Main()
        {
            var test = new PriorityQueue<int>();
            test.Insert(1);
            test.Insert(2);
            test.Insert(3);
            test.Insert(4);
            test.Insert(0);
            test.Insert(20);
            test.Insert(7);
            test.Insert(3000);

            var count = test.Size;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(test.Pop());
            }
        }
    }
}

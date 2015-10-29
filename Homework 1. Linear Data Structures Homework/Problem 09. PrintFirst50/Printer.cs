namespace Problem_09.PrintFirst50
{
    using System;
    using System.Collections.Generic;

    public class Printer
    {
        static void Main()
        {
            var list = new Queue<int>();
            var element = 2;
            var newElement = 0;

            list.Enqueue(element);
            for (int i = 0; i < 50; i++)
            {
                element = list.Dequeue();
                Console.Write(element + " ");
                newElement = element + 1;
                list.Enqueue(newElement);

                newElement = 2*element + 1;
                list.Enqueue(newElement);

                newElement = element + 2;
                list.Enqueue(newElement);
            }
            Console.ReadKey();
        }
    }
}

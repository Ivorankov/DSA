using System;

namespace Problem_03.BiDictionary
{
    public class EntryPoint
    {
        static void Main()
        {
            var collection = new BiDictionary<int, double, string>();
            collection.Add(0, 0, "test");
            collection.Add(2, 1.5, "test1");
            collection.Add(1, 1, "test2");

            Console.WriteLine(collection.Find(1));
            Console.WriteLine(collection.Find(1.5));
            Console.WriteLine(collection.Find(1));
            


            Console.ReadKey();
        }
    }
}

using System;
using System.Runtime.InteropServices.ComTypes;

namespace HashSet
{
    class StartUp
    {
        static void Main()
        {
            var hashSet = new CHashSet<int>();

            hashSet.Add(1);
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(1);

            foreach (var item in hashSet)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            hashSet.Remove(1);

            foreach (var item in hashSet)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            var secondHashSet = new CHashSet<int>();
            secondHashSet.Add(3);
            secondHashSet.Add(4);
            secondHashSet.Add(2);

            var unionTest = hashSet.Union(secondHashSet);

            foreach (var item in unionTest)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            var intersectTest = hashSet.Intersect(secondHashSet);

            foreach (var item in intersectTest)
            {
                Console.Write(item + " ");
            }
        }
    }
}

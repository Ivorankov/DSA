using System;

namespace HashTable
{
    class StartUp
    {
        static void Main()
        {
            var hashTable = new CHashTable<int,string>();

            hashTable.Add(0, "a");
            hashTable.Add(1, "b");
            hashTable.Add(2, "c");
            hashTable.Add(3, "a");
            hashTable.Add(4, "d");
            hashTable.Add(5, "e");
            hashTable.Add(0, "f");

            foreach (var item in hashTable)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Console.WriteLine(hashTable.Contains(4).ToString());

            hashTable.Clear();

            Console.WriteLine(hashTable.Count);
        }
    }
}

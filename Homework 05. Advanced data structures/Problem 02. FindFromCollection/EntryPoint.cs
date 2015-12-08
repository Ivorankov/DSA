namespace Problem_02.FindFromCollection
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    class EntryPoint
    {
        private static Random rnd = new Random();

        static void Main()
        {
            var collection = GenerateCollection();

            PerformSerches(10000, collection);
        }

        private static void PerformSerches(int count, OrderedBag<Product> collection)
        {
            for (int i = 0; i < count; i++)
            {
                var res = collection.Range(new Product("GenericProduct", rnd.Next(10)), true,
                                           new Product("GenericProduct", rnd.Next(5,150)), true)
                                           .Take(20);
//<-- Break point goes here :D
            }

            //Console.SpamTillUserRagequits
        }

        private static Product GenerateProduct()
        {
            var name = "GenericProduct";
            var price = rnd.Next(150);
            var newProduct = new Product(name, price);

            return newProduct;
        }

        private static OrderedBag<Product> GenerateCollection()
        {
            OrderedBag<Product> collection = new OrderedBag<Product>();
            for (int i = 0; i < 500000; i++)
            {
                collection.Add(GenerateProduct());
            }

            return collection;
        }
    }
}

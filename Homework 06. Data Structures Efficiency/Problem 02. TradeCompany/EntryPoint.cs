namespace Problem_02.TradeCompany
{
    using System;
    using Wintellect.PowerCollections;

    internal class EntryPoint
    {
        private static Random rnd = new Random();
        static void Main()
        {
            var test = GenerateProductCollection();

            var minPrice = 75;
            var maxPrice = 500;

           var result = test.Range(minPrice, true, maxPrice, true);
           Console.WriteLine("Found " + result.Count + " products within that price range");

            Console.ReadKey();
        }

        private static OrderedMultiDictionary<decimal, Product> GenerateProductCollection()
        {
            var collection = new OrderedMultiDictionary<decimal, Product>(true);

            for (int i = 0; i < 100000; i++)
            {
                var currentProduct = new Product();
                currentProduct.Name = rnd.Next(0, 5).ToString();
                currentProduct.Vendor = rnd.Next(0, 20).ToString();
                currentProduct.Barcode = rnd.Next(50, 100).ToString();
                var price = rnd.Next(50, 15000);
                currentProduct.Price = price;

                collection.Add(price, currentProduct);
            }

            return collection;
        } 
    }
}

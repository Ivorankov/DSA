using System;

namespace Problem_02.FindFromCollection
{
    class Product : IComparable
    {
        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; } //Coins are stupid

        public int CompareTo(Product other)
        {
            return this.Price - other.Price;
        }

        public int CompareTo(object obj)
        {
            var other = obj as Product;
            return this.Price - other.Price;
        }
    }
}

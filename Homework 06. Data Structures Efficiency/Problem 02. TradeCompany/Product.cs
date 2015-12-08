using System;

namespace Problem_02.TradeCompany
{
    public class Product : IComparable
    {
        public string Vendor { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Product;
            var res = this.Price.CompareTo(other.Price);
            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDD_T2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public double Weight { get; set; }
        public int Quantity { get; set; }

        public Product(string name, int price, double weight, int quantity)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Quantity = quantity;
        }
    }
}

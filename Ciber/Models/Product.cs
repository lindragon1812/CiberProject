﻿namespace Ciber.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public int? Quantity { get; set;}
    }
}

using System;
using System.Drawing;

namespace Ciber.Models
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public string CategoryName { get; set; }

        public string CustomerName { get; set; }

        

        public DateTime CreatedDate { get; set; }

        public int Amount { get; set; }
    }
}

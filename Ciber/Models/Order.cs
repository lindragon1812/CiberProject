using System;

namespace Ciber.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int? Amount { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;
    }
}

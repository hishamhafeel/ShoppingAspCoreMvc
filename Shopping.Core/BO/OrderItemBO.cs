using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.BO
{
    public class OrderItemBO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}

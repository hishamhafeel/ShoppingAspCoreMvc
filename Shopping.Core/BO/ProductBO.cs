using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.BO
{
    public class ProductBO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductUnitPrice { get; set; }
    }
}

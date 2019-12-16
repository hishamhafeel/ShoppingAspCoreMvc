using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class OrderItemsModel
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductSubTotal { get; set; }
    }
}

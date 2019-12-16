using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class UpdateOrderItemViewModel
    {
        [Display(Name = "Order Item ID")]
        public int Id { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Sub-Total")]
        public decimal SubTotal { get; set; }

        public Order Order { get; set; }
    }
}

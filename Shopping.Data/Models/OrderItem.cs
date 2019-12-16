using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping.Data.Models
{
    public class OrderItem
    {
        [Display(Name="Order Item ID")]
        public int Id { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(maximum:10, minimum:0)]
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
        public Order Order { get; set; }
    }
}

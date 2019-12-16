using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopping.Data.Models
{
    public class Order
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}

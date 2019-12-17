using Shopping.Core.Domain.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shopping.ViewModels
{
    public class ViewOrderViewModel
    {

        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }

        public List<OrderItem> OrderItem { get; set; }
    }
}

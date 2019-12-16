using Shopping.Core.BO;
using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class OrderDetailsViewModel
    {
       [Display(Name="Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public List<OrderItemBO> OrderItems { get; set; }

        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }


        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

    }
}

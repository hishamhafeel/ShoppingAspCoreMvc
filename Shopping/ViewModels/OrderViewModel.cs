using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Item Total Price")]
        public decimal OrderTotal { get; set; }

        [Display(Name = "Order Total")]
        public decimal OrderFinalTotal { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public List<SelectListItem> CustomerNameList { get; set; }

        [Display(Name = "Product Name")]
        public List<SelectListItem> ProductNameList { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public int SelectedProductId { get; set; }

        public int BuyQuantity { get; set; }

        public string ProductNameInOrderItems { get; set; }

        public Product Product { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}

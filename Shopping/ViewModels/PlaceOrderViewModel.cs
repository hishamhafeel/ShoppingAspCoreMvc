using Microsoft.AspNetCore.Mvc.Rendering;
using Shopping.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.ViewModels
{
    public class PlaceOrderViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }
        
        [Display(Name = "Customer Name")]
        public List<SelectListItem> CustomerNameList { get; set; }

        [Required(ErrorMessage = "Customer Name is required.")]
        public int SelectedCustomerId { get; set; }

    }
}

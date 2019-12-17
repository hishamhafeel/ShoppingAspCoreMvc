using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping.Core.Domain.Product
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Product Quantity In Stock")]
        public decimal ProductQtyInStock { get; set; }

        [Display(Name = "Product Unit Price")]
        public decimal ProductUnitPrice { get; set; }
    }
}

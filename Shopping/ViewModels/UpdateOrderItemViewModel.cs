using Shopping.Core.Domain.Order;
using Shopping.Core.Domain.Product;
using System.ComponentModel.DataAnnotations;

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

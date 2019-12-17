using System.ComponentModel.DataAnnotations;

namespace Shopping.Core.Domain.Order
{
    public class OrderItem
    {
        [Display(Name = "Order Item ID")]
        public int Id { get; protected set; }

        public Product.Product Product { get; protected set; }

        [Required]
        [Range(maximum: 10, minimum: 0)]
        public int Quantity { get; protected set; }
        public decimal UnitPrice { get; protected set; }
        public decimal SubTotal { get; protected set; }
        public Order Order { get; protected set; }
    }
}

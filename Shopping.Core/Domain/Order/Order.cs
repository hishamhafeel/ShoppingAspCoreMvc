using Shopping.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shopping.Core.Domain.Order
{
    public class Order
    {
        private int customerId;
        private decimal orderTotal;
        private ICollection<OrderItem> orderItems;

        [Display(Name = "Order ID")]
        public int OrderId { get; protected set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; protected set; }

        public ICollection<OrderItem> OrderItems {
            get
            {
                return orderItems;
            }
            protected set
            {
                if (value == null || value.Count == 0)
                {
                    throw new OrderItemNotFoundException();
                }
                orderItems = value;
            }
        }

        [Display(Name = "Order Total")]
        public decimal OrderTotal
        {
            get
            {
                return orderTotal;
            }
            protected set
            {
                if (value > 10000)
                {
                    throw new OrderTotalExceededException();
                }
                orderTotal = value;
            }
        }

        public int CustomerId
        {
            get {
                return customerId;
            }
            protected set {
                if (value <= 0)
                {
                    throw new CustomerNotFoundException();
                }
                customerId = value;
            }
        }

        [ForeignKey(nameof(CustomerId))]
        public Customer.Customer Customer { get; protected set; }

        public Order(DateTime orderDate, decimal orderTotal, int customerId, List<OrderItem> orderItems)
        {
            OrderDate = orderDate;
            OrderTotal = orderTotal;
            CustomerId = customerId;
            OrderItems = orderItems;
        }
        public Order Create(Order order)
        {
            if(order == null)
            {
                throw new OrderNotFoundException();
            }
           
            return this;
        }
    }
}

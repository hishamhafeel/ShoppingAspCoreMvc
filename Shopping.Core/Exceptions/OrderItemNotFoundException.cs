using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.Exceptions
{
    public class OrderItemNotFoundException : Exception
    {
        public OrderItemNotFoundException() : base("Order Item that has been requested is not found!")
        {

        }
    }
}

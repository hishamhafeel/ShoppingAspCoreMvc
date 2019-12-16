using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException() : base("Order that has been requested is not found!")
        {

        }
    }
}

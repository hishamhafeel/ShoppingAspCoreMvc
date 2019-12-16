using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.Exceptions
{
    public class QuantityInvalidException : Exception
    {
        public QuantityInvalidException() : base("Quantity value entered is invalid. Please enter quantity below 10")

        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.Exceptions
{
    public class NoItemInStockException : Exception
    {
        public NoItemInStockException() : base("There are no items in stock!")
        {

        }
    }
}

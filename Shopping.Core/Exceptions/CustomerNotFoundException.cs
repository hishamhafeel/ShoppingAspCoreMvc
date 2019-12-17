using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.Exceptions
{
    class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException() : base("Customer was not found. Please choose a customer.")
        {

        }
    }
}

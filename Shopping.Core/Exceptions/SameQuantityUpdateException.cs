using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Core.Exceptions
{
    public class SameQuantityUpdateException : Exception
    {
        public SameQuantityUpdateException() : base("The quantity entered is the same as existing quantity")
        {

        }
    }
}

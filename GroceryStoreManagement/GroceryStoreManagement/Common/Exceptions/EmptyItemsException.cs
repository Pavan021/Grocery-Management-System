using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreManagement.Common
{
    public class EmptyItemsException : Exception
    {
        public EmptyItemsException(string message) : base(message)
        {

        }
    }
}
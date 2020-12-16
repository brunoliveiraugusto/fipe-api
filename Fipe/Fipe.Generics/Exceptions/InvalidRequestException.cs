using System;
using System.Collections.Generic;
using System.Text;

namespace Fipe.Generics.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string message) : base(message)
        {

        }
    }
}

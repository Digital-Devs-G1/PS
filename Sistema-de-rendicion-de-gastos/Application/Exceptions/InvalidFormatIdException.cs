using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidFormatIdException : Exception
    {
        public InvalidFormatIdException() : base() { }
        public InvalidFormatIdException(string message) : base(message) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidFormatIdException : Exception
    {
        private static readonly string description = "El id debe ser mayor a 0. ";
        public InvalidFormatIdException()
        : base(description)
        { }

        public InvalidFormatIdException(string message) 
            : base(description + message) 
        { }
    }
}

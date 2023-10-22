using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NoFilterMatchesException : Exception
    {
        private static readonly string description =
            "No se encontraron registros. ";
        public NoFilterMatchesException() : base(description)
        { }

        public NoFilterMatchesException(string message)
            : base(description + message)
        { }
    }
}

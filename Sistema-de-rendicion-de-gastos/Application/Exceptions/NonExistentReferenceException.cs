using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class NonExistentReferenceException : Exception
    {
        private static readonly string description = 
            "El id no corresponde a ningun elemento registrado. " ;
        public NonExistentReferenceException() : base(description)
        { }

        public NonExistentReferenceException(string message) 
            : base(description + message) 
        { }
    }
}

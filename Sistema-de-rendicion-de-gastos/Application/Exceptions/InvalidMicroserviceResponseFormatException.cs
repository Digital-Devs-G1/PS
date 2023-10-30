using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidMicroserviceResponseFormatException : Exception
    {
        private static readonly string description = 
            "La informacion recibida a raiz de la comunicacion " +
            "entre microservicios no tiene el formato esperado. URL: ";

        public InvalidMicroserviceResponseFormatException(string url)
            : base(description + url)
        { }

        public InvalidMicroserviceResponseFormatException(
            string url,
            string message
            )
            : base(description + url + message)
        { }
    }
}

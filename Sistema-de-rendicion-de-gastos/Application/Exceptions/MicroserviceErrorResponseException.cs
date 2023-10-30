using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class MicroserviceErrorResponseException : Exception
    {
        private static readonly string description =
            "La informacion recibida a raiz de la comunicacion " +
            "entre microservicios genero un status code no esperado. URL: ";

        public MicroserviceErrorResponseException(string url)
            : base(description + url)
        { }

        public MicroserviceErrorResponseException(
            string url,
            string message
            )
            : base(description + url + message)
        { }
    }
}

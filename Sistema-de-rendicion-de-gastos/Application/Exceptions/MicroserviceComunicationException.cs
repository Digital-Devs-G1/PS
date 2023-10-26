using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class MicroserviceComunicationException : Exception
    {
        private static readonly string description = 
            "No fue posible la comunicacion entre microservicios. ";
        public MicroserviceComunicationException()
        : base(description)
        { }

        public MicroserviceComunicationException(string message)
            : base(description + message)
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class InvalidTokenInformation : Exception
    {
        private static readonly string description =
           "";
        public InvalidTokenInformation() : base(description)
        { }

        public InvalidTokenInformation(string message)
            : base(description + message)
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Response.StatusResponseNS
{
    public class ErrorResponse : StatusResponse
    {
        public ErrorResponse(int code, string message) : base(code, message)
        {
        }

        public override bool IsError()
        {
            return false;
        }
    }
}

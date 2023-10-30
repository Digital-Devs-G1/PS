using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IMicroservices.Generic
{
    public interface IGetMicroserviceClient
    {
        public Task<HttpResponseMessage> Get(string url);
    }
}

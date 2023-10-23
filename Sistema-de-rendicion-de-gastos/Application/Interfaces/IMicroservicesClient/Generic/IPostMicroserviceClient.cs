using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IMicroservices.Generic
{
    public interface IPostMicroserviceClient
    {
        public Task<HttpResponseMessage> Post(string url, string body);
    }
}

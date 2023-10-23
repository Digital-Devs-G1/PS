using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories.Microservices
{
    public interface IMicroserviceClient
    {
        public Task<string> sendRequest(string apiUrl);
    }
}

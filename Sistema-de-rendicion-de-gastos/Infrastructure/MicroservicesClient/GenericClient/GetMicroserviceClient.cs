using Application.Interfaces.IMicroservices.Generic;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.MicroservicesClient.GenericClient
{
    public class GetMicroserviceClient :
        MicroserviceClient,
        IGetMicroserviceClient
    {
        public GetMicroserviceClient(IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
        }

        protected override async Task<HttpResponseMessage> HttpMethod(
            HttpClient client,
            string url
            )
        {
            return await client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> Get(string url)
        {
            return await SendRequest(url);
        }
    }
}

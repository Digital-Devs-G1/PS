using Application.Interfaces.IMicroservices.Generic;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace Infrastructure.MicroservicesClient.GenericClient
{
    public class PostMicroservicClient :
        MicroserviceClient,
        IPostMicroserviceClient
    {
        private string _body;

        public PostMicroservicClient(IHttpContextAccessor httpContextAccessor)
            : base(httpContextAccessor)
        {
        }

        protected override async Task<HttpResponseMessage> HttpMethod(
            HttpClient client,
            string url
            )
        {
            var content = new StringContent(_body, Encoding.UTF8, "application/json");
            return await client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> Post(string url, string body)
        {
            _body = body;
            return await SendRequest(url);
        }
    }
}

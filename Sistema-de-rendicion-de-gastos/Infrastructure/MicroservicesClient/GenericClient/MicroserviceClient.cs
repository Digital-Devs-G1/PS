using Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.MicroservicesClient.GenericClient
{
    public abstract class MicroserviceClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        protected string _token { get; set; }

        public MicroserviceClient(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected async Task<HttpResponseMessage> SendRequest(string url)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", token.ToString());
                    return await HttpMethod(client, url);
                }
                catch (Exception ex)
                {
                    throw new MicroserviceComunicationException(
                        $"Url: {url}. Error: {ex.Message}"
                    );
                }
            }
        }

        protected abstract Task<HttpResponseMessage> HttpMethod(
            HttpClient client,
            string url
       );
    }
}
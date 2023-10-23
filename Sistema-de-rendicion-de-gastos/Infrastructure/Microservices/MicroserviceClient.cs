
using Infrastructure.Authentication.Constants;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
using Application.Interfaces.IRepositories.Microservices;

namespace Infrastructure.Microservices
{
    public abstract class MicroserviceClient : IMicroserviceClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MicroserviceClient(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected async Task<string> sendRequest(string apiUrl)
        {

            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            /*string employee = new JwtHelper().GetClaimValue(token, TypeClaims.Id);
            string rol = new JwtHelper().GetClaimValue(token, TypeClaims.Rol);
            string email = new JwtHelper().GetClaimValue(token, TypeClaims.Email);*/

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.DefaultRequestHeaders.Add("Authorization", token.ToString());
                    HttpResponseMessage response = HttpMethod(apiUrl, client);

                    if (response.IsSuccessStatusCode)
                    {

                        return await response.Content.ReadAsStringAsync();
                    }
                    
                    throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }

        protected abstract Task<HttpResponseMessage> HttpMethod(
            HttpClient client, 
            string url
       );
    }

    public class MicroserviceGetClient : MicroserviceClient
    {
        public MicroserviceGetClient(IHttpContextAccessor httpContextAccessor) 
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

    }
}

using Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.MicroservicesClient.GenericClient
{
    public abstract class MicroserviceClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MicroserviceClient(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected async Task<HttpResponseMessage> SendRequest(string url)
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            /*string employee = new JwtHelper().GetClaimValue(token, TypeClaims.Id);
            string rol = new JwtHelper().GetClaimValue(token, TypeClaims.Rol);
            string email = new JwtHelper().GetClaimValue(token, TypeClaims.Email);*/

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //client.DefaultRequestHeaders.Add("Authorization", token.ToString());
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
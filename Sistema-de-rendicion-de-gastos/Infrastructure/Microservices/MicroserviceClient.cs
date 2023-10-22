
namespace Infrastructure.Microservices
{
    public class MicroserviceClient
    { 
        public async Task<string> sendRequest(string apiUrl)
        {   
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {

                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

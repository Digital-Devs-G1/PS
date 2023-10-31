
using Application.DTO.Response.Microservices;
using Application.Exceptions;
using Application.Interfaces.IMicroservices.Generic;
using Application.Interfaces.IMicroservicesClient;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Infrastructure.MicroservicesClient
{
    public class CompanyClient : ICompanyClient
    {
        private readonly IGetMicroserviceClient _getClient;

        public CompanyClient(IGetMicroserviceClient getClient)
        {
            _getClient = getClient;
        }

        public async Task<int> GetDepartmentId()
        {
            string url = "https://localhost:7296/api/Employee/GetDepartmentByEmployee";
            HttpResponseMessage response = await _getClient.Get(url);
            
            if (response.IsSuccessStatusCode)
            {
                DepartmentResponse department;
                string jsonResponse = await response.Content.ReadAsStringAsync();
                try
                {
                    department = JsonConvert.DeserializeObject<DepartmentResponse>(jsonResponse);
                }
                catch (Exception)
                {
                    throw new InvalidMicroserviceResponseFormatException(
                        url,
                        "Formato de DepartmentReponse invalido en la respuesta entre microservicios."
                    );
                }
                if (department.DepartmentId < 1)
                    throw new UnprocesableContentException("Id de departament con formato invalido en respuesta de microservicio");
                return department.DepartmentId;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NotFoundException("" +
                    "El empleado no pertenece a ningun departamento"
                );
            }
            string json = await response.Content.ReadAsStringAsync();
            try
            {
                throw new MicroserviceErrorResponseException(
                    url,
                    "Code " + response.StatusCode.ToString() + ": " + json
                );
            } catch (Exception)
            {
                throw new UnprocesableContentException("Error en el formate de respuesta del microservico con statusCode " + response.StatusCode);
            }
        }
    }
}


using Application.DTO.Response.Microservices;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IMicroservices.Generic;
using Application.Interfaces.IMicroservicesClient;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Infrastructure.MicroservicesClient
{
    public class CompanyApprover : ICompanyApprover
    {
        private readonly IGetMicroserviceClient _getClient;

        public CompanyApprover(IGetMicroserviceClient getClient)
        {
            _getClient = getClient;
        }

        public async Task<int> GetApproverId()
        {
            string url = "https://localhost:7296/api/Employee/ObtenerAprobador";
            return await GetApprover(url);
        }

        public async Task<int> GetNextApproverId(double amount)
        {
            string url = "https://localhost:7296/api/Employee/NextApprover?amount=" + amount.ToString();
            return await GetApprover(url);
        }

        private async Task<int> GetApprover(string url)
        {
            HttpResponseMessage response = await _getClient.Get(url);
            
            if (response.IsSuccessStatusCode)
            {
                DepartmentResponse department;
                string jsonResponse = await response.Content.ReadAsStringAsync();
                int approverId;
                try
                {
                    // department = JsonConvert.DeserializeObject<DepartmentResponse>(jsonResponse);
                    approverId = int.Parse(jsonResponse);
                }
                catch (Exception)
                {
                    throw new InvalidMicroserviceResponseFormatException(
                        url,
                        "Formato invalido en la respuesta entre microservicios para obtener aprovador."
                    );
                }
                if (approverId < 0) /* El cero indica que no necesita aprobacion */
                    throw new UnprocesableContentException("Id de aprovador con formato invalido en respuesta de microservicio");
                return approverId;
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

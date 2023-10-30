using Application.Dto.Response.StatusResponseNS;
using Application.DTO.Response.Microservices;
using Application.Exceptions;
using Application.Interfaces.IMicroservices.Generic;
using Application.Interfaces.IMicroservicesClient;
using Newtonsoft.Json;
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

        public async Task<int> GetDepartmentId(int employeeId)
        {
            string url = "https://localhost:7296/api/Department/GetDepartment/" + employeeId;
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
                        "Se esperaba un entero para el id de departamento"
                    );
                }
                return department.DepartmentId;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new NonExistentReferenceException("" +
                    "El empleado no pertenece a ningun departamento"
                );
            }
            string json = await response.Content.ReadAsStringAsync();
            ErrorResponse error = JsonConvert.DeserializeObject<ErrorResponse>(json);
            throw new MicroserviceErrorResponseException(
                url,
                "Code " + response.StatusCode.ToString() + ": " + error.Message
            );
        }

    }
}

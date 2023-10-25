using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class ValidateEmployeeId
    {
        public static async Task<bool> ValidateEmployeeExists(int employeeId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("URL_DEL_MICROSERVICIO_COMPANY");

                var response = await client.GetAsync($"/api/employees/{employeeId}");

                return response.IsSuccessStatusCode;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IMicroservicesClient
{
    public interface ICompanyClient
    {
        public Task<int> GetDepartmentId();    
    }
}

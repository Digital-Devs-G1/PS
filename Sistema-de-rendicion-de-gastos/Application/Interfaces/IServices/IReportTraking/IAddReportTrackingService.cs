using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices.IReportTraking
{
    public interface IAddReportTrackingService
    {
        public Task AddCreationTracking(int reportId, int employeeId);

        public Task AddAcceptTracking(int reportId, int employeeId);

        public Task AddDismissTracking(int reportId, int employeeId);
    }
}

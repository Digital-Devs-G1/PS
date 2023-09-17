using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Inserts
{
    public enum ReportOperationEnum
    {
        Create = 1,
        Review,
        Approval,
        Refuse
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Response
{
    public class RealReport
    {
        private Report _report;
        public IList<VariableFieldResponse> VariableFields { get; set; }

        public RealReport(Report report, IList<VariableFieldResponse> variableFields)
        {
            _report = report;
            VariableFields = variableFields;
        }
        public int ReportId { get { return _report.ReportId; } set { _report.ReportId = value; } }

        public string Description { get { return _report.Description; } set { _report.Description = value; } }

        public int Amount { get { return _report.Amount; } set { _report.Amount = value; } }

        //public ICollection<ReportTracking> Trackings { get { return _report.Trackings; } set { _report.Trackings = value; } }
        //public ICollection<VariableField> Fields { get { return _report.ReportId; } set { _report.Fields = value; } }
    }
}

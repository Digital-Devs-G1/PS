using Domain.Entities;
using System;

namespace Application.DTO.Response.ReportNS
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

        public double Amount { get { return _report.Amount; } set { _report.Amount = value; } }
    }
}

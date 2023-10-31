using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Query
{
    public class ReportTemplateFieldQuerys : IReportTemplateFieldQuerys
    {
        public readonly ReportsDbContext _context;

        public ReportTemplateFieldQuerys(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task<IList<ReportTemplateField>> GetResportTemplatesFieldsByDepartment(
            int tempId,
            int departmentId
            )
        {
            return await _context
                .ReportTemplateField
                .Include(ft => ft.ReportTemplateNav)
                .Where( ft => 
                    ft.ReportTemplateId == tempId &&
                    ft.ReportTemplateNav.DepartmentId == departmentId
                    )
                .ToListAsync();
        }

        public async Task<ReportTemplateField> GetFirstTemplateById(int tempId)
        {
            return await _context.ReportTemplateField.Where(ft => ft.ReportTemplateId == tempId).FirstOrDefaultAsync();
        }

        public async Task<ReportTemplateField> GetTemplate(string tempName, int tempId)
        {
            var result = await _context.ReportTemplateField.FindAsync(new object[] { tempId, tempName });
            return result;
        }
    }
}

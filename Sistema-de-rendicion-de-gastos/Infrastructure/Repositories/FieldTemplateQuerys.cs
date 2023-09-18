using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FieldTemplateQuerys : IFieldTemplateQuerys
    {
        public readonly ReportsDbContext _context;

        public FieldTemplateQuerys(ReportsDbContext context)
        {
            _context = context;
        }

        public async Task<IList<FieldTemplate>> GetTemplatesById(int tempId)
        {
            return await _context.FieldTemplates.Where(ft => ft.FieldTemplateId == tempId)
                                                .ToListAsync();
        }
    }
}

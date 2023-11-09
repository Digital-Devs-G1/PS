using Application.Interfaces.IRepositories.IQuery;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepositoryQuerys<T> : IGenericRepositoryQuerys<T> where T : BaseEntity
    {
        private readonly ReportsDbContext _context;
        private readonly DbSet<T> entities;

        public GenericRepositoryQuerys(ReportsDbContext context)
        {
            this._context = context;
            entities = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await entities.FindAsync(id);
        }
    }
}

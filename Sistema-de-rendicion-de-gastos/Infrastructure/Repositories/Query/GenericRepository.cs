using Application.Interfaces.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Query
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ReportsDbContext _dbContext;

        public GenericRepository(ReportsDbContext context)
        {
            this._dbContext = context;
        }

        private DbSet<T> Entity()
        {
            return _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entity().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Entity().FindAsync(id);
        }
        public async Task Add(T entity)
        {
            Entity().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Entity().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await GetByIdAsync(id);
            Entity().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}

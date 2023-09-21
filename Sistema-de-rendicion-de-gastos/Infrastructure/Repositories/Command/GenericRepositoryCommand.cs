using Application.Interfaces.IRepositories.ICommand;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Command
{
    public class GenericRepositoryCommand<T> : IGenericRepositoryCommand<T> where T : BaseEntity
    {
        private readonly ReportsDbContext context;
        private readonly DbSet<T> entities;

        public GenericRepositoryCommand(ReportsDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            entities.Add(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Add(IList<T> entities)
        {
            foreach(var entity in entities)
                context.Add(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(T entity)
        {
            entities.Update(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(T entity)
        {
            entities.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}

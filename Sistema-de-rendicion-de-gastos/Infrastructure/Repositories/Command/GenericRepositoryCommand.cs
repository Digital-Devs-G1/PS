using Application.Dto.Response.StatusResponseNS;
using Application.Interfaces.IRepositories.ICommand;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Data.Entity.Validation;

namespace Infrastructure.Repositories.Command
{
    public class GenericRepositoryCommand<T> : IGenericRepositoryCommand<T> where T : BaseEntity
    {
        private readonly ReportsDbContext context;
        private readonly DbSet<T> entities;
        private readonly IRepositoryResponseFactory _responseFactory;

        public GenericRepositoryCommand(
            ReportsDbContext context, 
            IRepositoryResponseFactory responseFactory
            )
        {
            this.context = context;
            entities = context.Set<T>();
            _responseFactory = responseFactory;
        }
        
        public async Task<int> CommitAsync(ConcurrentBag<StatusResponse> errors)
        {
            int written = 0;

            try
            {
                written = await context.SaveChangesAsync();
            } 
            catch (DbUpdateConcurrencyException) 
            {
                errors.Add(_responseFactory.DbUpdateConcurrencyException());
            } 
            catch (DbUpdateException)
            {
                errors.Add(_responseFactory.DbUpdateConcurrencyException());
            } catch (DbEntityValidationException)
            {
                errors.Add(_responseFactory.DbEntityValidationException());
            }
            catch (NotSupportedException)
            {
                errors.Add(_responseFactory.NotSupportedException());
            }
            catch (ObjectDisposedException)
            {
                errors.Add(_responseFactory.ObjectDisposedException());
            }
            catch (InvalidOperationException)
            {
                errors.Add(_responseFactory.InvalidOperationException());
            }
            return written;
        }

        public async Task<int> AddAndCommit(
            ConcurrentBag<StatusResponse> errors,
            T entity
            )
        {
            entities.Add(entity);
            return await CommitAsync(errors);
        }

        public async Task<int> AddAndCommit(
            ConcurrentBag<StatusResponse> errors, 
            IList<T> entities
            )
        {
            foreach(var entity in entities)
                context.Add(entity);
            return await CommitAsync(errors);
        }

        public async Task<int> UpdateAndCommit(
            ConcurrentBag<StatusResponse> errors, 
            T entity
            )
        {
            entities.Update(entity);
            return await CommitAsync(errors);
        }

        public async Task<int> DeleteAndCommit(
            ConcurrentBag<StatusResponse> errors,
            T entity
            )
        {
            entities.Remove(entity);
            return await CommitAsync(errors);
        }
    }
}
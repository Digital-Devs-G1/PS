using Application.Dto.Response.StatusResponseNS;
using System.Collections.Concurrent;

namespace Application.Interfaces.IRepositories.ICommand
{
    public interface IGenericRepositoryCommand<T> where T : class
    {
        public Task<int> SaveChangesAsync(ConcurrentBag<StatusResponse> errors);

        public Task<int> AddAndCommit(ConcurrentBag<StatusResponse> errors, T entity);

        public Task<int> AddAndCommit(ConcurrentBag<StatusResponse> errors, IList<T> entities);

        public Task<int> UpdateAndCommit(ConcurrentBag<StatusResponse> errors, T entity);

        public Task<int> DeleteAndCommit(ConcurrentBag<StatusResponse> errors, T entity);

    }
}
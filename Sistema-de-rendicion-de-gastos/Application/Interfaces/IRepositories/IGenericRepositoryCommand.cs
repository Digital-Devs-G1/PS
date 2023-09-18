using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IGenericRepositoryCommand<T> where T : class
    {
        public Task<bool> Add(T entity);
        public Task<bool> Add(IList<T> entities);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(T entity);
    }
}

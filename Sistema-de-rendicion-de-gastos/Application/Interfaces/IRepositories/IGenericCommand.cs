using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IGenericCommand<T> where T : class
    {
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(T entity);
    }
}

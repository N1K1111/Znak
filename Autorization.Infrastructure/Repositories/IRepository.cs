using Autorization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid id);
        Task<List<User>> GetByFilter(string filter);
        Task<User> Get(string email);
        Task<T> Create(T item);
        Task Update(T item);
        Task Delete(Guid id);

        Task Save();
    }
}

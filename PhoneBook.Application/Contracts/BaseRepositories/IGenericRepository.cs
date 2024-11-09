using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contracts.BaseRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id,string userId);
        Task<IReadOnlyList<T>> GetAll(string userId);
        Task<bool> Exist(int id, string userId);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contracts.BaseRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id,int userId);
        Task<IReadOnlyList<T>> GetAll(int userId);
        Task<bool> Exist(int id, int userId);
        Task<T> Add(T entity, int userId);
        Task Update(T entity, int userId);
        Task Delete(T entity, int userId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(string id);
        Task<T> Add(T model);
        Task<bool> Delete(T model);
        Task<T> Update(T model);
    }
}

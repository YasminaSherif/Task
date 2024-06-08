using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Contracts
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<bool> CodeExists(string code);
        Task<Client?> GetClientDetailsById(string id);
    }
}

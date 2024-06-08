using DAL.Context;
using DAL.Models;
using DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClientProductRepository:Repository<ClientProduct>,IRepository<ClientProduct>
    {
        public ClientProductRepository(ApplicationContext context):base(context)
        {
            
        }
    }
}

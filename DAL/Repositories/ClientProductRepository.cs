using DAL.Context;
using DAL.Models;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClientProductRepository : Repository<ClientProduct>, IClientProductRepository
    {
        private readonly ApplicationContext _context;

        public ClientProductRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public async Task<ClientProduct?> GetClientProductDetailsById(string id)
        {
            var clientProduct = await _context.ClientProducts
                .Include(c => c.Client)
                .Include(c => c.Product)
                .SingleOrDefaultAsync(c => c.Id == id);

            return clientProduct;
        }


    }
}


using DAL.Context;
using DAL.Models;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ClientRepositiory : Repository<Client>, IClientRepository
    {
        private readonly ApplicationContext _context;

        public ClientRepositiory(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CodeExists(string code)
        {
            return await _context.Clients.AnyAsync(c => c.Code == code);
        }


        public async Task<Client?> GetClientDetailsById(string id)
        {
            var client = await _context.Clients
                .Include(c => c.ClientProducts)
                .ThenInclude(cp=> cp.Product)
                .SingleOrDefaultAsync(c => c.Id == id);

            if(client is not null)
            {
               client.ClientProducts=client.ClientProducts.OrderBy(p=>p.Product.Name).ToList();
            }
            return client;
        }
    }
}

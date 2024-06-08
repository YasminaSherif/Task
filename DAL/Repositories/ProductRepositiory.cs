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
    public class ProductRepositiory : Repository<Product>, IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepositiory(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductDetailsById(string id)
        {
          var product= await _context.Products
                .Include(c => c.ClientProducts)
                .SingleOrDefaultAsync(c => c.Id == id);
            return product;
        }
    }
}

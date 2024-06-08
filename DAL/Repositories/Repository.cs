using DAL.Context;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        protected DbSet<T> dbSet;


        protected Repository(ApplicationContext context)
        {
            _context = context;
            dbSet=context.Set<T>();
        }

        public async Task<T> Add(T model)
        {
            await dbSet.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> Delete(T model)
        {
            
             dbSet.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }
       
        public async Task<T?> GetById(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> Update(T model)
        {
            dbSet.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        
    }
}

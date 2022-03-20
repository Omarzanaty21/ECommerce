using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEB.Data;
using WEB.Interfaces;
using WEB.Models;

namespace WEB.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private readonly DatabaseContext _context;
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetItemsAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetItemByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);
        }

        public async Task RemoveAsync(int id)
        {
            // var model = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(await GetItemByIdAsync(id));
        }

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetItemsQuery()
        {
            var itemsQuery = _context.Set<T>();

            return itemsQuery;
        }
    }
}
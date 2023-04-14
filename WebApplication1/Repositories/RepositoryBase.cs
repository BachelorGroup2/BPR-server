using BPR.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPR.API.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private readonly MyDBContext _context;

        public RepositoryBase(MyDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}

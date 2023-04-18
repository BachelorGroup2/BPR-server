using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KamtjatkaAPI.Models;

namespace KamtjatkaAPI.Repositories
{
        public class RepositoryBase<T> : IRepositoryBase<T> where T : class
        {

            private readonly vujeeaxiContext _context;

            public RepositoryBase(vujeeaxiContext context)
            {
                _context = context;
            }

            public async Task<T> Create(T entity)
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }

            public async Task<T> Delete(int id)
            {
                var entityToDelete = await _context.Set<T>().FindAsync(id);
                if (entityToDelete != null)
                {
                    _context.Set<T>().Remove(entityToDelete);
                    await _context.SaveChangesAsync();
                    return entityToDelete;
                }

                return null;
            }

            public async Task<IEnumerable<T>> Get()
            {
                return await _context.Set<T>().ToListAsync();
            }

            public async Task<T> Get(int id)
            {
                return await _context.Set<T>().FindAsync(id);
            }

            public async Task Update(T entity)
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }


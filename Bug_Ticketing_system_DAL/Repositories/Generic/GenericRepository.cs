using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System_DAL;
using Microsoft.EntityFrameworkCore;

namespace Bug_Ticketing_system_DAL.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BugDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(BugDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

        }
        public void DeleteAsync(Guid id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }

}

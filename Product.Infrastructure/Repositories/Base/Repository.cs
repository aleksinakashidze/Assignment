using Microsoft.EntityFrameworkCore;
using Product.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T:class
    {
        protected readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await GetById(id);
        }
       
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetById(id);
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteWithRangeAsync(IEnumerable<T> list)
        {
           
            _dbContext.RemoveRange(list);
            await _dbContext.SaveChangesAsync();
        }


        public IQueryable<T> Where(Expression<Func<T,bool>> filter)
        {
            return   _dbContext.Set<T>().Where(filter);
        }


        private async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}

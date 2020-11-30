using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechCodeLib.DAL;
using TechCodeLib.DAL.Entities;
using TechCodeLib.Repositories.Contract;

namespace TechCodeLib.Repositories
{
    public class TechCodeLibRepository<TEntity> : ITechCodeLibRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TechCodeLibContext _context;
        private DbSet<TEntity> _dbSet;

        public TechCodeLibRepository(TechCodeLibContext context)
        {
            _context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this._dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public void DeleteRange(Func<TEntity, bool> where)
        {
            var entitiesToDelete = _dbSet.Where(where);
            _dbSet.RemoveRange(entitiesToDelete);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIDAsync(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(en => en.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.FirstOrDefaultAsync(where);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbSet;
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.SingleOrDefaultAsync(where);
        }

        public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> where, params string[] include)
        {
            IQueryable<TEntity> query = _dbSet.AsQueryable();
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(where);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}

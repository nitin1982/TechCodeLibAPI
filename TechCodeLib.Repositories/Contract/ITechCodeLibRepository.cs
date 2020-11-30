using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechCodeLib.DAL.Entities;

namespace TechCodeLib.Repositories.Contract
{
    public interface ITechCodeLibRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);

        void Delete(TEntity entity);
        void DeleteRange(Func<TEntity, bool> where);

        //IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        //TEntity GetByID(int id);
        Task<TEntity> GetByIDAsync(int id);

        //IEnumerable<TEntity> GetFiltered(Func<TEntity, bool> where);
        Task<IEnumerable<TEntity>> GetFilteredAsync(Expression<Func<TEntity, bool>> where);

        //TEntity GetFirst(Func<TEntity, bool> predicate);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> where);

        IQueryable<TEntity> GetQueryable();

        
        IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> where, params string[] include);

        //TEntity GetSingle(Func<TEntity, bool> predicate);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> where);

        void Update(TEntity entity);
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Droplab.Data.Repositories.Interfaces
{
  public interface IRepository<TEntity, VO> 
  where TEntity : class
  where VO : class
    {
        Task<TEntity> Get(long id);
        Task<IEnumerable<TEntity>> GetAll(int offset, int limit);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int Count();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> ToEntity(VO vo);
        VO ToVo(TEntity entity);
        

    }
}


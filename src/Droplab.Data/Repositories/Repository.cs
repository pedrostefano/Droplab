using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Droplab.Data.Models;
using Droplab.Data.Repositories.Interfaces;
using Droplab.VOs.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Droplab.Data.Repositories
{
    public abstract class Repository<TEntity, VO> : IRepository<TEntity, VO> 
    where TEntity : BaseEntity, new()
    where VO : BaseVO, new()
    
    {
        protected readonly DroplabDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(DroplabDbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }   

        public virtual async Task<TEntity> Get(long id) => await _entities.FindAsync(id);
        public virtual async Task<IEnumerable<TEntity>> GetAll(int offset, int limit){
            
            offset = offset == 0 ? offset = 1 : offset;
            limit = limit == 0 ? int.MaxValue : limit;

            var entities = await _entities.OrderBy(o => o.Id)
                .Skip((offset - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return entities;            
        }

        public virtual void Add(TEntity entity){
            _entities.Add(entity);
        } 
        public virtual void AddRange(IEnumerable<TEntity> entities) => _entities.AddRange(entities);
        public virtual void Update(TEntity entity) => _entities.Update(entity);
        public virtual void UpdateRange(IEnumerable<TEntity> entities) => _entities.UpdateRange(entities);
        public virtual void Remove(TEntity entity) => _entities.Remove(entity);
        public virtual void RemoveRange(IEnumerable<TEntity> entities) => _entities.RemoveRange(entities);
        public virtual int Count() => _entities.Count();
        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _entities.Where(predicate);
        public virtual TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate) => _entities.SingleOrDefault(predicate);
        public abstract Task<TEntity> ToEntity(VO vo);
        public abstract VO ToVo(TEntity entity);
    }
}
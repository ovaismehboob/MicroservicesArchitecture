using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EFRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly DbContext _dbContext;

        public EFRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> All<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().AsQueryable();

        }
      
        public virtual bool Contains<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _dbContext.Set<T>().Count<T>(predicate) > 0;
        }
        public virtual void Create<T>(T TObject) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(TObject);
        }
        public virtual async void CreateAsync<T>(T TObject) where T : BaseEntity
        {
            await _dbContext.Set<T>().AddAsync(TObject);
        }
        public virtual void Delete<T>(T TObject) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(TObject);
        }
        public virtual void Delete<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            var objects = Filter<T>(predicate);
            foreach (var obj in objects)
                _dbContext.Set<T>().Remove(obj);
        }

        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _dbContext.Set<T>().Where<T>(predicate).AsEnumerable<T>();
        }
        public virtual IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : BaseEntity
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? _dbContext.Set<T>().Where<T>(filter).AsQueryable() : _dbContext.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsEnumerable();
        }
        public virtual async Task<IEnumerable<T>> FilterAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return await _dbContext.Set<T>().Where<T>(predicate).ToListAsync<T>();
        }
        public virtual async Task<IEnumerable<T>> FilterAsync<T>(Expression<Func<T, bool>> filter, int index = 0, int size = 50) where T : BaseEntity
        {
            int skipCount = index * size;
            var _resetSet = filter != null ? _dbContext.Set<T>().Where<T>(filter).AsQueryable() : _dbContext.Set<T>().AsQueryable();
            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            return await _resetSet.ToListAsync<T>();
        }
        public virtual T Find<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _dbContext.Set<T>().FirstOrDefault<T>(predicate);
        }
        public virtual async Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync<T>(predicate);
        }
        public virtual T Single<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            return All<T>().FirstOrDefault(expression);

        }
        public virtual async Task<T> SingleAsync<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            return await All<T>().FirstOrDefaultAsync(expression);
        }
        public void Update<T>(T TObject) where T : BaseEntity
        {
             var entry = _dbContext.Entry(TObject);
             _dbContext.Set<T>().Attach(TObject);
             entry.State = EntityState.Modified;
        }

        
    }
}

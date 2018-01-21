using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        void CreateAsync<T>(T TObject) where T : BaseEntity;
        Task<IEnumerable<T>> FilterAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        Task<IEnumerable<T>> FilterAsync<T>(Expression<Func<T, bool>> filter, int index = 0, int size = 50) where T : BaseEntity;
        Task<T> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        Task<T> SingleAsync<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
    }
}

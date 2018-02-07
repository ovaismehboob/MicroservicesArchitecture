using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<T> All<T>() where T : class;
        T Find<T>(Expression<Func<T, bool>> predicate) where T : class;
        T Single<T>(Expression<Func<T, bool>> expression) where T : class;
        bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class;
    }
}

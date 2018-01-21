using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        //IQueryable<T> All<T>() where T : BaseEntity;
        //void Create<T>(T TObject) where T : BaseEntity;
        //void Delete<T>(T TObject) where T : BaseEntity;
        //void Delete<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        //void Update<T>(T TObject) where T : BaseEntity;
        //IEnumerable<T> Filter<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        //IEnumerable<T> Filter<T>(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50) where T : BaseEntity;
        //T Find<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;
        //T Single<T>(Expression<Func<T, bool>> expression) where T : BaseEntity;
        //bool Contains<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity;

        IUnitOfWork UnitOfWork { get; }
    }
}

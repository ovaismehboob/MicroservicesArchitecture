using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vendor.Domain.Models.VendorModel;
using Vendor.Models.VendorModel;

namespace Vendor.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository
    {

        VendorDBContext _dbContext;


        public VendorRepository(VendorDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public VendorMaster Add(VendorMaster vendorMaster)
        {
            var res= _dbContext.Add(vendorMaster);
            return res.Entity;
        }

        public void Add(VendorDocument vendorDocument) => throw new NotImplementedException();
        public IQueryable<T> All<T>() where T : class => throw new NotImplementedException();
        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : class => throw new NotImplementedException();
        public void Delete(int vendorDocumentID) => throw new NotImplementedException();
        public T Find<T>(Expression<Func<T, bool>> predicate) where T : class => throw new NotImplementedException();
        public Task<VendorMaster> GetAsync(int vendorID) => throw new NotImplementedException();
        public T Single<T>(Expression<Func<T, bool>> expression) where T : class => throw new NotImplementedException();
        public void Update(VendorMaster vendorMaster) => throw new NotImplementedException();
    }
}

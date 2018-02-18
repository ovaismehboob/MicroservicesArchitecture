using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vendor.Domain.Models.VendorModel;
using Vendor.Models.VendorModel;
using static Infrastructure.Data.BaseEntity;

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
        
        public void AddDocument(VendorDocument vendorDocument)
        {
            var res = _dbContext.Add(vendorDocument);
        }

        public void Update(VendorMaster vendorMaster)
        {
            _dbContext.Entry(vendorMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public async Task<VendorMaster> GetAsync(int vendorID)
        {
            var vendorMaster = await _dbContext.VendorMaster.FindAsync(vendorID);
            if (vendorMaster != null)
            {
                await _dbContext.Entry(vendorMaster)
                    .Collection(i => i.VendorDocuments).LoadAsync();
            }
            return vendorMaster;
        }


        public IQueryable<T> All<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _dbContext.Set<T>().Count<T>(predicate) > 0;
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity
        {
            return _dbContext.Set<T>().FirstOrDefault<T>(predicate);
        }
        
    }
}

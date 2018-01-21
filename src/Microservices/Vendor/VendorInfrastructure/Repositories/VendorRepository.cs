using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vendor.Domain.Models.VendorModel;
using Vendor.Models.VendorModel;

namespace VendorInfrastructure.Repositories
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
        public Task<VendorMaster> GetAsync(int vendorID) => throw new NotImplementedException();
        public void Update(VendorMaster vendorMaster) => throw new NotImplementedException();
    }
}

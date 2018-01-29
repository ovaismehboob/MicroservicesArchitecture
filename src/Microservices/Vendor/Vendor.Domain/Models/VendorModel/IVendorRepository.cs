using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vendor.Models.VendorModel;
namespace Vendor.Domain.Models.VendorModel
{
    public interface IVendorRepository : IRepository<VendorMaster>
    {
        VendorMaster Add(VendorMaster vendorMaster);

        void Update(VendorMaster vendorMaster);

        Task<VendorMaster> GetAsync(int vendorID);

        void Add(VendorDocument vendorDocument);

        void Delete(int vendorDocumentID);
    }
}

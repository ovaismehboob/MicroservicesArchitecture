using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendor.API.ViewModels;
using Vendor.Models.VendorModel;

namespace Vendor.API.Notifications
{
    public class CreateVendorNotification : INotification
    {

        public VendorMaster _vendorVM;
        public CreateVendorNotification(VendorMaster vendorVM)
        {
            _vendorVM = vendorVM;
        }


    }

}

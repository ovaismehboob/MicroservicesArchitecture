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

        public VendorViewModel _vendorVM;
        public CreateVendorNotification(VendorViewModel vendorVM)
        {
            _vendorVM = vendorVM;
        }


    }

}

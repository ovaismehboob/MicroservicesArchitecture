using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Vendor.API.ViewModels;

namespace Vendor.API.Commands
{
    public class CreateVendorCommand : IRequest<bool>
    {

        [DataMember]
        public VendorViewModel VendorViewModel { get; set; }

        public CreateVendorCommand(VendorViewModel vendorViewModel)
        {
            VendorViewModel = vendorViewModel;
        }


    }
}

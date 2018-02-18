using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Vendor.API.ViewModels;
using Vendor.Models.VendorModel;

namespace Vendor.API.Commands
{
    public class CreateVendorCommand : IRequest<bool>
    {

        [DataMember]
        public VendorMaster VendorMaster { get; set; }

        public CreateVendorCommand(VendorMaster vendorMaster)
        {
            VendorMaster = vendorMaster;
        }

    }
}

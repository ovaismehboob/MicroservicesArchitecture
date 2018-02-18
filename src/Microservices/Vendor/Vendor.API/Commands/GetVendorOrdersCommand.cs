using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Vendor.API.AggregateModels;

namespace Vendor.API.Commands
{
    public class GetVendorOrdersCommand : IRequest<VendorOrders>
    {

        [DataMember]
        public int VendorID { get; set; }

        public GetVendorOrdersCommand(int vendorID)
        {
            VendorID = vendorID;
        }
    }
}

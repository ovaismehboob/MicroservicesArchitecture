using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendor.Models.VendorModel;

namespace Vendor.API.AggregateModels
{
    public class VendorOrders
    {

        public VendorOrders()
        {
            Orders = new List<Order>();
        }
        public VendorMaster Vendor { get; set; }
        public List<Order> Orders { get; set; }

    }
}

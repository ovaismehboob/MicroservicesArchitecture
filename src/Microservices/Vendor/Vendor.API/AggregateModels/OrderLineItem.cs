using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendor.API.AggregateModels
{
    public class OrderLineItem
    {
        public string OrderID { get; set; }

        public string ItemNumber { get; set; }

        public int Quantity { get; set; }
        public string Unit { get; set; }
    }
}

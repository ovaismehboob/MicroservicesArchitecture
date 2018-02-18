using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendor.API.AggregateModels
{
    public class Order
    {

        public Order()
        {
            OrderItems = new List<OrderLineItem>();
        }
        public string OrderNumber { get; set; }
        public int VendorID { get; set; }

        public DateTime OrderDate { get; set; }

        public string Currency { get; set; }

        public List<OrderLineItem> OrderItems { get; set; }
    }
}

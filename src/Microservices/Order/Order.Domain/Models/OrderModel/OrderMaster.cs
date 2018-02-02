using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Order.Domain.Models.OrderModel
{
    public class OrderMaster : BaseEntity
    {

        [Key]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int VendorID { get; set; }

        public DateTime OrderDate { get; set; }

        public string Currency { get; set; }
    }
}

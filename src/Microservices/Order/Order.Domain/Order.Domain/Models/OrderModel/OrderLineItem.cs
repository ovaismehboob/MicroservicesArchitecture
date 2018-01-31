using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Order.Domain.Models.OrderModel
{
    public class OrderLineItem : BaseEntity
    {

        [Key]
        public int Id { get; set; }

        public string OrderID { get; set; }

        public string ItemNumber { get; set; }

        public int Quantity { get; set; }
        public string Unit { get; set; }

        public decimal TotalPrice { get; set; }

        public int OrderMasterID { get; set; }

        [ForeignKey("OrderMasterID")]
        public OrderMaster Order { get; set; }
    }

}

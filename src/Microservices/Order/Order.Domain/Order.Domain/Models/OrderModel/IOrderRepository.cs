using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Models.OrderModel
{
    public interface IOrderRepository : IRepository<OrderMaster>
    {
        OrderMaster Add(OrderMaster orderMaster);

        void Update(OrderMaster orderMaster);

        Task<OrderMaster> GetAsync(int vendorID);

        void Delete(int orderLineItemID);

    }
}


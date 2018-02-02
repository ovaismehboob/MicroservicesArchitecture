using Infrastructure.Data;
using Order.Domain.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public OrderMaster Add(OrderMaster orderMaster) => throw new NotImplementedException();
        public void Delete(int orderLineItemID) => throw new NotImplementedException();
        public Task<OrderMaster> GetAsync(int vendorID) => throw new NotImplementedException();
        public void Update(OrderMaster orderMaster) => throw new NotImplementedException();
    }
}

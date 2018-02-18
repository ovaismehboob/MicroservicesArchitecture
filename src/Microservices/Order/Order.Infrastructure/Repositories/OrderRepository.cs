using Infrastructure.Data;
using Order.Domain.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        OrderDBContext _context;
        public OrderRepository(OrderDBContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public OrderMaster Add(OrderMaster orderMaster)
        {
            return _context.OrderMaster.Add(orderMaster).Entity;
        }

        public IQueryable<T> All<T>() where T : BaseEntity => throw new NotImplementedException();
        public bool Contains<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity => throw new NotImplementedException();

        public void Delete(int orderLineItemID)
        { 
            
        }

        public T Find<T>(Expression<Func<T, bool>> predicate) where T : BaseEntity => throw new NotImplementedException();
        public Task<OrderMaster> GetAsync(int vendorID) => throw new NotImplementedException();
        public void Update(OrderMaster orderMaster) => throw new NotImplementedException();
    }
}

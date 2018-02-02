using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order.Infrastructure
{
    public class OrderDBContext : FraymsDBContext
    {

        public OrderDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //  optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=FraymsVendorDB;Integrated Security=False; User Id=sa; Password=P@ssw0rd; Timeout=500000;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        #region Entities representing Vendor Domain Objects
        public DbSet<OrderMaster> OrderMaster { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; protected set; }
        #endregion
    }

}

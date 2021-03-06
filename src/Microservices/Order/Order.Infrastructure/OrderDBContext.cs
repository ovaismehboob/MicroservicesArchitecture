﻿using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Order.Domain.Models.OrderModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure
{
    public class OrderDBContext : DbContext, IUnitOfWork
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

        public void BeginTransaction()
        {
            this.Database.BeginTransaction();
        }
        public void RollbackTransaction()
        {
            this.Database.RollbackTransaction();
        }
        public void CommitTransaction()
        {
            this.Database.CommitTransaction();
        }
        public Task<bool> SaveChangesAsync()
        {
            return this.SaveChangesAsync();
        }

        #region Entities representing Vendor Domain Objects
        public DbSet<OrderMaster> OrderMaster { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; protected set; }
        #endregion
    }

}

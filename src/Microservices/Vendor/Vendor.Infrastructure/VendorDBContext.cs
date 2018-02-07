using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Vendor.Models.VendorModel;

namespace Vendor.Infrastructure
{
    public class VendorDBContext : DbContext, IUnitOfWork
    {


        public VendorDBContext(DbContextOptions options) : base(options)
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
        public DbSet<VendorMaster> VendorMaster { get; set; }
        public DbSet<VendorDocument> VendorDocuments { get; protected set; }
        #endregion
    }
}

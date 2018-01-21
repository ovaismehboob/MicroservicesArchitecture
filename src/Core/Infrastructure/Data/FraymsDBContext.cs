using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class FraymsDBContext : DbContext, IUnitOfWork
    {

        public FraymsDBContext(DbContextOptions options): base(options)
        {

        }
        public void BeginTransaction()
        {
            base.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            base.Database.CommitTransaction();
        }
        public void RollbackTransaction()
        {
            base.Database.RollbackTransaction();
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
               var result = await base.SaveChangesAsync();
               return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }


    }
}

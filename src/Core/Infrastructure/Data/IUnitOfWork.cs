using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IUnitOfWork: IDisposable
    {
        void BeginTransaction();

        void RollbackTransaction();

        void CommitTransaction();

        Task<bool> SaveChangesAsync();
        
    }
}

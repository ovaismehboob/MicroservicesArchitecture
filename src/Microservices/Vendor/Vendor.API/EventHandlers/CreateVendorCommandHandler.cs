using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vendor.API.Commands;
using Vendor.Domain.Models.VendorModel;
using Vendor.Models.VendorModel;

namespace Vendor.API.EventHandlers
{
    public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, bool>
    {
        private readonly IVendorRepository _vendorRepository;

        public CreateVendorCommandHandler(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public async Task<bool> Handle(CreateVendorCommand command, CancellationToken cancellationToken)
        {

            _vendorRepository.UnitOfWork.BeginTransaction();
            try
            {
                _vendorRepository.Add(command.VendorMaster);
                _vendorRepository.UnitOfWork.CommitTransaction();
            }catch(Exception ex)
            {
                _vendorRepository.UnitOfWork.RollbackTransaction();
            }
            return await _vendorRepository.UnitOfWork.SaveChangesAsync();
        }
    }

}

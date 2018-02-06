using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vendor.API.Notifications;

namespace Vendor.API.NotificationHandlers
{
    public class QueryDBHandler : INotificationHandler<CreateVendorNotification>
    {
        public Task Handle(CreateVendorNotification notification, CancellationToken cancellationToken)
        {
            //Save Vendor into query DB 
            var vendor = notification._vendorVM;
            return Task.FromResult(0);
        }

      
    }
}

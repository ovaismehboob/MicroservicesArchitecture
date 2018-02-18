using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vendor.API.Notifications;
using Vendor.Models.VendorModel;

namespace Vendor.API.NotificationHandlers
{
    public class SendEmailHandler : INotificationHandler<CreateVendorNotification>
    {

        MessagingService _service;
        
        public SendEmailHandler(MessagingService service) : base()
        {
            _service = service;
        }

        public Task Handle(CreateVendorNotification notification, CancellationToken cancellationToken)
        {
            _service.SendEmail(notification._vendorVM.Email, "Registration", "Thankyou for registration");
            return Task.FromResult(0);
        }
    }
}

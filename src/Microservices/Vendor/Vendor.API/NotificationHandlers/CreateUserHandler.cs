using APIComponents.Http;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vendor.API.Notifications;
using Vendor.Models.VendorModel;

namespace Vendor.API.NotificationHandlers
{
    public class CreateUserHandler : INotificationHandler<CreateVendorNotification>
    {
        IResilientHttpClient _client; 
        public CreateUserHandler(IResilientHttpClient client)
        {
            _client = client;
        }
        public Task Handle(CreateVendorNotification notification, CancellationToken cancellationToken)
        {
            string uri = "http://businessfrayms.com/api/Identity";
            string token = "";//read token from user session
            var response = _client.Post<VendorMaster>(uri, notification._vendorVM,"");
            return Task.FromResult(0);
        }
    }
}

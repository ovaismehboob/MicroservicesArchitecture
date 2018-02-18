using APIComponents.Http;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vendor.API.AggregateModels;
using Vendor.API.Commands;

namespace Vendor.API.EventHandlers
{
    public class GetVendorOrderCommandHandler : IRequestHandler<GetVendorOrdersCommand, VendorOrders>
    {

        IResilientHttpClient _client;


        public GetVendorOrderCommandHandler(IResilientHttpClient client)
        {
            _client = client;
        }

        public Task<VendorOrders> Handle(GetVendorOrdersCommand request, CancellationToken cancellationToken)
        {
            //Call http client that have circuit breaker and retry implemented
            string uri = "http://businessfrayms.com/api/Order?vendorId=" + request.VendorID;
            var response=  _client.Get(uri);
            return null;
        }
        
    }
}

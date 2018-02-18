using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APIComponents.Controllers;
using AspNet.Security.OAuth.Introspection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vendor.API.AggregateModels;
using Vendor.API.Commands;
using Vendor.API.Notifications;
using Vendor.API.ViewModels;
using Vendor.Models.VendorModel;

namespace Vendor.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Vendor")]
    public class VendorController : BaseController
    {
        private readonly IMediator _mediator;
        private ILogger _logger;

        public VendorController(IMediator mediator, ILogger<VendorController> logger) : base(logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [Authorize(AuthenticationSchemes = OAuthIntrospectionDefaults.AuthenticationScheme)]
        // POST: api/VendorMaster
        [HttpPost]
        public void Post([FromBody]VendorMaster value)
        {
            try
            {

                bool result = _mediator.Send(new CreateVendorCommand(value)).Result;
                if (result)
                {
                    //Record saved succesfully, publishing event now
                    _mediator.Publish(new CreateVendorNotification(value));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }


        public IActionResult Get(int vendorID)
        {
            try
            {
                VendorOrders vendorOrders = _mediator.Send(new GetVendorOrdersCommand(vendorID)).Result;
                return Ok(vendorOrders);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }

        }


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }

}

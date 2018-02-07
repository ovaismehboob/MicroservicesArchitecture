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
using Vendor.API.Commands;
using Vendor.API.Notifications;
using Vendor.API.ViewModels;

namespace Vendor.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Vendor")]
    public class VendorController : BaseController
    {
        private readonly IMediator _mediator;
        private ILogger _logger;

        public VendorController(IMediator mediator, ILogger logger): base(logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET: api/VendorMaster
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/VendorMaster/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [Authorize(AuthenticationSchemes = OAuthIntrospectionDefaults.AuthenticationScheme)]
        // POST: api/VendorMaster
        [HttpPost]
        public void Post([FromBody]VendorViewModel value)
        {
            try
            {
                bool result = _mediator.Send(new CreateVendorCommand(value)).Result;
                if (result)
                {
                    //Record saved succesfully, publishing event now
                    _mediator.Publish(new CreateVendorNotification(value));
                }
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
           
            

        }

        // PUT: api/VendorMaster/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

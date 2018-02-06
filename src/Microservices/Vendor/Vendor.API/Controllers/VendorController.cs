using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AspNet.Security.OAuth.Introspection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vendor.API.Commands;
using Vendor.API.Notifications;
using Vendor.API.ViewModels;

namespace Vendor.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Vendor")]
    public class VendorController : Controller
    {
        private readonly IMediator _mediator;

        public VendorController(IMediator mediator)
        {
            _mediator = mediator;
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
            bool result=_mediator.Send(new CreateVendorCommand(value)).Result;
            if (result)
            {
                //Record saved succesfully, publishing event now
                _mediator.Publish(new CreateVendorNotification(value));
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

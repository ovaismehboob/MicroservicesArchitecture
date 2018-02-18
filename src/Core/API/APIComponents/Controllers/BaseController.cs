using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace APIComponents.Controllers
{
    public class BaseController : Controller
    {
        IRepository<BaseEntity> _repository;
        private ILogger _logger;
        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;

        }

        public ILogger Logger { get { return _logger; } }
        public HttpResponseMessage LogException(Exception ex)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            message.Content = new StringContent(ex.Message);
            message.StatusCode = System.Net.HttpStatusCode.ExpectationFailed;
            return message;
        }


    }
}

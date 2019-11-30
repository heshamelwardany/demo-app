using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.WebSpa.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Demo.WebSpa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public ConfigurationController(IOptionsSnapshot<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_appSettings);
        }
    }
}

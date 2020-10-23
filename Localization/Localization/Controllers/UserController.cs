using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Localization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Localization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IStringLocalizer<UserController> _localizer;


        public UserController(IStringLocalizer<UserController> localizer)
        {
            _localizer = localizer;
        }

        // GET: api/<UserController>
        [HttpGet]
        public string Get()
        {
            return _localizer["Test"];
        }

        [HttpPost]
        public string Post(TestRequest model)
        {
            return _localizer["Test"];
        }
    }
}

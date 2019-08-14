using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public Dictionary<string, string> msgs = new Dictionary<string, string>
        {
            {"hi", "hello" },
            {"hello", "hi" }
        };
        [HttpGet("{msg}")]
        public ActionResult<string> Get(string msg)
        {
            return msgs.ContainsKey(msg) ? msgs[msg] : "invalid";
        }

    }
}
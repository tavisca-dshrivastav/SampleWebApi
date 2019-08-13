using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Dictionary<string, string> users = new Dictionary<string, string>
        {
            {"1", "deepak" },
            {"2", "sandesh" },
            {"3", "ankit" },
            {"4", "gjh" },
            {"5", "deesidlucliepak" },
            {"6", "dexdsxszsdcepak" },
            {"7", "dedxdxepak" }
        };
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string[] temp =  new string[users.Count];
            int t = 0;
            foreach (var i in users)
                temp[t++] = i.Value;
            return temp;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return users[id.ToString()];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Console.WriteLine(value);
            users.Add((users.Count + 1).ToString(), value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            users[id.ToString()] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            users.Remove(id.ToString());
        }
    }
}

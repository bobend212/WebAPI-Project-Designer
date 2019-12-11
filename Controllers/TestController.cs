using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectsDbAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "val1", "val2", "val3", "val4" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "ID: " + id;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
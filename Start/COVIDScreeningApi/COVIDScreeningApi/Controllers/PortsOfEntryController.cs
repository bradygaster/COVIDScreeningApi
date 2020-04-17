using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COVIDScreeningApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PortsOfEntryController : ControllerBase
    {
        // GET: api/<PortsOfEntryController>
        [HttpGet]
        public IEnumerable<PortsOfEntry> Get()
        {
            return new List<PortsOfEntry>();
        }

        // GET api/<PortsOfEntryController>/5
        [HttpGet("{id}")]
        public PortsOfEntry Get(int id)
        {
            return null;
        }

        // POST api/<PortsOfEntryController>
        [HttpPost]
        public void Post([FromBody] PortsOfEntry value)
        {
        }

        // PUT api/<PortsOfEntryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PortsOfEntry value)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COVIDScreeningApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentativeDataController : ControllerBase
    {
        // GET: api/<RepresentativeDataController>
        [HttpGet]
        public IEnumerable<RepresentativeData> Get()
        {
            return new List<RepresentativeData>();
        }

        // GET api/<RepresentativeDataController>/5
        [HttpGet("{id}")]
        public RepresentativeData Get(int id)
        {
            return null;
        }

        // POST api/<RepresentativeDataController>
        [HttpPost]
        public void Post([FromBody] RepresentativeData value)
        {
        }

        // PUT api/<RepresentativeDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RepresentativeData value)
        {
        }
    }
}

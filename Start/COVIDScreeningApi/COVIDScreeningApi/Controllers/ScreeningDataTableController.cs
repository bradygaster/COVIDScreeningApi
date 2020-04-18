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
    public class ScreeningDataTableController : ControllerBase
    {
        // GET: api/<ScreeningDataTableController>
        [HttpGet]
        public IEnumerable<ScreeningDataTable> Get()
        {
            return new List<ScreeningDataTable>();
        }

        // GET api/<ScreeningDataTableController>/5
        [HttpGet("{id}")]
        public ScreeningDataTable Get(int id)
        {
            return new ScreeningDataTable();
        }

        // POST api/<ScreeningDataTableController>
        [HttpPost]
        public void Post([FromBody] ScreeningDataTable value)
        {
        }

        // PUT api/<ScreeningDataTableController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ScreeningDataTable value)
        {
        }
    }
}

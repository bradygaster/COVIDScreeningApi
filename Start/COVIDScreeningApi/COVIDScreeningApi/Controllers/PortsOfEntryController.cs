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
            return new List<PortsOfEntry>(new PortsOfEntry[]
            {
                new PortsOfEntry { ItemsLabels = "Peace Arch Border", ItemsLatitudes = 49.001453, ItemsLongitudes = -122.736694},
                new PortsOfEntry { ItemsLabels = "Jefferson County International Airport", ItemsLatitudes = 48.108032, ItemsLongitudes = -122.774895},
                new PortsOfEntry { ItemsLabels = "Fairfield International Airport", ItemsLatitudes = 48.116325, ItemsLongitudes = -123.493484},
                new PortsOfEntry { ItemsLabels = "Grant County International Airport", ItemsLatitudes = 47.189873, ItemsLongitudes = -119.323608},
                new PortsOfEntry { ItemsLabels = "Spokane International Airport", ItemsLatitudes = 47.625526, ItemsLongitudes = -117.536163},
                new PortsOfEntry { ItemsLabels = "Seattle Airport", ItemsLatitudes = 47.443760, ItemsLongitudes = -122.302202},
            });
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

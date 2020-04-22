using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Data;
using COVIDScreeningApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COVIDScreeningApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PortsOfEntryController : ControllerBase
    {
        private readonly DataContext dataContext;
        private readonly IConfiguration configuration;
        public PortsOfEntryController (DataContext dataContext, IConfiguration configuration) {
            this.configuration = configuration;
            this.dataContext = dataContext;
        }

        // GET: api/<PortsOfEntryController>
        [HttpGet]
        public IEnumerable<PortsOfEntry> Get()
        {
            return this.dataContext.Ports
                .OrderBy(x => x.Label)
                .Select(x => PortsOfEntry.FromDataModel(x));
        }

        // GET api/<PortsOfEntryController>/5
        [HttpGet("{id}")]
        public PortsOfEntry Get(Guid id)
        {
            return this.dataContext.Ports.First(x => x.Id == id).ToApiModel();
        }

        // POST api/<PortsOfEntryController>
        [HttpPost]
        public ActionResult Post([FromBody] PortsOfEntry value)
        {
            var dataObject = PortOfEntry.FromApiModel(value);
            this.dataContext.Ports.Add (dataObject);
            this.dataContext.SaveChanges();
            var result = PortsOfEntry.FromDataModel(
                this.dataContext.Ports.First (x => x.Id == dataObject.Id)
            );
            var resultUrl = string.Concat(configuration["SwaggerBaseUrl"], $"/PortsOfEntry/{dataObject.Id}");
            return Created(resultUrl, result);
        }

        // PUT api/<PortsOfEntryController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] PortsOfEntry value)
        {
            var entity = this.dataContext.Ports.First (x => x.Id == id);
            PortOfEntry.CopyPropertyValues(value, entity);
            this.dataContext.Update(entity);
            this.dataContext.SaveChanges();
        }
    }
}

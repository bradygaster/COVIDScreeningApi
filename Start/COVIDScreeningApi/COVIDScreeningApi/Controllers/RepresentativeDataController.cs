using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using COVIDScreeningApi.Data;
using COVIDScreeningApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COVIDScreeningApi.Controllers {
    [Route ("[controller]")]
    [ApiController]
    public class RepresentativeDataController : ControllerBase {
        private readonly DataContext dataContext;
        private readonly IConfiguration configuration;
        public RepresentativeDataController (DataContext dataContext, IConfiguration configuration) {
            this.configuration = configuration;
            this.dataContext = dataContext;
        }

        // GET: api/<RepresentativeDataController>
        [HttpGet]
        public IEnumerable<RepresentativeData> Get () {
            return this.dataContext.Representatives
                .OrderBy(x => x.RepName)
                .Select(x => RepresentativeData.FromDataModel(x));
        }

        // GET api/<RepresentativeDataController>/5
        [HttpGet ("{id}")]
        public RepresentativeData Get (Guid id) {
            return this.dataContext.Representatives.First(x => x.Id == id).ToApiModel();
        }

        // POST api/<RepresentativeDataController>
        [HttpPost]
        public ActionResult Post ([FromBody] RepresentativeData value) {
            var dataObject = Representative.FromApiModel(value);
            Guid newId = Guid.NewGuid();
            dataObject.Id = newId;
            this.dataContext.Representatives.Add (dataObject);
            this.dataContext.SaveChanges ();
            var result = RepresentativeData.FromDataModel(
                this.dataContext.Representatives.First (x => x.Id == newId)
            );
            var resultUrl = string.Concat(configuration["SwaggerBaseUrl"], $"/RepresentativeData/{newId}");
            return Created(resultUrl, result);
        }

        // PUT api/<RepresentativeDataController>/5
        [HttpPut ("{id}")]
        public void Put (Guid id, [FromBody] RepresentativeData value) {
            var entity = this.dataContext.Representatives.First (x => x.Id == id);
            entity.RepContact = value.RepContact;
            entity.RepEmail = value.RepEmail;
            entity.RepLocation = value.RepLocation;
            entity.RepName = value.RepName;
            this.dataContext.Update(entity);
            this.dataContext.SaveChanges();
        }
    }
}
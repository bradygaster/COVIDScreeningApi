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
    public class ScreeningDataTableController : ControllerBase {
        private readonly IConfiguration configuration;
        private readonly DataContext dataContext;
        public ScreeningDataTableController (DataContext dataContext, IConfiguration configuration) {
            dataContext.Database.EnsureCreated();
            this.dataContext = dataContext;
            this.configuration = configuration;
        }

        // GET: api/<ScreeningDataTableController>
        [HttpGet(Name=nameof(GetScreenings))]
        public IEnumerable<ScreeningDataTable> GetScreenings () {
            return this.dataContext.Screenings
                .OrderBy(x => x.VisitorName)
                .Select(x => ScreeningDataTable.FromDataModel(x));
        }

        // GET api/<ScreeningDataTableController>/5
        [HttpGet ("{id}", Name=nameof(GetScreening))]
        public ScreeningDataTable GetScreening (Guid id) {
            return this.dataContext.Screenings.First(x => x.Id == id).ToApiModel();
        }

        // POST api/<ScreeningDataTableController>
        [HttpPost(Name=nameof(CreateScreening))]
        public ActionResult<ScreeningDataTable> CreateScreening ([FromBody] ScreeningDataTable value) { 
            var dataObject = Screening.FromApiModel(value);
            Guid newId = Guid.NewGuid();
            dataObject.Id = newId;
            this.dataContext.Screenings.Add (dataObject);
            this.dataContext.SaveChanges ();
            var result = ScreeningDataTable.FromDataModel(
                this.dataContext.Screenings.First (x => x.Id == newId)
            );
            var resultUrl = string.Concat(configuration["SwaggerBaseUrl"], $"/ScreeningDataTable/{newId}");
            return Created(resultUrl, result);
        }

        // PUT api/<ScreeningDataTableController>/5
        [HttpPut ("{id}", Name=nameof(PutScreening))]
        public void PutScreening (Guid id, [FromBody] ScreeningDataTable value) { 
            var entity = this.dataContext.Screenings.First (x => x.Id == id);
            Screening.CopyPropertyValues(value, entity);
            this.dataContext.Update(entity);
            this.dataContext.SaveChanges();
        }
    }
}
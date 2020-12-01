using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeriesApi.Models;
using SeriesApi.Services;

namespace SeriesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private ISeriesServices seriesServices;
        public SeriesController(ISeriesServices seriesServices)
        {
            this.seriesServices = seriesServices;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Serie>> getSeries()
        {
            try
            {
                return Ok(seriesServices.getSeries());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Serie> getSerie(int id)
        {
            try
            {
                return Ok(seriesServices.getSerie(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "something bad happened");
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Serie newSerie)
        {
            seriesServices.addSerie(newSerie);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Serie serieToUp)
        {
            seriesServices.updateSerie(id, serieToUp);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            seriesServices.deleteSerie(id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleVersioning.Models;

namespace ModuleVersioning.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version: apiVersion}movies")]
    [ApiController]
    public class MovieV2Controller : ControllerBase
    {
        static List<MoviesV2> _movies = new List<MoviesV2>()
        {
            new MoviesV2(){Id=0, MovieName="Lalaland", MovieDescription="Music", Type= "Music"},
            new MoviesV2(){Id=1, MovieName="Jumanji", MovieDescription="Adventure", Type= "Adventure"}
        };

        // GET: api/MovieV2
        [HttpGet]
        public IEnumerable<MoviesV2> Get()
        {
            return _movies;
        }

        // GET: api/MovieV2/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/MovieV2
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/MovieV2/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

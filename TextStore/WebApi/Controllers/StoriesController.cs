using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextStore.WebApi.Data;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/stories")]
    public class StoriesController : Controller
    {
        private IRepository _repository;

        public StoriesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Story
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Story/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Story
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Story/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

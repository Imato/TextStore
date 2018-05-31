using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TextStore.Model;
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

        [HttpGet]
        public IEnumerable<Story> Get()
        {
            return _repository.GetStories();
        }

        [HttpGet("{id}")]
        public Story Get(int id)
        {
            return _repository.GetById<Story>(id);
        }
        
        [HttpPost]
        public void Post([FromBody]Story value)
        {
            _repository.Save(value);
        }
        

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Story value)
        {
            if (_repository.GetById<Story>(id) != null)
                _repository.Save(value);
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete<Story>(id);
        }
    }
}

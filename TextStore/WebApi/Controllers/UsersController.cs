using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextStore.Model;
using TextStore.WebApi.Data;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private IRepository _repository;

        public UsersController(IRepository repository)
        {
            _repository = repository;
        }

   
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {

            var users = new List<Person>
            {

                new Person(1,"Antti",23)

            };


                return new JsonResult(users);
        }
       

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
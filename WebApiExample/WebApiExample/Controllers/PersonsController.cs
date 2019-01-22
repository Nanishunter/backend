using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Models;
using WebApiExample.Repositories;
using WebApiExample.Services;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Person>> GetPersons()
        {
            var persons = _personService.Read();
                return new JsonResult(persons);
               
        }
       
        // GET api/persons/5
        [HttpGet("{id}")]

        public ActionResult<Person> Get(int id)

        {  ;
            var person = _personService.Read(id);
            return new JsonResult(person);
        }

        // POST api/persons ADD PERSON
        [HttpPost]

        public ActionResult<Person> Post(Person person)
        {
            _personService.Create(person);
            return new JsonResult(person);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return new OkResult();
        }

        // PUT api/persons/{id}

        [HttpPut("{id}")]
        public IActionResult Update(int id, Person person)
        {
            Person updatedContact = _personService.Update(id, person);
            return new JsonResult(updatedContact);

        }

    }




}
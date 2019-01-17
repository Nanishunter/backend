using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Models;
using WebApiExample.Repositories;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Person>> GetPersons()
        {
            var persons = _personRepository.Read();
                return new JsonResult(persons);
               
        }
       
        // GET api/persons/5
        [HttpGet("{id}")]

        public ActionResult<Person> Get(int id)

        {  ;
            var person = _personRepository.Read(id);
            return new JsonResult(person);
        }

        // POST api/persons ADD PERSON
        [HttpPost]

        public ActionResult<Person> Post(Person person)
        {
            var newPerson = _personRepository.Create(person);
            return new JsonResult(newPerson);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personRepository.Delete(id);
            return new OkResult();
        }

        // PUT api/persons/{id}

        [HttpPut("{id}")]
        public IActionResult Update(int id, Person person)
        {
            Person updatedContact = _personRepository.Update(id, person);
            return new JsonResult(updatedContact);

        }

    }




}
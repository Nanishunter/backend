using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;
using WebApiExample.Repositories;

namespace WebApiExample.Services
{
    public class PersonService:IPersonService

    {
        private readonly IPersonRepository _personRepository;
       
        //Alustetaan konstruktori
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        // Haetaan kaikki personit
        public List<Person> Read()
        {
            return _personRepository.Read();
        }


        //Haetaan id:n perusteella
        public Person Read(int id)
        {
            return _personRepository.Read(id);
        }

        //Luodaan usi
        public Person Create(Person person)
        {
            return _personRepository.Create(person);
        }

        //päivitetään
        public Person Update(int id, Person person)
        {
            //_context.Update(person);
            //_context.SaveChanges();
            //return person;
            var savedPerson = Read(id);
            if (savedPerson == null)
                throw new Exception("Person not found");
            else
            {
                _personRepository.Update(id, person);
                return person;
            }
        }


        //poistetaan
        public void Delete(int id)
        {
             _personRepository.Delete(id);
        }
    }
}

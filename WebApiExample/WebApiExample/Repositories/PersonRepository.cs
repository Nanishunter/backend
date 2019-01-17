using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApiExample.Models;
namespace WebApiExample.Repositories
{
    public class PersonRepository: IPersonRepository
    {

        private readonly BackenddbContext _context;

        public PersonRepository(BackenddbContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public List<Person> Read()
        {
            //// select * from person
            return _context.Person.AsNoTracking().Include(p=>p.Phone).ToList();
            

            // return _context.Person.FromSql("Select Person.Name FROM PERSON").AsNoTracking().ToList();
        }

        public Person Read(int id)
        {
            return _context.Person.AsNoTracking()
                .Include("Phone")
                .FirstOrDefault(p => p.Id == id);
        }

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
                _context.Update(person);
                _context.SaveChanges();
                return person;
            }
        }

        public void Delete(int id)
        {
            var person = Read (id);
            _context.Person.Remove(person);
            _context.SaveChanges();
            return;
        }
    }
}

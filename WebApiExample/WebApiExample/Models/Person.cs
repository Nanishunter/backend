using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiExample.Models
{
    public partial class Person
    {
        public Person()
        {

            Phone = new HashSet<Phone>();
        }

        public Person(long id, string name, short? age)
        {
            Id = id;
            Name = name;
            Age = age;
         
        }

        public long Id { get; set; }
        [StringLength(10)] public string Name { get; set; }
        public short? Age { get; set; }

        [InverseProperty("Person")] public ICollection<Phone> Phone { get; set; }
    }

    class PersonImpl : Person
    {
    }
}


using curso_restful.Models;
using curso_restful.ViewModels.Converter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso_restful.ViewModels.Converter
{
    public class PersonConverter : IParser<PersonVM, Person>, IParser<Person, PersonVM>
    {
        public Person Parse(PersonVM origin)
        {
            if (origin == null) return new Person();
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public PersonVM Parse(Person origin)
        {
            if (origin == null) return new PersonVM();
            return new PersonVM
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> ParseList(List<PersonVM> origin)
        {
            if (origin == null) return new List<Person>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<PersonVM> ParseList(List<Person> origin)
        {
            if (origin == null) return new List<PersonVM>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

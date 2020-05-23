using curso_restful.Contexts;
using curso_restful.Interfaces;
using curso_restful.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace curso_restful.Services.Implementations
{
    public class PersonService
    {
        private IPersonRepository repo;

        public PersonService(IPersonRepository repo)
        {
            this.repo = repo;
        }

        public Person Create(Person person)
        {
            return repo.Create(person);
        }

        public void Delete(long id)
        {
            repo.Delete(id);
        }

        public List<Person> FindAll()
        {
            return repo.FindAll();
        }        

        public Person FindById(long id)
        {
            return repo.FindById(id);
        }

        public Person Update(Person person)
        {
            return repo.Update(person);
        }        
    }
}

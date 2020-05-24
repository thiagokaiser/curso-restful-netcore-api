using curso_restful.Contexts;
using curso_restful.Interfaces;
using curso_restful.Models;
using curso_restful.ViewModels;
using curso_restful.ViewModels.Converter;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace curso_restful.Services
{
    public class PersonService
    {
        private IPersonRepository repo;
        private PersonConverter converter;

        public PersonService(IPersonRepository repo)
        {
            this.repo = repo;
            this.converter = new PersonConverter();
        }

        public PersonVM Create(PersonVM person)
        {
            var model = converter.Parse(person);
            var vm = converter.Parse(repo.Create(model));
            return vm;
        }

        public void Delete(long id)
        {
            repo.Delete(id);
        }

        public List<PersonVM> FindAll()
        {
            return converter.ParseList(repo.FindAll());
        }        

        public PersonVM FindById(long id)
        {
            return converter.Parse(repo.FindById(id));
        }

        public PersonVM Update(PersonVM person)
        {
            var model = converter.Parse(person);
            var vm = converter.Parse(repo.Update(model));
            return vm;
        }        
    }
}

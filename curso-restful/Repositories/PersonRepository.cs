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
    public class PersonRepository : IPersonRepository
    {
        private MyDbContext context;        

        public PersonRepository(MyDbContext context)
        {
            this.context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                context.Add(person);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {            
            var result = context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                context.Persons.Remove(result);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public List<Person> FindAll()
        {
            return context.Persons.ToList();
        }        

        public Person FindById(long id)
        {
            return context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();

            var result = context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));            
            try
            {
                context.Entry(result).CurrentValues.SetValues(person);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        private bool Exist(long id)
        {
            return context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}

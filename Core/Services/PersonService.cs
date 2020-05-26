using Core.Interfaces;
using Core.ViewModels;
using Core.ViewModels.Converter;
using System.Collections.Generic;

namespace Core.Services
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

using Core.Interfaces;
using Core.ViewModels;
using Core.ViewModels.Converter;
using System.Collections.Generic;

namespace Core.Services
{
    public class BookService
    {
        private IBookRepository repo;
        private BookConverter converter;

        public BookService(IBookRepository repo)
        {
            this.repo = repo;
            this.converter = new BookConverter();
        }

        public BookVM Create(BookVM book)
        {
            var model = converter.Parse(book);
            var vm = converter.Parse(repo.Create(model));
            return vm;
        }

        public void Delete(long id)
        {
            repo.Delete(id);
        }

        public List<BookVM> FindAll()
        {
            return converter.ParseList(repo.FindAll());
        }        

        public BookVM FindById(long id)
        {
            return converter.Parse(repo.FindById(id));
        }

        public BookVM Update(BookVM book)
        {
            var model = converter.Parse(book);
            var vm = converter.Parse(repo.Update(model));
            return vm;
        }

        public BookVM GetBookByPrice(decimal valor)
        {
            return converter.Parse(repo.GetBookByPrice(valor));
        }
    }
}

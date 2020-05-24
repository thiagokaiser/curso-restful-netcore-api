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

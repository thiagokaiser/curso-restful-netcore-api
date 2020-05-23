using curso_restful.Contexts;
using curso_restful.Interfaces;
using curso_restful.Models;
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

        public BookService(IBookRepository repo)
        {
            this.repo = repo;
        }

        public Book Create(Book book)
        {
            return repo.Create(book);
        }

        public void Delete(long id)
        {
            repo.Delete(id);
        }

        public List<Book> FindAll()
        {
            return repo.FindAll();
        }        

        public Book FindById(long id)
        {
            return repo.FindById(id);
        }

        public Book Update(Book book)
        {
            return repo.Update(book);
        }

        public Book GetBookByPrice(decimal valor)
        {
            return repo.GetBookByPrice(valor);
        }
    }
}

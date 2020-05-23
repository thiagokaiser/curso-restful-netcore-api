using curso_restful.Contexts;
using curso_restful.Interfaces;
using curso_restful.Models;
using curso_restful.Repositories.Generic;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

namespace curso_restful.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly MyDbContext context;
        public BookRepository(MyDbContext context) : base(context)
        {
            this.context = context;
        }

        public Book GetBookByPrice(decimal item)
        {
            return context.Books.FirstOrDefault(p => p.Price == item);
        }
    }
}

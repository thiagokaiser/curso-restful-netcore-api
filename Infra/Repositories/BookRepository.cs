using Core.Interfaces;
using Core.Models;
using Infra.Contexts;
using Infra.Repositories.Generic;
using System.Linq;

namespace Infra.Repositories
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

using Core.Models;

namespace Core.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBookByPrice(decimal item);
    }
}

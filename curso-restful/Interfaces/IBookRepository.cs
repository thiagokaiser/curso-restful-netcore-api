using curso_restful.Models;
using curso_restful.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso_restful.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBookByPrice(decimal item);
    }
}

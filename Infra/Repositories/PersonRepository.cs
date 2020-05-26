using Core.Interfaces;
using Core.Models;
using Infra.Contexts;
using Infra.Repositories.Generic;

namespace Infra.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly MyDbContext context;
        public PersonRepository(MyDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}

using curso_restful.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso_restful.Contexts
{
    public class MyDbContext : DbContext
    {
        protected MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}

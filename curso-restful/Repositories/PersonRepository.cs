﻿using curso_restful.Contexts;
using curso_restful.Interfaces;
using curso_restful.Models;
using curso_restful.Repositories.Generic;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace curso_restful.Repositories
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

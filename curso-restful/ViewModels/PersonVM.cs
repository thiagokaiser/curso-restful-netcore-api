﻿using curso_restful.Models.Base;
using System.Collections.Generic;

namespace curso_restful.ViewModels
{
    public class PersonVM
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        //public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}

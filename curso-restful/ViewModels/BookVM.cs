using curso_restful.Models.Base;
using System;
using System.Collections.Generic;

namespace curso_restful.ViewModels
{
    public class BookVM
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
        //public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}

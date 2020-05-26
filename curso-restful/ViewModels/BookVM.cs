using curso_restful.Hypermedia;
using curso_restful.Models.Base;
using System;
using System.Collections.Generic;

namespace curso_restful.ViewModels
{
    public class BookVM : ListLinks
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
        
    }
}

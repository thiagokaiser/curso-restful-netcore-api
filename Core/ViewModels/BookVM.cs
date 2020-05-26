using Core.Hypermedia;
using System;

namespace Core.ViewModels
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

using Core.Models;
using Core.ViewModels.Converter.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core.ViewModels.Converter
{
    public class BookConverter : IParser<Book, BookVM>, IParser<BookVM, Book>
    {
        public BookVM Parse(Book origin)
        {
            if (origin == null) return new BookVM();
            return new BookVM
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public Book Parse(BookVM origin)
        {
            if (origin == null) return new Book();
            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public List<BookVM> ParseList(List<Book> origin)
        {
            if (origin == null) return new List<BookVM>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Book> ParseList(List<BookVM> origin)
        {
            if (origin == null) return new List<Book>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

using Core.Hypermedia;
using Core.Services;
using Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]    
    public class BookController : ControllerBase
    {
        private BookService service;

        public BookController(BookService service)
        {
            this.service = service;
        }

        [HttpGet(Name = nameof(GetBook))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult GetBook()
        {
            var books = service.FindAll();
            books.ForEach(c => AddLinks(c));
            return Ok(books);
        }

        [HttpGet("{id}", Name = nameof(GetBookById))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult GetBookById(int id)
        {
            var book = service.FindById(id);
            if (book == null) return NotFound();
            AddLinks(book);

            return Ok(book);
        }
                
        [HttpPost(Name = nameof(PostBook))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult PostBook([FromBody] BookVM book)
        {
            if (book == null) return BadRequest();
            var result = service.Create(book);
            AddLinks(result);

            return Ok(result);
        }
                
        [HttpPut(Name = nameof(PutBook))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult PutBook([FromBody] BookVM book)
        {
            if (book == null) return BadRequest();
            var result = service.Update(book);
            AddLinks(result);

            return Ok(result);
        }
                
        [HttpDelete("{id}", Name = nameof(DeleteBook))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult DeleteBook(int id)
        {
            service.Delete(id);
            return NoContent();
        }

        // GET: api/Person/5
        [HttpGet("price/{valor}", Name = nameof(GetBookByPrice))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult GetBookByPrice(decimal valor)
        {
            var book = service.GetBookByPrice(valor);
            if (book == null) return NotFound();
            AddLinks(book);

            return Ok(book);
        }

        private void AddLinks(BookVM book)
        {
            var path = "api/v1/book/" + book.Id;
            
            book.Links.Add(new HyperMediaLink("GET", path, "self", "application/json"));            
            book.Links.Add(new HyperMediaLink("PUT", path, "update", "application/json"));
            book.Links.Add(new HyperMediaLink("DELETE", path, "delete", "application/json"));
        }
    }
}

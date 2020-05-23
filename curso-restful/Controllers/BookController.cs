using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curso_restful.Interfaces;
using curso_restful.Models;
using curso_restful.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace curso_restful.Controllers
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

        // GET: api/Person
        [HttpGet]
        public IActionResult GetBook()
        {
            return Ok(service.FindAll());
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = service.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST: api/Person
        [HttpPost]
        public IActionResult PostBook([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(service.Create(book));
        }

        // PUT: api/Person/
        [HttpPut]
        public IActionResult PutBook([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(service.Update(book));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            service.Delete(id);
            return NoContent();
        }

        // GET: api/Person/5
        [HttpGet("price/{valor}")]
        public IActionResult GetBookByPrice(decimal valor)
        {
            var book = service.GetBookByPrice(valor);
            if (book == null) return NotFound();
            return Ok(book);
        }
    }
}

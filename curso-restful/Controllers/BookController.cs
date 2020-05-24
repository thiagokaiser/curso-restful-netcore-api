using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curso_restful.Interfaces;
using curso_restful.Models;
using curso_restful.Services;
using curso_restful.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;

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
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetBook()
        {
            return Ok(service.FindAll());
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetBook(int id)
        {
            var book = service.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST: api/Person
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult PostBook([FromBody] BookVM book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(service.Create(book));
        }

        // PUT: api/Person/
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult PutBook([FromBody] BookVM book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(service.Update(book));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult DeleteBook(int id)
        {
            service.Delete(id);
            return NoContent();
        }

        // GET: api/Person/5
        [HttpGet("price/{valor}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult GetBookByPrice(decimal valor)
        {
            var book = service.GetBookByPrice(valor);
            if (book == null) return NotFound();
            return Ok(book);
        }
    }
}

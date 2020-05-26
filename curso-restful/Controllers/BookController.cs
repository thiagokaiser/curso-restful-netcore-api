﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using curso_restful.Hypermedia;
using curso_restful.Interfaces;
using curso_restful.Models;
using curso_restful.Services;
using curso_restful.ViewModels;
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
            return Ok(book);
        }
                
        [HttpPost(Name = nameof(PostBook))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult PostBook([FromBody] BookVM book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(service.Create(book));
        }
                
        [HttpPut(Name = nameof(PutBook))]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult PutBook([FromBody] BookVM book)
        {
            if (book == null) return BadRequest();
            return new ObjectResult(service.Update(book));
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

using System;
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
    public class PersonController : ControllerBase
    {
        private PersonService personService;

        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }
        
        [HttpGet]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult Get()
        {
            var persons = personService.FindAll();
            persons.ForEach(c => AddLinks(c));
            return Ok(persons);
        }
                
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult Get(int id)
        {
            var person = personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult Post([FromBody] PersonVM person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(personService.Create(person));
        }
                
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult Put([FromBody] PersonVM person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(personService.Update(person));
        }
                
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult Delete(int id)
        {
            personService.Delete(id);
            return NoContent();
        }

        private void AddLinks(PersonVM person)
        {
            var path = "api/v1/person/" + person.Id;

            person.Links.Add(new HyperMediaLink("GET", path, "self", "application/json"));
            person.Links.Add(new HyperMediaLink("PUT", path, "update", "application/json"));
            person.Links.Add(new HyperMediaLink("DELETE", path, "delete", "application/json"));
        }
    }
}

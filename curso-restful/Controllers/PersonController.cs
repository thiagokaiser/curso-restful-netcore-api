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
    public class PersonController : ControllerBase
    {
        private PersonService personService;

        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }

        // GET: api/Person
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(personService.FindAll());
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(int id)
        {
            var person = personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST: api/Person
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVM person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(personService.Create(person));
        }

        // PUT: api/Person/
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVM person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(personService.Update(person));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            personService.Delete(id);
            return NoContent();
        }
    }
}

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
            AddLinks(person);

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult Post([FromBody] PersonVM person)
        {
            if (person == null) return BadRequest();
            var result = personService.Create(person);
            AddLinks(result);

            return Ok(result);
        }
                
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public IActionResult Put([FromBody] PersonVM person)
        {
            if (person == null) return BadRequest();
            var result = personService.Update(person);
            AddLinks(result);

            return Ok(result);
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

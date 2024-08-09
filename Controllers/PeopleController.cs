using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController([FromKeyedServices("PeopleService2")]IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }


        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

       [HttpGet("{id}")]
        public ActionResult<People> Get(int id)//sio no encutra un registro lo que hace es retornar un 404
        {
           var people = Repository.People.FirstOrDefault(x => x.Id == id);
            if(people == null)
            {
                return NotFound();
            }
            return Ok(people); 
        }
        [HttpGet("search/{search}")]
        public List<People> Get(string search)
        {
            return Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
        }
        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
            {
                return BadRequest();
            }
            Repository.People.Add(people);
            return NoContent();
        }
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1, Name = "Pedro", Birthdate = new DateTime(2001, 12, 3)
            },
            new People()
            {
                Id = 2, Name = "Pablito", Birthdate = new DateTime(2001, 1, 3)
            },
            new People()
            {
                Id = 3, Name = "Hector", Birthdate = new DateTime(2001, 9, 25)
            }
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}

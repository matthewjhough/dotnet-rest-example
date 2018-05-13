using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MiscREST.Models;

namespace MiscREST.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _context;
        public PersonController(PersonContext context) 
        {
            _context = context;

            if(context.People.Count() == 0) 
            {
                _context.People.Add(
                    new Person() 
                    { 
                        FirstName ="John", 
                        LastName="Doe" 
                    }
                );
                _context.SaveChanges();
            }

        }

        [HttpGet]
        public ActionResult<List<Person>> GetAll() 
        {
            return _context.People.ToList();
        }

        [HttpGet("{id}", Name = "GetPerson")]
        public ActionResult<Person> GetById(long id) 
        {
            var item = _context.People.Find(id);
            if(item == null) {
                return NotFound();
            }
            return item;
        }

    }
}
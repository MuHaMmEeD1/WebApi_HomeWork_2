using Microsoft.AspNetCore.Mvc;
using WebApi_HomeWork_2.Dtos;
using WebApi_HomeWork_2.Entitys;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_HomeWork_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {


    static public List<Person>? persons { get; set; } = new List<Person>
    {
        new Person { Id = 1, Fullname = "John Doe", SeriaNo = "A1B2C3D4E5", Age = 24, Score = 78.34 },
        new Person { Id = 2, Fullname = "Jane Smith", SeriaNo = "F9G8H7J6K5", Age = 40, Score = 67.89 },
        new Person { Id = 3, Fullname = "Alice Johnson", SeriaNo = "Z8X7C6V5B4", Age = 31, Score = 88.15 },
        new Person { Id = 4, Fullname = "Robert Brown", SeriaNo = "M7N8L9K4P3", Age = 29, Score = 90.23 },
        new Person { Id = 5, Fullname = "Mary Davis", SeriaNo = "P3O2I1U9Y8", Age = 36, Score = 74.56 },
        new Person { Id = 6, Fullname = "Michael Wilson", SeriaNo = "W6Q5T4R3E2", Age = 27, Score = 85.77 },
        new Person { Id = 7, Fullname = "Patricia Miller", SeriaNo = "J2K3L4M5N6", Age = 42, Score = 62.11 },
        new Person { Id = 8, Fullname = "Linda Martinez", SeriaNo = "C3D2E1F5G6", Age = 50, Score = 91.33 },
        new Person { Id = 9, Fullname = "William Anderson", SeriaNo = "R4T5Y6U7I8", Age = 22, Score = 79.45 },
        new Person { Id = 10, Fullname = "Barbara Thomas", SeriaNo = "O9P0Q1W2E3", Age = 33, Score = 88.98 }
    };




        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<PersonDto> Get()
        {

            var personDtos = persons.Select(p=>new PersonDto { Id=p.Id , Age=p.Age,Fullname=p.Fullname, Score=p.Score,SeriaNo=p.SeriaNo});

            return personDtos;
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = persons.FirstOrDefault(p => p.Id == id);
            if (person != null) {
            
                var personDto = new PersonDto { Id=person.Id , Age=person.Age, Fullname=person.Fullname,Score=person.Score,SeriaNo=person.SeriaNo };

                return Ok(personDto);
            }
            return NotFound();
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            persons.Add(new Person { Id = dto.Id, Fullname = dto.Fullname, SeriaNo = dto.SeriaNo, Age = dto.Age, Score = dto.Score });

            return Ok(dto); 
           
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

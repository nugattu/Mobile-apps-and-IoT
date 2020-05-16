using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab1_Kaminski.Context;
using Lab1_Kaminski.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab1_Kaminski.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly PersonContext _personContext;
        public PeopleController(PersonContext personContext)
        {
            this._personContext = personContext;
        }
        [HttpGet]
        public List<Person> Get()
        {
            List<Person> osoba = _personContext.People.ToList();
            return osoba;
        }
        [HttpGet("{id}")]
        public Person GetId([FromRoute] int id)
        {
           var osoba = _personContext.People.FirstOrDefault(p => p.PersonId == id);
            return osoba;
        }
        [HttpPost]
        public long Dodaj([FromBody]Person person)
        {
            _personContext.People.Add(person);
            var rows = _personContext.SaveChanges();
           // Console.WriteLine($"{rows}");
            return person.PersonId;
        }
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
            var osoba = _personContext.People.FirstOrDefault(p => p.PersonId == id);
            _personContext.Remove(osoba);
            _personContext.SaveChanges();
        }
        [HttpPut("{id}")]
        public Person Put([FromBody]Person person,[FromRoute] int id)
        {
            var osoba = _personContext.People.FirstOrDefault(p => p.PersonId == id);
            osoba.FirstName = person.FirstName;
            osoba.LastName = person.LastName;
            _personContext.SaveChanges();
            
            return osoba;
        }
    }
}
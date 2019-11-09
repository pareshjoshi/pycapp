using ContactsService.Models;
using ContactsService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactsRepository repository;
  
        public ContactController(IContactsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return new ActionResult<IEnumerable<Contact>>(repository.Contacts);
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            Contact contact = this.repository.Contacts.SingleOrDefault(c => id == c.Id);
            if(contact == null)
            { 
                throw new ArgumentOutOfRangeException("id");
            }

            return contact;
        }

        [HttpPost]
        public void Post([FromBody] Contact value)
        {
            repository.Add(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.repository.Remove(id);
        }
    }
}

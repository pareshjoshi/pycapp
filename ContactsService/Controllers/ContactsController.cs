using ContactsService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ContactsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            return ContactsRepo.Contacts;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var index = ContactsRepo.Contacts.FindIndex(cn => cn.Id == id);
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            return ContactsRepo.Contacts[index];
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Contact value)
        {
            ContactsRepo.Contacts.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Contact value)
        {
            var index = ContactsRepo.Contacts.FindIndex(cn => cn.Id == id);
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            ContactsRepo.Contacts[index] = value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var index = ContactsRepo.Contacts.FindIndex(cn => cn.Id == id);
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            ContactsRepo.Contacts.RemoveAt(index);
        }
    }
}

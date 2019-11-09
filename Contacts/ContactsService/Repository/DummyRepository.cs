using ContactsService.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContactsService.Repository
{
    public class DummyRepository : IContactsRepository
    {
        public static List<Contact> StaticContacts = new List<Contact>();

        static DummyRepository()
        {
            StaticContacts.Add(new Contact
            {
                Id = 1,
                Name = "paresh",
                Mobile = "0000001111",
                Email = "pjo2@example.com"
            });

            StaticContacts.Add(new Contact
            {
                Id = 2,
                Name = "ramesh",
                Mobile = "1111110000",
                Email = "rmodj@example.com"
            });
        }

        public IEnumerable<Contact> Contacts => StaticContacts;

        public void Add(Contact value)
        {
            StaticContacts.Add(value);
        }

        public void Remove(int id)
        {
            var contact = Contacts.SingleOrDefault(c => c.Id == id);

            StaticContacts.Remove(contact);
        }
    }
}

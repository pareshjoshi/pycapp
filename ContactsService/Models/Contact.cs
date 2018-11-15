using System.Collections.Generic;

namespace ContactsService.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
    }

    public static class ContactsRepo
    {
        public static List<Contact> Contacts = new List<Contact>();

        static ContactsRepo()
        {
            Contacts.Add(new Contact
            {
                Id = 1,
                Name = "paresh",
                Mobile = "0000001111",
                Email = "pjo2@example.com"
            });

            Contacts.Add(new Contact
            {
                Id = 2,
                Name = "ramesh",
                Mobile = "1111110000",
                Email = "rmodj@example.com"
            });
        }
    }
}

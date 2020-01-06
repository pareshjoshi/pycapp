namespace ContactsService.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ContactsService.Models;

    /// <summary>
    /// The test repository.
    /// </summary>
    public class InMemoryContactsRepository : IContactsRepository
    {
        private static readonly List<Contact> Contacts;

        static InMemoryContactsRepository()
        {
            Contacts = new List<Contact>(GetContacts());
        }

        /// <inheritdoc />
        public Task<Contact> AddAsync(Contact value)
        {
            value.ContactId = Guid.NewGuid();

            Contacts.Add(value);

            return Task.FromResult(value);
        }

        /// <inheritdoc />
        public Task RemoveAsync(Guid id)
        {
            return Task.Run(() =>
            {
                int index = Contacts.FindIndex(c => c.ContactId == id);
                if (index != -1)
                {
                    Contacts.RemoveAt(index);
                }
            });
        }

        /// <inheritdoc />
        public Task<Contact> ReplaceAsync(Contact value)
        {
            return Task.Run(() =>
            {
                int index = Contacts.FindIndex(c => c.ContactId == value.ContactId);

                if (index != -1)
                {
                    Contacts.RemoveAt(index);
                    Contacts.Add(value);
                }

                return value;
            });
        }

        /// <inheritdoc />
        public Task<IEnumerable<Contact>> SearchAsync(string mobile = null)
        {
            return Task.FromResult(Contacts.AsEnumerable());
        }

        private static IEnumerable<Contact> GetContacts()
        {
            yield return new Contact
            {
                ContactId = Guid.NewGuid(),
                PersonalInformation = new PersonalDetails
                {
                    FullName = "Paresh J",
                    Birthdate = new DateTime(1988, 01, 01),
                    CurrentAddress = "Universe",
                    Email = "pareshj@example.com",
                    Hobbies = new[] { "Singing", "Music" },
                    Mobile1 = "5252525252",
                    Mobile2 = "2525252525",
                    MotherTongue = "G",
                    PermanantAddress = "Another universe",
                    ProfilePicture = "http://example.com/picture1"
                },
                SatsangInformation = new SatsangDetails
                {
                    Center = "Amb",
                    IsAttendingYuvaSabha = true,
                    IsDoingPooja = true,
                    IsDoingTilakChandalo = true,
                    IsReadingVMSV = true,
                    IsSatsangiFamily = true,
                    LastSatsangExam = SatsangExam.None
                },
                WorkInformation = new WorkDetails
                {
                    Company = "Self",
                    Designation = "Con",
                    Skills = new[] { "programming", "web" },
                    Summary = "an experienced professional"
                }
            };

            yield return new Contact
            {
                ContactId = Guid.NewGuid(),
                PersonalInformation = new PersonalDetails
                {
                    FullName = "Jay J",
                    Birthdate = new DateTime(1992, 01, 01),
                    CurrentAddress = "beutiful world",
                    Email = "jayj@example.com",
                    Hobbies = new[] { "painting", "sketch" },
                    Mobile1 = "7272727272",
                    MotherTongue = "G",
                    ProfilePicture = "http://example.com/picture2"
                },
                SatsangInformation = new SatsangDetails
                {
                    Center = "Kot",
                    IsAttendingYuvaSabha = true,
                    IsDoingPooja = true,
                    IsDoingTilakChandalo = true,
                    IsReadingVMSV = true,
                    IsSatsangiFamily = true,
                    LastSatsangExam = SatsangExam.Parichay
                },
                WorkInformation = new WorkDetails
                {
                    Company = "XYZ",
                    Designation = "Manager",
                    Skills = new[] { "management", "marketting" },
                    Summary = "an executive"
                }
            };
        }
    }
}

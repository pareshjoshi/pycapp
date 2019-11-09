using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsService.Repository
{
    public interface IContactsRepository
    {
        public IEnumerable<Contact> Contacts { get; }

        void Add(Contact value);

        void Remove(int id);
    }
}

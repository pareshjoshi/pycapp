namespace ContactsService.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ContactsService.Models;

    public interface IContactsRepository
    {
        public Task<IEnumerable<Contact>> SearchAsync(string filter = null);

        Task<Contact> AddAsync(Contact value);

        Task<Contact> ReplaceAsync(Contact value);

        Task RemoveAsync(Guid id);
    }
}

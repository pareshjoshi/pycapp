namespace ContactsService.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ContactsService.Models;

    /// <summary>
    /// The contacts repository interface.
    /// </summary>
    public interface IContactsRepository
    {
        /// <summary>
        /// Searches the contact from the repository.
        /// </summary>
        public Task<IEnumerable<Contact>> SearchAsync(string filter = null);

        /// <summary>
        /// Adds the contact to the repository.
        /// </summary>
        Task<Contact> AddAsync(Contact value);

        /// <summary>
        /// Replaces the contact in the repository.
        /// </summary>
        Task<Contact> ReplaceAsync(Contact value);

        /// <summary>
        /// Remove the contact from the repository.
        /// </summary>
        Task RemoveAsync(Guid id);
    }
}

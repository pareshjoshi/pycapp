namespace ContactsService.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ContactsService.Configuration;
    using ContactsService.Models;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;

    /// <summary>
    /// The contacts repository.
    /// </summary>
    public class ContactsRepository : IContactsRepository
    {
        private readonly IMongoCollection<Contact> collection;

        public ContactsRepository(IMongoClient connection, IOptions<Mongo> mongoConfiguration)
        {
            var configuration = mongoConfiguration.Value;
            var database = connection.GetDatabase(configuration.Database);

            collection = database.GetCollection<Contact>(configuration.ContactsCollection);
        }

        public async Task<IEnumerable<Contact>> SearchAsync(string contactId = null)
        {
            var filterDefinition = !string.IsNullOrWhiteSpace(contactId) ? Builders<Contact>.Filter.Eq(x => x.ContactId, new Guid(contactId)) : FilterDefinition<Contact>.Empty;

            var cursor = await collection.FindAsync<Contact>(filterDefinition);

            return cursor.ToEnumerable();
        }

        public async Task<Contact> AddAsync(Contact value)
        {
            value.ContactId = Guid.NewGuid();

            await collection.InsertOneAsync(value);

            var builder = Builders<Contact>.Filter;
            var filter = builder.Eq(c => c.ContactId, value.ContactId);

            var cursor = await collection.FindAsync<Contact>(filter);

            return await cursor.SingleAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var builder = Builders<Contact>.Filter;
            var filter = builder.Eq(c => c.ContactId, id);

            var result = await collection.DeleteOneAsync(filter);
        }

        public async Task<Contact> ReplaceAsync(Contact value)
        {
            var builder = Builders<Contact>.Filter;
            var filter = builder.Eq(c => c.ContactId, value.ContactId);

            var cursor = await collection.FindAsync<Contact>(filter);
            var contact = await cursor.SingleAsync();
            value.Id = contact.Id;

            var res = await collection.ReplaceOneAsync(filter, value);

            cursor = await collection.FindAsync<Contact>(filter);

            return await cursor.SingleAsync();
        }
    }
}

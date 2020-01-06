namespace ContactsService.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ContactsService.Models;
    using ContactsService.Repository;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The contacts controller that exposes the endpoints to manage contacts information.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactsController"/> class.
        /// </summary>
        public ContactsController(IContactsRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets all contacts from the repository.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            try
            {
                return Ok(await repository.SearchAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"There was an error when retrieving the contacts from the server. {e.Message}" });
            }
        }

        /// <summary>
        /// Gets the contact that represents the contact id <paramref name="contactId"/>.
        /// </summary>
        [HttpGet("{contactId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Contact>> GetById(Guid contactId)
        {
            try
            {
                var contacts = await this.repository.SearchAsync(contactId.ToString());

                var contact = contacts.FirstOrDefault();

                if (contacts == null)
                {
                    NotFound(new { Message = $"No record found with the id - {contactId}" });
                }

                return contact;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"There was an error when retrieving the contact from the server. {e.Message}" });
            }
        }

        /// <summary>
        /// Creates a new contact.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Contact>> Create([FromBody] Contact value)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, await repository.AddAsync(value));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"There was an error when writing the contact to the server. {e.Message}" });
            }
        }

        /// <summary>
        /// Updates the contact.
        /// </summary>
        [HttpPost("{contactId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Contact>> Update(Guid contactId, [FromBody] Contact value)
        {
            try
            {
                if (!Guid.Equals(contactId, value.ContactId))
                {
                    return BadRequest(new { Message = $"Invalid contact id {contactId} supplied for updating record" });
                }

                return StatusCode(StatusCodes.Status201Created, await repository.ReplaceAsync(value));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"There was an error when updating the contact to the server. {e.Message}" });
            }
        }

        /// <summary>
        /// Deletes the contact permenantly.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(Guid id)
        {
            try
            {
                this.repository.RemoveAsync(id);

                return Ok(new { Message = "record deleted successfully" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"There was an error when removing the contact from the server. {e.Message}" });
            }
        }
    }
}

using FirstBlazorApp.Data;
using FirstBlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {

        private readonly IContactsRepository _contactsRepository;
        public ContactsController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<IEnumerable<Contact>> Get() //Task es el metodo asincronico de controller y <Contact> es lo que me devuelve
        {
            return await _contactsRepository.GetAll();
        }

        // GET api/Contacts/5
        [HttpGet("{id}")]
        public async Task<Contact> Get(int id)
        {
            return await _contactsRepository.GetDetails(id);
        }

        // POST api/<ContactsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Contact contact) // <IActionResult> es lo q devuelve una https response, ([FromBody] es lo q va dentro del body)
        {
            if(contact == null)
                return BadRequest();

            if (string.IsNullOrEmpty(contact.LastName))
                ModelState.AddModelError("Contact", "LastName can't be empty"); //devolucion de errores
            if(!ModelState.IsValid)
                return BadRequest(ModelState); //devuelvo el error para que lo vea el usuario

            await _contactsRepository.Insert(contact);
            return NoContent();
        }

        // PUT api/Contact/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest();

            if (string.IsNullOrEmpty(contact.LastName))
                ModelState.AddModelError("Contact", "LastName can't be empty"); //devolucion de errores
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //devuelvo el error para que lo vea el usuario
            if(contact.Id == 0)
                contact.Id = id;

            await _contactsRepository.Update(contact);
            return NoContent();
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactsRepository.Delete(id);
            return NoContent();
        }
    }
}

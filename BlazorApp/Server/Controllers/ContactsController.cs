using BlazorApp.Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Controllers
{
    //this api is accesable without authorisation just for testing reasons
    //uncoment bellow to make secure
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly DataContext _context;
        public ContactsController(DataContext context)
        {

            _context = context;
        }



        //returns list of all contacts
        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }



        //returns one contact by the ID provided by user
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetSingleContact(int id)
        {
            var singleContact = await _context.Contacts.
                Include(h => h.Category).
                FirstOrDefaultAsync(h => h.Id == id);
            if (singleContact == null)
            {
                return NotFound("Not found");
            }
            return Ok(singleContact);
        }
        //returns list of categories
        [HttpGet("categories")]
        public async Task<ActionResult<List<Category>>> GetCartegories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);

        }
        //returns list of subcategories
        [HttpGet("subcategories")]
        public async Task<ActionResult<List<Category>>> GetSubCartegories()
        {
            var subCategories = await _context.SubCategories.ToListAsync();
            return Ok(subCategories);
        }
        //creates a new contact
        [HttpPost]
        public async Task<ActionResult<List<Contact>>> CreateContact(Contact contact)
        {
            contact.Category = null;
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Ok(await GetDbContacts());
        }
        //updates contacts
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Contact>>> UpdateContact(Contact contact, int id)
        {
            var dbContact = await _context.Contacts
                .Include(h => h.Category).
                FirstOrDefaultAsync(h => h.Id == id);
            if (dbContact == null)
            {
                return NotFound("not found");
            }

            dbContact.Name = contact.Name;
            dbContact.Surname = contact.Surname;
            dbContact.Address = contact.Address;
            dbContact.Password = contact.Password;
            dbContact.Mail = contact.Mail;
            dbContact.CategoryID = contact.CategoryID;
            dbContact.SubCategoryId = contact.SubCategoryId;
            dbContact.Telepfone = contact.Telepfone;
            dbContact.Birthdate = contact.Birthdate;

            await _context.SaveChangesAsync();
            return Ok(await GetDbContacts());

        }
        //deletes a contact by id
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> DeleteContact(int id)
        {
            var dbContact = await _context.Contacts
               .Include(h => h.Category).
               FirstOrDefaultAsync(h => h.Id == id);
            if (dbContact == null)
            {
                return NotFound("not found");
            }
            _context.Contacts.Remove(dbContact);
            await _context.SaveChangesAsync();

            return Ok(await GetDbContacts());

        }

        private async Task<List<Contact>> GetDbContacts()
        {
            return await _context.Contacts.Include(h => h.Category).ToListAsync();
        }

    }
}

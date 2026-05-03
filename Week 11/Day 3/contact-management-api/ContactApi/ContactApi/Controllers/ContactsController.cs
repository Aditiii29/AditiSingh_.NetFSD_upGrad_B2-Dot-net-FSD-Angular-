using Microsoft.AspNetCore.Mvc;
using ContactApi.Models;

namespace ContactApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ContactsController : ControllerBase
  {
    private static List<Contact> contacts = new List<Contact>
        {
            new Contact { Id = 1, Name = "Aditi", Email = "aditi@gmail.com", Phone = "9999999999" }
        };

    // GET: api/contacts
    [HttpGet]
    public ActionResult<IEnumerable<Contact>> GetAll()
    {
      return Ok(contacts);
    }

    // GET: api/contacts/1
    [HttpGet("{id}")]
    public ActionResult<Contact> GetById(int id)
    {
      var contact = contacts.FirstOrDefault(c => c.Id == id);
      if (contact == null) return NotFound();
      return Ok(contact);
    }

    // POST: api/contacts
    [HttpPost]
    public ActionResult Add(Contact contact)
    {
      contact.Id = contacts.Count + 1;
      contacts.Add(contact);
      return Ok(contact);
    }

    // PUT: api/contacts/1
    [HttpPut("{id}")]
    public ActionResult Update(int id, Contact updated)
    {
      var contact = contacts.FirstOrDefault(c => c.Id == id);
      if (contact == null) return NotFound();

      contact.Name = updated.Name;
      contact.Email = updated.Email;
      contact.Phone = updated.Phone;

      return Ok(contact);
    }

    // DELETE: api/contacts/1
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      var contact = contacts.FirstOrDefault(c => c.Id == id);
      if (contact == null) return NotFound();

      contacts.Remove(contact);
      return Ok();
    }
  }
}

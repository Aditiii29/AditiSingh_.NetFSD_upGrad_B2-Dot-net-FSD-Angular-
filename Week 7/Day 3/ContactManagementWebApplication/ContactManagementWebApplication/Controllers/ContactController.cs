using Microsoft.AspNetCore.Mvc;
using ContactManagementWebApplication.Services;
using ContactManagementWebApplication.Models;

namespace ContactManagementWebApplication.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        // Constructor Injection
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Show all contacts
        [HttpGet("list")]
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // Get contact by ID
        [HttpGet("get/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        // Show add form
        [HttpGet("add")]
        public IActionResult AddContact()
        {
            return View();
        }

        // Add contact
        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}

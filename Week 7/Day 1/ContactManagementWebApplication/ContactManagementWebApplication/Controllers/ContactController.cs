using Microsoft.AspNetCore.Mvc;
using ContactManagementWebApplication.Models;

namespace ContactManagementWebApplication.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        // In-memory list (No DB)
        private static List<ContactInfo> contactList = new List<ContactInfo>()
        {
            new ContactInfo { ContactId=1, FirstName="Rahul", LastName="Sharma", CompanyName="ABC Infotech",  EmailId="rahul@abc.com", MobileNo=9876543210, Designation="Developer" },
            new ContactInfo { ContactId=2, FirstName="Priya", LastName="Verma",  CompanyName="XYZ Solutions", EmailId="priya@xyz.com", MobileNo=9123456789, Designation="Designer"  },
            new ContactInfo { ContactId=3, FirstName="Amit",  LastName="Patel",  CompanyName="Tech Corp",     EmailId="amit@tech.com", MobileNo=9988776655, Designation="Manager"   }
        };

        // 1. Show all contacts
        [Route("ShowContacts")]
        public ActionResult ShowContacts() => View(contactList);

        // 2. Get contact by ID
        [Route("GetContactById")]
        public ActionResult GetContactById(int id)
        {
            var contact = contactList.FirstOrDefault(c => c.ContactId == id);
            if (contact == null) ViewBag.Message = $"No contact found with ID = {id}";
            return View(contact);
        }


        // 3. GET: Add Contact
        [Route("AddContact"), HttpGet]
        public ActionResult AddContact() => View();

        // 4. POST: Add Contact
        [Route("AddContact"), HttpPost]
        public ActionResult AddContact(ContactInfo c)
        {
            c.ContactId = contactList.Count > 0 ? contactList.Max(x => x.ContactId) + 1 : 1;
            contactList.Add(c);
            return RedirectToAction("ShowContacts");
        }
    }
}
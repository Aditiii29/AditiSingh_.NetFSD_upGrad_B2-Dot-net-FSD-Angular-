using DAL.Model;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppUILayer.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        [Route("ShowContacts")]
        [HttpGet]
        public IActionResult ShowContacts()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }

        [Route("Details/{id}")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null) return NotFound();
            return View(contact);
        }

        [Route("AddContact")]
        [HttpGet]
        public IActionResult AddContact()
        {
            // Load companies and departments for dropdowns
            var companies = _repo.GetAllCompanies();
            var departments = _repo.GetAllDepartments();

            // Pass to view using ViewBag
            ViewBag.Companies = new SelectList(
                companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(
                departments, "DepartmentId", "DepartmentName");

            return View();
        }

        [Route("AddContact")]
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }
            var companies = _repo.GetAllCompanies();
            var departments = _repo.GetAllDepartments();
            ViewBag.Companies = new SelectList(
                companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(
                departments, "DepartmentId", "DepartmentName");
            return View(contact);
        }

        [Route("EditContact/{id}")]
        [HttpGet]
        public IActionResult EditContact(int id)
        {
            var contact = _repo.GetContactById(id);
            if (contact == null) return NotFound();
            var companies = _repo.GetAllCompanies();
            var departments = _repo.GetAllDepartments();
            ViewBag.Companies = new SelectList(
                companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(
                departments, "DepartmentId", "DepartmentName");
            return View(contact);
        }

        [Route("EditContact")]
        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }
            var companies = _repo.GetAllCompanies();
            var departments = _repo.GetAllDepartments();
            ViewBag.Companies = new SelectList(
                companies, "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(
                departments, "DepartmentId", "DepartmentName");
            return View(contact);
        }

        [Route("DeleteContact/{id}")]
        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }
    }
}
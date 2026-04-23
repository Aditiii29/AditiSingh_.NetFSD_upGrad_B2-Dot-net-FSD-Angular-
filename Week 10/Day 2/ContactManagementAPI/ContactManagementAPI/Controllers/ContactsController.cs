using ContactManagementAPI.Models;
using ContactManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactService _service;
    private readonly ILogger<ContactsController> _logger;

    public ContactsController(IContactService service,
                              ILogger<ContactsController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogInformation("GetAll called");
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var contact = _service.GetById(id);
        if (contact == null)
            return NotFound($"Contact {id} not found");
        return Ok(contact);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Contact contact)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var created = _service.Add(contact);
        return CreatedAtAction(nameof(GetById),
                               new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Contact contact)
    {
        var updated = _service.Update(id, contact);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (!_service.Delete(id))
            return NotFound();
        return NoContent();
    }
}
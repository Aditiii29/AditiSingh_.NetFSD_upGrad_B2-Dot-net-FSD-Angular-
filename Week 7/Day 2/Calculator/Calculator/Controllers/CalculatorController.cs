using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    [Route("calc")]
    public class CalculatorController : Controller
    {
        // GET → Show form
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        // POST → Handle form submission
        [HttpPost("add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;

            // Pass result using ViewData
            ViewData["Result"] = result;

            return View("Add");
        }
    }
}
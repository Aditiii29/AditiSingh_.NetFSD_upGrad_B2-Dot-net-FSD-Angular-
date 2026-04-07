using Microsoft.AspNetCore.Mvc;

namespace Problem4.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        // GET → Show form
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        // POST → Handle submission
        [HttpPost("form")]
        public IActionResult Form(string name, string comments, int rating)
        {
            string message;

            // Conditional logic
            if (rating >= 4)
            {
                message = "Thank You for your valuable feedback!";
            }
            else
            {
                message = "We will improve based on your feedback.";
            }

            // Pass message using ViewData
            ViewData["Message"] = message;
            ViewData["Name"] = name;

            return View();
        }
    }
}

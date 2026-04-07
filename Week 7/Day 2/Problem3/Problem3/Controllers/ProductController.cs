using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Problem3.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        // Static list to store products (temporary memory)
        private static List<Product> products = new List<Product>();

        // GET → Show form + list
        [HttpGet("add")]
        public IActionResult Add()
        {
            ViewBag.Products = products;
            return View();
        }

        // POST → Add product
        [HttpPost("add")]
        public IActionResult Add(string name, double price, int quantity)
        {
            // Create new product
            Product p = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            // Add to list
            products.Add(p);

            // Pass list using ViewBag
            ViewBag.Products = products;

            return View();
        }
    }

    // Simple class (NOT a Model as per restriction)
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}

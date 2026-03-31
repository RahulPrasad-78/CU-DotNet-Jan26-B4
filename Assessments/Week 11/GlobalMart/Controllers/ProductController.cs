using GlobalMart.Models;
using GlobalMart.Services;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
{
    public class ProductController : Controller
    {
        private readonly IPricingService _Service;
        public ProductController(IPricingService service)
        {
            _Service = service;
        }
        List<Product> products = new List<Product>()
        {
            new Product(){ProductId=1, Name="Laptop", Price=50000, Description="High-performance laptop suitable for coding, gaming, and multitasking."},
            new Product(){ProductId=2, Name="Mobile", Price=20000, Description="Affordable smartphone with good camera and battery life."},
            new Product(){ProductId=3, Name="Tablet", Price=30000, Description="Portable tablet ideal for reading, streaming, and light work."},
            new Product(){ProductId=4, Name="Smartwatch", Price=10000, Description="Wearable device for fitness tracking, notifications, and health monitoring."},
            new Product(){ProductId=5, Name="Headphones", Price=5000, Description="Noise-cancelling headphones with high-quality sound output."},
            new Product(){ProductId=6, Name="Keyboard", Price=2500, Description="Mechanical keyboard designed for fast typing and gaming precision."}
        };

        // GET: ProductController
        public ActionResult Index()
        {
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}

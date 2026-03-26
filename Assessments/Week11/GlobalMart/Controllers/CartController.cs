using GlobalMart.Models;
using GlobalMart.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMart.Controllers
{
    public class CartController : Controller
    {
        private readonly IPricingService _service;
        public CartController(IPricingService service)
        {
            _service = service;
        }

        private const string CartKey = "Cart";

        private List<Cart> GetCart()
        {
            var data = HttpContext.Session.GetString(CartKey);

            if (string.IsNullOrEmpty(data))
                return new List<Cart>();

            return System.Text.Json.JsonSerializer.Deserialize<List<Cart>>(data);
        }

        private void SaveCart(List<Cart> cart)
        {
            HttpContext.Session.SetString(CartKey,
                System.Text.Json.JsonSerializer.Serialize(cart));
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
        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(int productId)
        {
            var cart = GetCart();

            var product = products.Find(p => p.ProductId == productId);

            if (product == null)
                return BadRequest("Product not found");

            string promo = "WINTER25";
            decimal discountedPrice = _service.CalculatePrice(product.Price, promo);

            cart.Add(new Cart
            {
                Name = product.Name,
                Price = discountedPrice
            });

            SaveCart(cart);

            return RedirectToAction("Index");
        }
    }
}

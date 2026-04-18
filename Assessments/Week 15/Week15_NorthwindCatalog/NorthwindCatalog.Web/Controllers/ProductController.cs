using Microsoft.AspNetCore.Mvc;

namespace NorthwindCatalog.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _factory;

        public ProductController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IActionResult> ByCategory(int id)
        {
            var client = _factory.CreateClient("api");

            var products = await client.GetFromJsonAsync<List<ProductDto>>
                ($"api/products/by-category/{id}");

            return View(products);
        }
    }
}
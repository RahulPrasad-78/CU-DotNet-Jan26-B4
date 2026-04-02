using Microsoft.AspNetCore.Mvc;
using SmartBank.Web.Models;
using System.Text;
using System.Text.Json;

namespace SmartBank.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _client;

        public AuthController(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("Gateway");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("auth/register", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Login");

            ViewBag.Error = await response.Content.ReadAsStringAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("auth/login", content);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Invalid login";
                return View(model);
            }

            var result = await response.Content.ReadAsStringAsync();

            var jsonDoc = JsonDocument.Parse(result);
            var token = jsonDoc.RootElement.GetProperty("token").GetString();

            HttpContext.Session.SetString("JWT", token);

            return RedirectToAction("Index", "Home");
        }
    }
}
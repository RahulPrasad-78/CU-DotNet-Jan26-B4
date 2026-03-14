using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Summary()
        {
            ViewBag.MarketStatus = "Open";

            ViewData["TopGainer"] = "F1";
            ViewData["Volume"] = 1250000;
            return View();
        }

        [HttpGet("Analyze/{ticker}/{days:int?}")]
        public IActionResult Search(string ticker, int? days)
        {
            if (days == null)
            {
                days = 30;
            }

            ViewBag.Ticker = ticker;
            ViewBag.Days = days;

            return View();
        }
    }
}

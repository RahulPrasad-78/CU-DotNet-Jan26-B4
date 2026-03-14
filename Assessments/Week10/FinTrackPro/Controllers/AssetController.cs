using FinTrackPro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTrackPro.Controllers
{
    public class AssetController : Controller
    {
        // GET: AssetController
        private static List<Assets> assets = new List<Assets>()
        {
            new Assets{Id = 101, Name="Rahul", Price = 700000},
            new Assets{Id = 102, Name="Rohan", Price = 400000},
            new Assets{Id = 101, Name="Ram", Price = 300000}
        };
        public ActionResult Index()
        {
            ViewData["Total"] = assets.Sum(x => x.Price);
            return View(assets);
        }

        // GET: AssetController/Details/5
        [Route("Asset/Info/{id:int}")]
        public ActionResult Details(int id)
        {
            var asset = assets[0];
            foreach (var a in assets)
            {
                if(id == a.Id)
                {
                    return View(a);
                }
            }
            return View(model: null);
        }

        // GET: AssetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetController/Delete/5
        public ActionResult Delete(int id)
        {
            Assets asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset == null)
            {
                return NotFound();
            }

            return View(asset);
        }

        // POST: AssetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var asset = assets.FirstOrDefault(a => a.Id == id);

            if (asset != null)
            {
                assets.Remove(asset);
                TempData["Message"] = "Asset deleted successfully.";
            }

            return RedirectToAction("Index");
        }
    }
}

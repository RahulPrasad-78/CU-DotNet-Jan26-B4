using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VagaBond.MVC.DTO;
using VagaBond.MVC.Models;
using VagaBond.MVC.Service;

namespace VagaBond.MVC.Controllers
{
    public class DestinationController : Controller
    {
        private readonly DestinationService _service;

        public DestinationController(DestinationService service)
        {
            _service = service;
        }

        // GET: Destination
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        // GET: Destination/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            return View(data);
        }

        // GET: Destination/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destination/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Destination des)
        {
            if (!ModelState.IsValid)
                return View(des);

            var result = await _service.CreateAsync(des);

            if (result)
                return RedirectToAction("Index");

            return View(des);
        }

        // GET: Destination/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            return View(data);
        }

        // POST: Destination/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Destination des)
        {
            if (id != des.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(des);

            try
            {
                var result = await _service.UpdateAsync(id, des);

                if (result)
                    return RedirectToAction("Index");

                ModelState.AddModelError(string.Empty, "Unable to update the destination. Please try again.");
                return View(des);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the destination.");
                return View(des);
            }
        }

        // GET: Destination/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound(); // instead of crash

            return View(data);
        }

        // POST: Destination/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);

                if (!result)
                {
                    // Could not delete (not found or server error)
                    return BadRequest();
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                // log if available
                return BadRequest();
            }
        }
    }
}

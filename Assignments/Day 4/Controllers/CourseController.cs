using Microsoft.AspNetCore.Mvc;

namespace TrainingPortal.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Topic()
        {
            return View();
        }
    }
}

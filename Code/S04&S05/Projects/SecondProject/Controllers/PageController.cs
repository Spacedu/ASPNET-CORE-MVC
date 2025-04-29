using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

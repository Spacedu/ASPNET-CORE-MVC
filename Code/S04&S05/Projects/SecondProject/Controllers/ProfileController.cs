using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

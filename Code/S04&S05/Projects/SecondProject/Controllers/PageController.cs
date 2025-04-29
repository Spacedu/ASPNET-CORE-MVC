using Microsoft.AspNetCore.Mvc;
using SecondProject.Models;

namespace SecondProject.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassData()
        {
            var news = new News { Title = "News of now", Author="Elias", Message="Good day!" };
            return View(news);
        }
    }
}

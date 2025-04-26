using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

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
            /*
             * Request/Response
             * ViewBag - Dynamic
             * ViewData - Dictonary
             * 
             * Request/Response > Redirect
             * TempData - Dictonary
             */

            ViewBag.Company = "Microsoft";
            ViewBag.Founder = "Bill Gates";
            ViewBag.CEO = "Satya Nadella";

            ViewData["Company2"] = "Apple";
            ViewData["Founder2"] = "Steven Jobs & Steve Wozniak";
            ViewData["CEO2"] = "Tim Cook";


            TempData["Company"] = "Oracle";
            TempData["Founder"] = "Larry Ellison";
            TempData["CEO"] = "Safra A. Catz";

            /*
             * For Test TempData enable this line: return RedirectToAction("ViewTempData");
             */
            

            var news = new News { Title = "News of now", Author="Elias", Message="Good day!" };
            return View(news);
        }

        public IActionResult ViewTempData()
        {
            return Ok($"{TempData.Peek("Company")} - {TempData["Founder"]} - {TempData["CEO"]}");
        }

        public IActionResult Flow()
        {
            List<News> news = new List<News>();
            /*news.Add(new News { Title = "News of now 1", Author = "Elias 1", Message = "Good day!" });
            news.Add(new News { Title = "News of now 2", Author = "Elias 2", Message = "Good day!" });
            news.Add(new News { Title = "News of now 3", Author = "Elias 3", Message = "Good day!" });
            news.Add(new News { Title = "News of now 4", Author = "Elias 4", Message = "Good day!" });
            */
            return View(news);
        }
    }
}

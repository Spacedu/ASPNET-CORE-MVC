using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Article(string slug)
        {
            return Ok($"Blog > Article: {slug}");
        }
    }
}

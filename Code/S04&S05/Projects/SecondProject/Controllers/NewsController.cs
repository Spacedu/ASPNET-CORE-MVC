using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Controllers;


[Route("News")]
public class NewsController : Controller
{
    [Route("List")]
    public IActionResult Index()
    {
        return Ok("News > List");
    }

    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id)
    {
        return Ok($"News > Edit: {id}");
    }

    


}

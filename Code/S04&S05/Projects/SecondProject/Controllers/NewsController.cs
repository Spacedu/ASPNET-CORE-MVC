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

    /*
     * Model Binding
     * 
     * HTML Form = Method = GET | POST
     * ?title=xyz&message=xyz (80k char limit)
     * 
     * Form: title=xyz&message=xyz
     */
    [HttpPost("Add")]
    public IActionResult Add([FromQuery]string author, string title, string message)
    {
        return Ok();
    }

    [HttpGet("Edit/{id}")]
    public IActionResult Edit(int id)
    {
        return Ok($"News > Edit: {id}");
    }
}

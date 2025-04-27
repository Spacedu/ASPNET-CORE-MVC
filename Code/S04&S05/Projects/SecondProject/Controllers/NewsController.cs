using Microsoft.AspNetCore.Mvc;
using SecondProject.Models;

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
    [HttpGet("Add")]
    public IActionResult AddGet([FromQuery] News news)
    {
        return Ok();
    }
    [HttpPost("Add")]
    public IActionResult AddPost([FromHeader] string authorization, [FromForm] News news)
    {
        return Ok();
    }

    [HttpPost("Edit/{id}")]
    public IActionResult Edit(int id, [FromBody] News json)
    {
        return Ok($"News > Edit: {id}");
    }
}

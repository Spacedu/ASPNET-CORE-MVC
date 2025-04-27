using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Controllers;

[Route("ResultType")]
public class ResultTypeController : Controller
{
    [Route("Content")]
    public IActionResult ContentResult()
    {
        return Content("This is content result 2", "text/plain");

        return new ContentResult
        {
            StatusCode = 200,
            ContentType = "text/plain",
            Content = "This is content result"
        };
    }
}

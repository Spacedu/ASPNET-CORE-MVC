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

    [Route("Json")]
    public IActionResult JsonResult()
    {
        var obj = new { title = "XYZ", content = "XYZ-Content" };

        return Json(obj);

        return new JsonResult(obj);
    }

    [Route("File-Virtual")]
    public IActionResult FileVirtual()
    {
        return File("Files/articles.pdf", "application/pdf");

        return new VirtualFileResult("Files/articles.pdf", "application/pdf");
    }
    [Route("File-Physical")]
    public IActionResult FilePhysical()
    {
        return PhysicalFile(@"C:\Users\elias\Downloads\article.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");

        return new PhysicalFileResult(@"C:\Users\elias\Downloads\article.docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
    }
    [Route("File-Content")]
    public IActionResult FileContent()
    {
        byte[] fileInBytes = System.IO.File.ReadAllBytes(@"C:\Users\elias\Downloads\articles.pdf");

        return File(fileInBytes, "application/pdf");
        return new FileContentResult(fileInBytes, "application/pdf");
    }

    [Route("View")]
    public IActionResult ViewResult()
    {
        return View("View2");
        return new ViewResult { ContentType = "text/html", ViewName = "ViewResult" };
    }
}

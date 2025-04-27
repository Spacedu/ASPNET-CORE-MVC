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
    
    [Route("Redirect")]
    public IActionResult RedirectResult()
    {
        return Redirect("https://www.google.com");
        return new RedirectResult("https://www.google.com");
    }
    
    [Route("Redirect-Local")]
    public IActionResult RedirectLocalResult()
    {
        return LocalRedirect("/ResultType/View");
        return new LocalRedirectResult("/ResultType/View");
    }
    
    [Route("Redirect-Action")]
    public IActionResult RedirectActionResult()
    {
        var controller = nameof(ResultTypeController).Replace("Controller", string.Empty);
        var action = nameof(ContentResult).Replace("Result", string.Empty);

        return RedirectToAction(action, controller, new { slug = "slug1" });
        return new RedirectToActionResult("Json", "ResultType", new { slug = "slug1" });
    }
}

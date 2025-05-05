using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Libraries.ViewComponents;

public class AdsViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}

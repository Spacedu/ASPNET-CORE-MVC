using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Libraries.ViewComponents;

public class AdsViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string title)
    {
        //TODO - Get List from Database
        var ads = GetAdsFromDatabase();
        return View(ads);
    }

    public List<Ads> GetAdsFromDatabase()
    {
        List<Ads> ads = new List<Ads>();
        ads.Add(new Ads() { Title = "Ads 1", Description = "Lorem 1....." });
        ads.Add(new Ads() { Title = "Ads 2", Description = "Lorem 2....." });
        ads.Add(new Ads() { Title = "Ads 3", Description = "Lorem 3....." });

        return ads;
    }
}
public class Ads
{
    public string Title { get; set; }
    public string Description { get; set; }
}

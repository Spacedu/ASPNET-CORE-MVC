var builder = WebApplication.CreateBuilder(args);
#region MVC - Service
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
#endregion

var app = builder.Build();
//Middleware - Blazor, MVC, RazorPage
app.UseStaticFiles();

#region MVC - Config. Routing
/*
 * MVC - URL
 * https://localhost/{controller}/{action}/{id?}
 * https://localhost/Product/Index
 * https://localhost/Product/Add
 * https://localhost/Product/Edit/1
 * https://localhost/Product/Delete/1
 * https://localhost:7000/
 * 
 * https://localhost/Product > https://localhost/Product/Index
 * 
 * BLOG/NEWS - URL
 * https://localhost/article/{slug (title) == id (int, long, guid)}
 * https://localhost/article/how-to-take-better-performance
 */

app.UseRouting();

app.MapControllers();

//Conventions
app.MapControllerRoute(
    name: "blog",
    pattern: "article/{*slug}",
    defaults: new {controller="Blog", action="Article" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
#endregion
app.Run();
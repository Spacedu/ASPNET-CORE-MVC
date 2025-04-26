var builder = WebApplication.CreateBuilder(args);
#region MVC - Service
builder.Services.AddControllersWithViews();
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
 */

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
#endregion
app.Run();
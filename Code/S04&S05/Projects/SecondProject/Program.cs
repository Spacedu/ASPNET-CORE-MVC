var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Middleware - Blazor, MVC, RazorPage
app.UseStaticFiles();

app.Run();

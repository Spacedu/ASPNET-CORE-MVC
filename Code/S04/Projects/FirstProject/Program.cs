var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) => {

    if (context.Request.Path.StartsWithSegments("/contact"))
    {
        context.Response.Headers.ContentType = "text/html";

        await context.Response.WriteAsync("<h1>Contact page</h1>with form!");
    }
    else { 
        await context.Response.WriteAsync("Site under construction");
    }
});

app.Run();

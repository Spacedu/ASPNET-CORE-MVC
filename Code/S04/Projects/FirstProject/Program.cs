using System.Text.Json;
using FirstProject;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Client> clients = new List<Client>();
clients.Add(new Client { Name = "John" });
clients.Add(new Client { Name = "Joseph" });
clients.Add(new Client { Name = "Mary" });

app.Run(async (HttpContext context) => {
    if (context.Request.Path.StartsWithSegments("/api/clients"))
    {
        context.Response.Headers.ContentType = "application/json";

        var json = JsonSerializer.Serialize(clients);
        await context.Response.WriteAsync(json);

    } else if (context.Request.Path.StartsWithSegments("/contact"))
    {
        context.Response.Headers.ContentType = "text/html";

        await context.Response.WriteAsync("<h1>Contact page</h1>with form!");
    }
    else
    {
        await context.Response.WriteAsync("Site under construction");
    }
});

app.Run();

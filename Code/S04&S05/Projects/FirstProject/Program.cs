using System.Text.Json;
using FirstProject;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Client> clients = new List<Client>();
clients.Add(new Client { Name = "John" });
clients.Add(new Client { Name = "Joseph" });
clients.Add(new Client { Name = "Mary" });

/*
 * HTML: GET (Tag: a), POST (Form)
 * JS: GET, POST, PUT, PATCH, DELETE
 * API:
 * - RESTful - HTTP: GET, POST, PUT, PATCH, DELETE
 * - GraphQL
 * - gRPC
 * 
 * Postman* | Insomnia | VS(http)
 */

// Authentication | JSON > XML | Cookie | Configuration(Routing) | Middleware(Logs, Message on Screen)

//Middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 1: Init");
    await next(context);
    await context.Response.WriteAsync("Middlware 1: Finish");
});

//Middleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 2: Init");
    await next(context);
    await context.Response.WriteAsync("Middlware 2: Finish");
});

app.Run(async (HttpContext context) => {
    if(context.Request.Method == "GET")
    {
        //Browser
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
            //context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Page not found!!! :(");
        }
    }
    else if(context.Request.Method == "POST")
    {
        if (context.Request.Path.StartsWithSegments("/api/clients"))
        {
            // IO
            using (var reader = new StreamReader(context.Request.Body))
            {
                var body = await reader.ReadToEndAsync();

                Client client = JsonSerializer.Deserialize<Client>(body)!;
                clients.Add(client);
            }
        }
    }else if (context.Request.Method == "PUT")
    {
        // /api/clients/3
        if (context.Request.Path.StartsWithSegments("/api/clients"))
        {
            var sequenceFromUrl = context.Request.Path.Value!.Replace("/api/clients/", string.Empty);
            int sequence = int.Parse(sequenceFromUrl) - 1;

            clients.Remove(clients[sequence]);
            using (var reader = new StreamReader(context.Request.Body))
            {
                var body = await reader.ReadToEndAsync();

                Client client = JsonSerializer.Deserialize<Client>(body)!;
                clients.Insert(sequence, client);
            }

        }
    }
    else if (context.Request.Method == "DELETE")
    {
        if (context.Request.Path.StartsWithSegments("/api/clients"))
        {
            var sequenceFromUrl = context.Request.Path.Value!.Replace("/api/clients/", string.Empty);
            int sequence = int.Parse(sequenceFromUrl) - 1;

            clients.Remove(clients[sequence]);
        }
    } 
});

app.Run();

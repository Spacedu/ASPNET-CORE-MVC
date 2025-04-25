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

app.Run(async (HttpContext context) => {
    if(context.Request.Method == "GET")
    {
        //Browser
        if (context.Request.Path.StartsWithSegments("/api/clients"))
        {
            context.Response.Headers.ContentType = "application/json";

            var json = JsonSerializer.Serialize(clients);
            await context.Response.WriteAsync(json);
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

    }else if (context.Request.Method == "DELETE")
    {

    }


    /*
    else if (context.Request.Path.StartsWithSegments("/contact"))
    {
        context.Response.Headers.ContentType = "text/html";

        await context.Response.WriteAsync("<h1>Contact page</h1>with form!");
    }
    else
    {
        await context.Response.WriteAsync("Site under construction");
    }*/
});

app.Run();

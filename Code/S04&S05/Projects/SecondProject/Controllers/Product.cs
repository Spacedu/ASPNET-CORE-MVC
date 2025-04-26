using Microsoft.AspNetCore.Mvc;

namespace SecondProject.Controllers;

[Controller]
public class Product
{
    public string Index()
    {
        return "Product: Hello world! :)";
    }
}

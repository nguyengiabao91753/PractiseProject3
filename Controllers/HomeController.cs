using Microsoft.AspNetCore.Mvc;

namespace WebApplicationBYD.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

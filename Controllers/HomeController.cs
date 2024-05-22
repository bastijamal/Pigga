using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace PiggaProject.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }


}


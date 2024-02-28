using Microsoft.AspNetCore.Mvc;
using Mission08_Team0113.Models;
using System.Diagnostics;

namespace Mission08_Team0113.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTask()
        {
            return View();
        }

        public IActionResult Quadrant()
        {
            return View();
        }
    }
}

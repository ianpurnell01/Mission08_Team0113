using Microsoft.AspNetCore.Mvc;
using Mission08_Team0113.Models;
using System.Diagnostics;
using System.Security.AccessControl;

namespace Mission08_Team0113.Controllers
{
    public class HomeController : Controller
    {

        private IHabitsRepository _repo;

        public HomeController(IHabitsRepository other)
        {
            _repo = other;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories.OrderBy(x => x.CategoryName).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(Table t)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTable(t);
            }
            return View("Confirmation");
        }

        public IActionResult Quadrant()
        {
            //ViewBag.TaskName = _repo.Tables.FirstOrDefault(x => x.Task == "Brush Teeth");
            return View();
        }
    }
}

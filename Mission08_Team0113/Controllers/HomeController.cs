using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Quadrant1 = _repo.Tables
                .Where(x => x.Quadrant == 1)
                .ToList();
            ViewBag.Quadrant2 = _repo.Tables
                .Where(x => x.Quadrant == 2)
                .ToList();
            ViewBag.Quadrant3 = _repo.Tables
                .Where(x => x.Quadrant == 3)
                .ToList();
            ViewBag.Quadrant4 = _repo.Tables
                .Where(x => x.Quadrant == 4)
                .ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taskToEdit = _repo.Tables
                .Single(x => x.TaskId == id);
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Quadrant", taskToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Table updatedinfo)
        {
            _repo.EditTable(updatedinfo);
            return RedirectToAction("Quadrant");
        }

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var recordToDelete = _repo.Tables
        //        .Single(x => x.TaskId == id);

        //    return View(Quadrant);
        //}

        //[HttpPost]
        public IActionResult Delete(Table record)
        {
            _repo.DeleteTable(record);
            return RedirectToAction("Quadrant");
        }
    }
}

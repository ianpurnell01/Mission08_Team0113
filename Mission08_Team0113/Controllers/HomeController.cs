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
            ViewBag.TaskNames = _repo.Tables.FirstOrDefault(x => x.TaskName == "Brush Teeth");
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

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(NewMovie record)
        {
            _context.Movies.Remove(record);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}

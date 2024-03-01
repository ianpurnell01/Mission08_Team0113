using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team0113.Models;
using System.Diagnostics;
using System.Security.AccessControl;

namespace Mission08_Team0113.Controllers
{
    public class HomeController : Controller
    {
        //use repo, not context
        private IHabitsRepository _repo;

        public HomeController(IHabitsRepository other)
        {
            _repo = other;
        }

        //load homepage
        public IActionResult Index()
        {
            return View();
        }

        //adding a task
        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories.OrderBy(x => x.CategoryName).ToList();
            return View();
        }

        //submit add form
        [HttpPost]
        public IActionResult AddTask(Table t)
        {
            _repo.AddTable(t);
            return View("Confirmation");
        }

        //confirmation page after adding the task for the first time
        public IActionResult Confirmation()
        {
            return View();
        }

        //load the Quadrant view
        public IActionResult Quadrant()
        {
            //only pass in incomplete tasks
            ViewBag.Quadrant1 = _repo.Tables
                .Where(x => x.Quadrant == 1 && x.Completed == 0)
                .ToList();
            ViewBag.Quadrant2 = _repo.Tables
                .Where(x => x.Quadrant == 2 && x.Completed == 0)
                .ToList();
            ViewBag.Quadrant3 = _repo.Tables
                .Where(x => x.Quadrant == 3 && x.Completed == 0)
                .ToList();
            ViewBag.Quadrant4 = _repo.Tables
                .Where(x => x.Quadrant == 4 && x.Completed == 0)
                .ToList();
            return View();
        }

        // initialize edit view
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taskToEdit = _repo.Tables.FirstOrDefault(x => x.TaskId == id);
            if (taskToEdit != null)
            {
                ViewBag.Categories = _repo.Categories.OrderBy(x => x.CategoryName).ToList();
                return View("AddTask", taskToEdit);
            }
            return RedirectToAction("Quadrant");
        }

        //submit edit form
        [HttpPost]
        public IActionResult Edit(Table updatedTask)
        {
            _repo.EditTable(updatedTask);
            return RedirectToAction("Quadrant");
        }

        //delete record
        public IActionResult Delete(int id)
        {
            var delTask = _repo.Tables.FirstOrDefault(x => x.TaskId == id);
            if (delTask != null)
            {
                _repo.DeleteTable(delTask);
            }
            return RedirectToAction("Quadrant");
        }

    }
}

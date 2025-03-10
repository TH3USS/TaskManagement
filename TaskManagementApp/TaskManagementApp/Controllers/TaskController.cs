﻿using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Models;

namespace TaskManagementApp.Controllers
{
    public class TasksController : Controller
    {
        private static List<TaskItem> tasks = new List<TaskItem>();

        // GET: Tasks
        public IActionResult Index()
        {
            return View(tasks);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,Description")] TaskItem task)
        {
            if (ModelState.IsValid)
            {
                task.Id = tasks.Count + 1;
                task.IsCompleted = false;
                tasks.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // Other actions like Edit, Delete, etc.
    }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var starredList = Github.GetHub();
            return View(starredList);
        }
    }
}

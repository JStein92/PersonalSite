﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalSite.Models;
namespace PersonalSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            

            return View();
        }

        public IActionResult Projects()
        {
            var starredProjects = Project.GetProjects();
            return View(starredProjects);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

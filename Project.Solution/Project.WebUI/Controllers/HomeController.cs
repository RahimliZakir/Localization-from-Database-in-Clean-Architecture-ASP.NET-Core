﻿using Microsoft.AspNetCore.Mvc;

namespace Project.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Index(int? id)
        {
            ViewData["id"] = id;
            return View("RegisterIndex");
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                return View(register);
            }
            else
            {
                ViewData["errorMsg"] = "Your form had errors. Please make sure all the fields are filled out and everything is correct.";
                return View("RegisterIndex", register);
            }
        }
    }
}
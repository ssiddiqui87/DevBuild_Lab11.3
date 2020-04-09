using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoffeeShop.Controllers
{
    public class AdminController : Controller
    {
        IConfiguration ConfigRoot;
        DAL dal;

        public AdminController(IConfiguration config)
        {
            ConfigRoot = config;
            dal = new DAL(ConfigRoot.GetConnectionString("CoffeeShopDB"));
        }

        public IActionResult Index()
        {
            ViewData["Products"] = dal.GetProductsAll();

            return View("AdminIndex");
        }

        [HttpPost]
        public IActionResult Add(Products prod)
        {

            int result = dal.CreateProduct(prod);
            if (result == 1)
            {
                TempData["UserMsg"] = "Item successfully added";
            }
            else
            {
                TempData["UserMsg"] = "Item not added";
            }

            return RedirectToAction("Index");
        }

        public IActionResult AddForm()
        {
            Products prod = new Products();

            return View(prod);
        }

        public IActionResult Delete(int id)
        {
            int result = dal.DeleteProductById(id);

            if (result == 1)
            {
                TempData["UserMsg"] = "Item successfully deleted";
            }
            else
            {
                TempData["UserMsg"] = "Item for deletion not found";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Products prod = dal.GetProductById(id);

            if (prod == null)
            {
                return View("NoSuchItem");
            }
            else
            {
                return View(prod);
            }
        }

        [HttpPost]
        public IActionResult Edit(Products prod)
        {
            int result = dal.UpdateProductById(prod);

            if (result == 1)
            {
                TempData["UserMsg"] = "Item successfully updated";
            }
            else
            {
                TempData["UserMsg"] = "Item not updated";
            }

            return RedirectToAction("Index");
        }
    }
}
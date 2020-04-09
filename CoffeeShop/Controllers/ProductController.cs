using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using CoffeeShop.Models;

namespace CoffeeShop.Controllers
{
    public class ProductController : Controller
    {

        IConfiguration ConfigRoot;
        DAL dal;

        public ProductController(IConfiguration config)
        {
            ConfigRoot = config;
            dal = new DAL(ConfigRoot.GetConnectionString("CoffeeShopDB"));
        }
        public IActionResult Index()
        {

            ViewData["Products"] = dal.GetProductsAll();
            return View("ProductsIndex");
        }
    }
}
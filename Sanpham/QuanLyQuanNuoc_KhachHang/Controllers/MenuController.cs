using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyQuanNuoc.Models;

namespace QuanLyQuanNuoc_KhachHang.Controllers
{
    
    public class MenuController : Controller
    {
        private CNPM_QLNGKEntities1 db = new CNPM_QLNGKEntities1();
        // GET: Menu
        public ActionResult Index()
        {
            ViewBag.FoodCategories = db.FoodCategories.ToList();
            ViewBag.Food = db.Foods.ToList();
            ViewBag.Drink = db.Drinks.ToList();
            ViewBag.DrinkCategories = db.DrinkCategories.ToList();

            return View();
        }
    }
}
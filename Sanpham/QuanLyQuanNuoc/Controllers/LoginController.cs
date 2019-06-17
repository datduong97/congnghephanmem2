using QuanLyQuanNuoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyQuanNuoc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private CNPM_QLNGKEntities1 db = new CNPM_QLNGKEntities1();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account acc)
        {
            var lg = (from item in db.Accounts
                      where item.Username == acc.Username && item.Password == acc.Password
                      select new
                      {
                          item.Username,
                          item.DisplayName
                      }).ToList();
            if (lg.FirstOrDefault() != null)
            {
                Session["Username"] = lg.FirstOrDefault().Username;
                Session["Displayname"] = lg.FirstOrDefault().DisplayName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Username hoăc mật khẩu không đúng");
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");
        }
    }
}
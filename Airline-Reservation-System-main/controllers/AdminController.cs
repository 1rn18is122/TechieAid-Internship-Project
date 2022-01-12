using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARS.Models;

namespace ARS.Controllers
{
    public class AdminController : Controller
    {
        ContextCS c = new ContextCS();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            if (Session["u"] != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminLogin l)
        {
            var x = c.AdminLogins.Where(a => a.AdName == l.AdName && a.Password == l.Password).ToList();
            if ( x!=null )
            {
                Session["u"] = l.AdName;
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.m = "Wrong User id or Password";
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
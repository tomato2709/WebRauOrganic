using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRauTNT.Models;

namespace WebRauTNT.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext data = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            return View();
        }
        public ActionResult Error401()
        {
            return View();
        }
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult Error500()
        {
            return View();
        }
        public ActionResult Charts()
        {
            return View();
        }
        public ActionResult LayoutSideNavLight()
        {
            return View();
        }
        public ActionResult LayoutStatic()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Password()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Tables()
        {
            return View();
        }
        public bool AuthAdmin()
        {
            var user = data.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (user == null)
                return false;
            var userExist = user.Roles.FirstOrDefault(r => r.UserId == user.Id);
            if (userExist == null)
                return false;
            if (userExist.RoleId != "1")
                return false;
            return true;
        }
    }
}
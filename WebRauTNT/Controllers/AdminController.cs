using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebRauTNT.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
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
    }
}
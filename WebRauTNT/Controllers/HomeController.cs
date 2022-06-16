using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebRauTNT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
namespace WebRauTNT.Controllers
{
    public class HomeController : Controller
    {
        private WebRauTNTContext db = new WebRauTNTContext();

        public ActionResult Index()
        {
            var sanpham = db.SanPham.Include(s => s.LoaiSP);
            return View(sanpham.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogDetails()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitContact(LienHe LienHe)
        {
            LienHe.FullName = Request.Form["Fullname"];
            LienHe.Email = Request.Form["Email"];
            LienHe.Phone = Convert.ToInt32(Request.Form["Phone"]);
            LienHe.Title = Request.Form["Title"];
            LienHe.Detail = Request.Form["Detail"];
            LienHe.Status = 1;
            LienHe.Created_at = DateTime.Now;
            LienHe.Updated_at = DateTime.Now;
            LienHe.Updated_by = 1;
            db.LienHe.Add(LienHe);
            db.SaveChanges();
            return RedirectToAction("Contact", "Home");
        }
        public ActionResult ShopDetails()
        {
            return View();
        }
        public ActionResult ShopGrid()
        {
            return View();
        }
        public ActionResult ShopCart()
        {
            return View();
        }
    }
}
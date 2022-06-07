using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRauTNT.Models;

namespace WebRauTNT.Controllers
{
    public class LienHeController : Controller
    {
        private WebRauTNTContext db = new WebRauTNTContext();
        private ApplicationDbContext data = new ApplicationDbContext();
        // GET: LienHe
        public ActionResult Index(int? page, string searchString)
        {
            if (!AuthAdmin())
                return RedirectToAction("Error401", "Admin");
            ViewBag.Keyword = searchString;
            int pageSize = 10;
            int pageNum = page ?? 1;
            return View(LienHe.getAll(searchString).ToPagedList(pageNum, pageSize));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
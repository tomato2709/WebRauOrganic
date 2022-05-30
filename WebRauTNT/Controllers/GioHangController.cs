using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRauTNT.Models;

namespace WebRauTNT.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
/*        public ActionResult Index()
        {
            return View();
        }*/

        // Tạo đối tượng để quản lý data
        WebRauTNTContext db = new WebRauTNTContext();

        // GET: GioHang
        public List<Giohang> LayGioHang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            // NẾU TỒN TẠI, GÁN VÀO GIỎ HÀNG
            if (lstGiohang == null)
            {
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }

        // Thêm giỏ hàng
        public ActionResult ThemGiohang(int iIdSanPham, string strURL)
        {
            // LẤY SESSION 
            List<Giohang> lstGiohang = LayGioHang();
            // Kiểm tra sản phẩm đã cho vào giỏ hay chưa
            Giohang sanpham = lstGiohang.Find(n => n.iIdSanPham == iIdSanPham);
            if (sanpham == null)
            {
                sanpham = new Giohang(iIdSanPham);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }

        }

        // Tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongSoLuong = lstGiohang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }

        //TÍNH TỔNG TIỀN
        private double TongTien()
        {
            double iTongTien = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTongTien = lstGiohang.Sum(n => n.dThanhTien);
            }
            return iTongTien;
        }

        //TẠO GIỎ HÀNG
        public ActionResult GioHang()
        {
            List<Giohang> lstGiohang = LayGioHang();
/*            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
*/
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGiohang);

        }

        public ActionResult GiohangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }

        // xóa giỏ hàng
        public ActionResult XoaGiohang(int iIdSanPham)
        {

            List<Giohang> lstGiohang = LayGioHang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.iIdSanPham == iIdSanPham);
            if (lstGiohang != null)
            {
                lstGiohang.RemoveAll(n => n.iIdSanPham == iIdSanPham);
                return RedirectToAction("Giohang");
            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Giohang");
        }

        // Xóa tất cả giỏ hàng
        public ActionResult XoaTatCaGioHang()
        {
            List<Giohang> lstGioHang = LayGioHang();
            lstGioHang.Clear();
            return RedirectToAction("GioHang");
        }

        // CẬP NHẬT giỏ hàng
        public ActionResult CapNhatGiohang(int iIdSanPham, FormCollection f)
        {
            List<Giohang> lstGiohang = LayGioHang();
            // kiểm tra sp đã cho vào giỏ chưa
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.iIdSanPham == iIdSanPham);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("Giohang");
        }

        //Dăt hàng
        [HttpGet]
        public ActionResult Dathang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("Login", "Account");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //lấy giỏ hàng
            List<Giohang> lstGiohang = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(lstGiohang);
        }

        public ActionResult Dathang(FormCollection collection)
        {
            DonHang dh = new DonHang();
            Models.LinQ.AspNetUser kh = (Models.LinQ.AspNetUser)Session["TaiKhoan"];
            //AspNetUsers kh = (AspNetUsers)Session["TaiKhoan"];

            List<Giohang> gh = LayGioHang();
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]);
            dh.MaKH = kh.Id;
            dh.NgayDat = DateTime.Now;
            dh.NgayGiao = DateTime.Parse(ngaygiao);
            dh.TrangThaiGiaoHang = false;
            dh.TongTien = TongTien();

            db.DonHang.Add(dh);
            db.SaveChanges();
            foreach (var item in gh)
            {
                ChiTietDonHang ctdh = new ChiTietDonHang();
                ctdh.MaDH = dh.MaDH;
                ctdh.MaSP = item.iIdSanPham;
                ctdh.Soluong = item.iSoLuong;
                ctdh.Gia = item.dThanhTien;
                SanPham sanPham = db.SanPham.Single(n => n.MaSP == item.iIdSanPham);
                sanPham.SoLuong -= item.iSoLuong;
                db.SaveChanges();
                db.ChiTietDonHang.Add(ctdh);
                db.SaveChanges();
            }
            Session["Giohang"] = null;
            return RedirectToAction("XacNhanDonHang", "GioHang");
        }

        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRauTNT.Models
{
    public class Giohang
    { 
    WebRauTNTContext db = new WebRauTNTContext();


        public int iIdSanPham { set; get; }
            public string sTenSanPham { set; get; }
            public string sHinh { set; get; }
            public double dGia { set; get; }
            public int iSoLuong { set; get; }
            public double dThanhTien
            {
                get { return iSoLuong * dGia; }
            }
            public Giohang(int Id)
            {
                iIdSanPham = Id;
                SanPham sp = db.SanPham.Single(n => n.MaSP == iIdSanPham);
                sTenSanPham = sp.Ten;
                sHinh = sp.Hinh;
                dGia = double.Parse(sp.Gia.ToString());
                iSoLuong = 1;
            }

        }
    }
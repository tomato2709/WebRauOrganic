using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRauTNT.Models
{
    public class DonHangViewModel
    {
        public LinQ.DonHang DonHang { get; set; }
        public List<LinQ.ChiTietDonHang> CTDH { get; set; }
    }
}
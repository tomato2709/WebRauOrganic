using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRauTNT.Models
{
    public class DoanhThuViewModel
    {
        public PagedList.PagedList<DateTime> ThangNam { get; set; }
        public List<Double> Result { get; set; }
        public double Total { get; set; }

        public int SumLoaiSP { get; set; }

        public int SumSP { get; set; }

        public int SumDH { get; set; }

        public int SumKH { get; set; }
    }
}
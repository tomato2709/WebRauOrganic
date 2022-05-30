namespace WebRauTNT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuan = new HashSet<BinhLuan>();
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        [Key]
        public int MaSP { get; set; }

        public int MaLoai { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public double? Gia { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(10)]
        public string DonVi { get; set; }
        [DisplayFormat(DataFormatString = "{0:0,0}")]
        public double? GiamGia { get; set; }

        [StringLength(255)]
        public string Hinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }

        public static List<SanPham> getAll(string searchKey)
        {
            WebRauTNTContext db = new WebRauTNTContext();
            searchKey = searchKey + "";
            return db.SanPham.Where(p => p.Ten.Contains(searchKey) && p.SoLuong > 0).ToList();
        }
       
    }
}

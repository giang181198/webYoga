namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDonHang")]
    public partial class tblDonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDonHang()
        {
            tblChiTietDonHangs = new HashSet<tblChiTietDonHang>();
        }

        [Key]
        public int IdDonHang { get; set; }

        public int? IdKhachHang { get; set; }

        public double? TongTien { get; set; }

        [StringLength(30)]
        public string Payment { get; set; }

        public DateTime? NgayDatHang { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public int? SoDienThoaiNhan { get; set; }

        [StringLength(30)]
        public string TenNguoiNhan { get; set; }

        [StringLength(30)]
        public string DiaChiNhan { get; set; }

        [StringLength(30)]
        public string EmailNhan { get; set; }

        [StringLength(30)]
        public string TrangThaiDonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChiTietDonHang> tblChiTietDonHangs { get; set; }

        public virtual tblKhachHang tblKhachHang { get; set; }
    }
}

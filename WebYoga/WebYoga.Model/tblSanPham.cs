namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSanPham")]
    public partial class tblSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSanPham()
        {
            tblChiTietDonHangs = new HashSet<tblChiTietDonHang>();
        }

        [Key]
        public int IdSanPham { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSanPham { get; set; }

        public int? IdHangSanXuat { get; set; }

        public int? IdChatLieu { get; set; }

        public int? IdTheLoai { get; set; }

        public int? IdMauSac { get; set; }

        public int? IdXuatXu { get; set; }

        public int? IdNamSanXuat { get; set; }

        public int? IdTrangThai { get; set; }

        public double? SoLuong { get; set; }

        public double? GiaBan { get; set; }

        public double? GiaKhuyenMai { get; set; }

        [StringLength(50)]
        public string HinhAnh { get; set; }

        [Column(TypeName = "ntext")]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string KichThuoc { get; set; }

        [StringLength(50)]
        public string TrongLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThemSanPham { get; set; }

        public double? SoLuongBan { get; set; }

        public virtual tblChatLieu tblChatLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChiTietDonHang> tblChiTietDonHangs { get; set; }

        public virtual tblHangSanXuat tblHangSanXuat { get; set; }

        public virtual tblMauSac tblMauSac { get; set; }

        public virtual tblNamSanXuat tblNamSanXuat { get; set; }

        public virtual tblTheLoai tblTheLoai { get; set; }

        public virtual tblTrangThai tblTrangThai { get; set; }

        public virtual tblXuatXu tblXuatXu { get; set; }
    }
}

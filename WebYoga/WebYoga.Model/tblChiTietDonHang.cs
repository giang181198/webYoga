namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChiTietDonHang")]
    public partial class tblChiTietDonHang
    {
        [Key]
        public int IdChiTietDonHang { get; set; }

        public int? IdDonHang { get; set; }

        public int? IdSanPham { get; set; }

        public int? SoLuong { get; set; }

        public virtual tblDonHang tblDonHang { get; set; }

        public virtual tblSanPham tblSanPham { get; set; }
    }
}

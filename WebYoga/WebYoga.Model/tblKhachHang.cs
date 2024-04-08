namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKhachHang")]
    public partial class tblKhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblKhachHang()
        {
            tblDonHangs = new HashSet<tblDonHang>();
        }

        [Key]
        public int IdKhachHang { get; set; }

        [Required]
        [StringLength(30)]
        public string TenKhachHang { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(11)]
        public string DienThoai { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(30)]
        public string PassWords { get; set; }

        [StringLength(100)]
        public string Avatar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDonHang> tblDonHangs { get; set; }
    }
}

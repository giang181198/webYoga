namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHangSanXuat")]
    public partial class tblHangSanXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblHangSanXuat()
        {
            tblSanPhams = new HashSet<tblSanPham>();
        }

        [Key]
        public int IdHangSanXuat { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHangSanXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSanPham> tblSanPhams { get; set; }
    }
}

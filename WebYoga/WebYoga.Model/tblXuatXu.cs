namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblXuatXu")]
    public partial class tblXuatXu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblXuatXu()
        {
            tblSanPhams = new HashSet<tblSanPham>();
        }

        [Key]
        public int IdXuatXu { get; set; }

        [Required]
        [StringLength(50)]
        public string TenXuatXu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSanPham> tblSanPhams { get; set; }
    }
}

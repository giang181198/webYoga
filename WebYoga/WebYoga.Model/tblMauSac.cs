namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMauSac")]
    public partial class tblMauSac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMauSac()
        {
            tblSanPhams = new HashSet<tblSanPham>();
        }

        [Key]
        public int IdMauSac { get; set; }

        [Required]
        [StringLength(50)]
        public string TenMauSac { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSanPham> tblSanPhams { get; set; }
    }
}

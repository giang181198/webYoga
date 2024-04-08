namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTheLoai")]
    public partial class tblTheLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTheLoai()
        {
            tblSanPhams = new HashSet<tblSanPham>();
        }

        [Key]
        public int IdTheLoai { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTheLoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSanPham> tblSanPhams { get; set; }
    }
}

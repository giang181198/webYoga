namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChatLieu")]
    public partial class tblChatLieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblChatLieu()
        {
            tblSanPhams = new HashSet<tblSanPham>();
        }

        [Key]
        public int IdChatLieu { get; set; }

        [Required]
        [StringLength(50)]
        public string TenChatLieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSanPham> tblSanPhams { get; set; }
    }
}

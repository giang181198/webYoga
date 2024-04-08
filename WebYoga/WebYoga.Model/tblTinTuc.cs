namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTinTuc")]
    public partial class tblTinTuc
    {
        [Key]
        public int IdTinTuc { get; set; }

        [StringLength(100)]
        public string TieuDe { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }
    }
}

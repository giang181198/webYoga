namespace WebYoga.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string PassWords { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(11)]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Avatar { get; set; }
    }
}

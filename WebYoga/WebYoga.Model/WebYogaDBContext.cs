using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebYoga.Model
{
    public partial class WebYogaDBContext : DbContext
    {
        public WebYogaDBContext()
            : base("name=WebYogaDBContext")
        {
        }

        public virtual DbSet<tblChatLieu> tblChatLieux { get; set; }
        public virtual DbSet<tblChiTietDonHang> tblChiTietDonHangs { get; set; }
        public virtual DbSet<tblDonHang> tblDonHangs { get; set; }
        public virtual DbSet<tblHangSanXuat> tblHangSanXuats { get; set; }
        public virtual DbSet<tblKhachHang> tblKhachHangs { get; set; }
        public virtual DbSet<tblMauSac> tblMauSacs { get; set; }
        public virtual DbSet<tblNamSanXuat> tblNamSanXuats { get; set; }
        public virtual DbSet<tblSanPham> tblSanPhams { get; set; }
        public virtual DbSet<tblTheLoai> tblTheLoais { get; set; }
        public virtual DbSet<tblTinTuc> tblTinTucs { get; set; }
        public virtual DbSet<tblTrangThai> tblTrangThais { get; set; }
        public virtual DbSet<tblXuatXu> tblXuatXus { get; set; }
        public virtual DbSet<USER> USERs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblKhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tblKhachHang>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<tblKhachHang>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblKhachHang>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<tblTinTuc>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);
        }
    }
}

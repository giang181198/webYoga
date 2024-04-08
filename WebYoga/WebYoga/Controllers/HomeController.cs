using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Controllers
{
    public class HomeController : Controller
    {
        WebYogaDBContext db = new WebYogaDBContext();
        tblKhachHangRepository khachhangRepo = new tblKhachHangRepository();

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            tblKhachHang khachhang = khachhangRepo.GetAll().SingleOrDefault(x => x.UserName == UserName && x.PassWords == Password);
            if (khachhang != null)
            {
                Session["IdKhachhang"] = khachhang.IdKhachHang;
                Session["TenDangNhap"] = khachhang.UserName;
                Session["TenKhachhang"] = khachhang.TenKhachHang;
                Session["HinhDaiDien"] = khachhang.Avatar;
                Session["Email"] = khachhang.Email;
                Session["DiaChi"] = khachhang.DiaChi;
                Session["SoDienThoai"] = khachhang.DienThoai;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Bạn nhập sai, vui lòng nhập lại";
            return View(khachhang);
        }
        public ActionResult Index()
        {
            ViewBag.SanPhamMoi = db.tblSanPhams.OrderByDescending(x=>x.NgayThemSanPham).Take(8).ToList();
            ViewBag.SanPhamBanChay = db.tblSanPhams.OrderByDescending(x => x.SoLuongBan).Take(8).ToList();
            return View();
        }
        public ActionResult Details(int id)
        {
            ViewBag.SanPhamMoi = db.tblSanPhams.OrderByDescending(x => x.NgayThemSanPham).Take(8).ToList();
            ViewBag.SanPhamBanChay = db.tblSanPhams.OrderByDescending(x => x.SoLuongBan).Take(8).ToList();
            //Tìm sách có mã sách = id
            tblSanPham sp = db.tblSanPhams.SingleOrDefault(x => x.IdSanPham == id);
            //Nếu không tìm thấy
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult SanPham()
        {
            ViewBag.SanPham = db.tblSanPhams.OrderByDescending(x => x.NgayThemSanPham).Take(1110).ToList();

            return View();
        }
        public ActionResult QuanAo()
        {
            ViewBag.QuanAo = db.tblSanPhams.Where(x => x.IdTheLoai==1).Take(1100).ToList();

            return View();
        }
        public ActionResult Giay()
        {

            ViewBag.Giay = db.tblSanPhams.Where(x => x.IdTheLoai == 6).Take(1100).ToList();

            return View();
        }
        public ActionResult TuiDung()
        {

            ViewBag.TuiDung = db.tblSanPhams.Where(x => x.IdTheLoai == 3).Take(1100).ToList();

            return View();
        }
        public ActionResult Ta()
        {
            ViewBag.Ta = db.tblSanPhams.Where(x => x.IdTheLoai == 2).Take(1100).ToList();


            return View();
        }
        public ActionResult DoTap()
        {
            ViewBag.DoTap = db.tblSanPhams.Where(x => x.IdTheLoai == 4).Take(1100).ToList();


            return View();
        }
        public ActionResult Tham()
        {
            ViewBag.Tham = db.tblSanPhams.Where(x => x.IdTheLoai == 5).Take(1100).ToList();


            return View();
        }
        
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
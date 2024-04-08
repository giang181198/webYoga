using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        USERsRepository UserRepo = new USERsRepository();
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            USER user = UserRepo.GetAll().SingleOrDefault(x => x.UserName == UserName && x.PassWords == Password);
            if(user != null)
            {
                Session["IdNguoiDung"] = user.UserId;
                Session["TenDangNhap"] = user.UserName;
                Session["TenNguoiDung"] = user.HoTen;
                Session["HinhDaiDien"] = user.Avatar;
                Session["Email"] = user.Email;
                Session["DiaChi"] = user.DiaChi;
                Session["SoDienThoai"] = user.SoDienThoai;
                return View("~/Areas/Administrator/Views/Home/Index.cshtml");
            }
            ViewBag.error = "Bạn nhập sai, vui lòng nhập lại";
            return View(user);
        }
    }
}
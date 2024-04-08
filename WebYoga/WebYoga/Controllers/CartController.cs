using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Models;
using WebYoga.Model;
using System.Web.Script.Serialization;
using WebYoga.Repository;
using System.Data;

namespace WebYoga.Controllers
{
    public class CartController : Controller
    {
        WebYogaDBContext db = new WebYogaDBContext();
        tblDonHangRepository donhangRepo = new tblDonHangRepository();
        tblChiTietDonHangRepository chitietdonhangRepo = new tblChiTietDonHangRepository();
        private const string CartSession = "CartSession";
        // GET: Cart

        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<Cart>();
            if(cart != null)
            {
                list = (List<Cart>)cart;
            }    
            return View(list);
        }
        
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CartSession];
            var list = new List<Cart>();
            if (cart != null)
            {
                list = (List<Cart>)cart;
            }
            return PartialView(list);
        }

        public ActionResult AddItem(int IdSanPham, int SoLuong)
        {
            tblSanPham sp = db.tblSanPhams.SingleOrDefault(x => x.IdSanPham == IdSanPham);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<Cart>)cart;
                if(list.Exists(x=>x.SanPham.IdSanPham == IdSanPham))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.IdSanPham == IdSanPham)
                        {
                            item.SoLuong += SoLuong;
                        }
                    }
                }
                else
                {
                    //Tạo mới đối tượng card 
                    var item = new Cart();
                    item.SanPham = sp;
                    item.SoLuong = SoLuong;
                    list.Add(item);
                }
                 
            }
            else
            {
                //Tạo mới đối tượng card 
                var item = new Cart();
                item.SanPham = sp;
                item.SoLuong = SoLuong;
                var list = new List<Cart>();
                list.Add(item);
                //Gán vào Session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<Cart>>(cartModel);
            var sessionCart = (List<Cart>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.SanPham.IdSanPham == item.SanPham.IdSanPham);
                if (jsonItem != null)
                {
                    item.SoLuong = jsonItem.SoLuong;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }


        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<Cart>)Session[CartSession];
            sessionCart.RemoveAll(x => x.SanPham.IdSanPham == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpGet]
        public ActionResult ThanhToan()
        {
            var cart = Session[CartSession];
            var list = new List<Cart>();
            if (cart != null)
            {
                list = (List<Cart>)cart;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult ThanhToan(string TenNguoiNhan, int SoDienThoaiNhan, string DiaChiNhan, string EmailNhan, string Note, tblDonHang donhang, tblChiTietDonHang chitietdonhang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    donhang.TenNguoiNhan = TenNguoiNhan;
                    donhang.SoDienThoaiNhan = SoDienThoaiNhan;
                    donhang.DiaChiNhan = DiaChiNhan;
                    donhang.EmailNhan = EmailNhan;
                    donhang.Note = Note;
                    donhang.TrangThaiDonHang = "Đơn mới khởi tạo";
                    donhang.NgayDatHang = DateTime.Now;
                    donhang.IdKhachHang = Convert.ToInt32(Session["IdKhachHang"]);
                    donhangRepo.Create(donhang);
                    var iddh = donhang.IdDonHang;

                    var cart = (List<Cart>)Session[CartSession];
                    int tongtien = 0;
                    foreach (var item in cart)
                    {
                        chitietdonhang.IdSanPham = item.SanPham.IdSanPham;
                        chitietdonhang.IdDonHang = iddh;
                        chitietdonhang.SoLuong = item.SoLuong;
                        chitietdonhangRepo.Create(chitietdonhang);
                        tongtien += (Convert.ToInt32(item.SanPham.GiaKhuyenMai) * item.SoLuong);
                    }

                    donhang.TongTien = tongtien;
                    donhangRepo.Update(donhang);
                    return RedirectToAction("/DatHangThanhCong");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View();
        }

        public ActionResult DatHangThanhCong()
        {
            return View();
        }
    }
}
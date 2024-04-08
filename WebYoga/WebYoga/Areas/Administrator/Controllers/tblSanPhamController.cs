using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblSanPhamController : Controller
    {
        // GET: Administrator/tblSanPham
        tblSanPhamRepository SanPhamRepo = new tblSanPhamRepository();
        tblHangSanXuatRepository hangsanxuatRepo = new tblHangSanXuatRepository();
        tblTheLoaiRepository theloaiRepo = new tblTheLoaiRepository();
        tblMauSacRepository mausacRepo = new tblMauSacRepository();
        tblXuatXuRepository xuatxuRepo = new tblXuatXuRepository();
        tblNamSanXuatRepository namsanxuatRepo = new tblNamSanXuatRepository();
        tblTrangThaiRepository trangthaiRepo = new tblTrangThaiRepository();
        tblChatLieuRepository chatlieuRepo = new tblChatLieuRepository();

        public ActionResult Index()
        {
            return View(SanPhamRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdHangSanXuat = new SelectList(hangsanxuatRepo.GetAll(), "IdHangSanXuat", "TenHangSanXuat");
            ViewBag.IdTheLoai = new SelectList(theloaiRepo.GetAll(), "IdTheLoai", "TenTheLoai");
            ViewBag.IdMauSac = new SelectList(mausacRepo.GetAll(), "IdMauSac", "TenMauSac");
            ViewBag.IdXuatXu = new SelectList(xuatxuRepo.GetAll(), "IdXuatXu", "TenXuatXu");
            ViewBag.IdNamSanXuat = new SelectList(namsanxuatRepo.GetAll(), "IdNamSanXuat", "TenNamSanXuat");
            ViewBag.IdTrangThai = new SelectList(trangthaiRepo.GetAll(), "IdTrangThai", "TenTrangThai");
            ViewBag.IdChatLieu = new SelectList(chatlieuRepo.GetAll(), "IdChatLieu", "TenChatLieu");

            return View();
        }
        [HttpPost]
        public ActionResult Create(tblSanPham c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    c.NgayThemSanPham = DateTime.Now;
                    SanPhamRepo.Create(c);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(c);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.IdHangSanXuat = new SelectList(hangsanxuatRepo.GetAll(), "IdHangSanXuat", "TenHangSanXuat");
            ViewBag.IdTheLoai = new SelectList(theloaiRepo.GetAll(), "IdTheLoai", "TenTheLoai");
            ViewBag.IdMauSac = new SelectList(mausacRepo.GetAll(), "IdMauSac", "TenMauSac");
            ViewBag.IdXuatXu = new SelectList(xuatxuRepo.GetAll(), "IdXuatXu", "TenXuatXu");
            ViewBag.IdNamSanXuat = new SelectList(namsanxuatRepo.GetAll(), "IdNamSanXuat", "TenNamSanXuat");
            ViewBag.IdTrangThai = new SelectList(trangthaiRepo.GetAll(), "IdTrangThai", "TenTrangThai");
            ViewBag.IdChatLieu = new SelectList(chatlieuRepo.GetAll(), "IdChatLieu", "TenChatLieu");
            tblSanPham c = SanPhamRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblSanPham c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SanPhamRepo.Update(c);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Chỉnh sửa thất bại. Vui lòng kiểm tra lại!");
            }
            return View(c);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                SanPhamRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
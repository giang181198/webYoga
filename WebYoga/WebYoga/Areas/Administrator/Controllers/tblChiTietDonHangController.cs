using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblChiTietDonHangController : Controller
    {
        // GET: Administrator/tblChiTietDonHang
        tblChiTietDonHangRepository chitietdonhangRepo = new tblChiTietDonHangRepository();
        tblDonHangRepository donhangRepo = new tblDonHangRepository();
        tblSanPhamRepository SanPhamRepo = new tblSanPhamRepository();
        public ActionResult Index()
        {
            return View(chitietdonhangRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdDonHang = new SelectList(donhangRepo.GetAll(), "IdDonHang", "IdDonHang");
            ViewBag.IdSanPham = new SelectList(SanPhamRepo.GetAll(), "IdSanPham", "TenSanPham");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblChiTietDonHang c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chitietdonhangRepo.Create(c);
                    
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
            ViewBag.IdDonHang = new SelectList(donhangRepo.GetAll(), "IdDonHang", "IdDonHang");
            ViewBag.IdSanPham = new SelectList(SanPhamRepo.GetAll(), "IdSanPham", "TenSanPham");
            tblChiTietDonHang c = chitietdonhangRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblChiTietDonHang c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chitietdonhangRepo.Update(c);
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
                chitietdonhangRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            
            return RedirectToAction("Index");
        }
    }
}
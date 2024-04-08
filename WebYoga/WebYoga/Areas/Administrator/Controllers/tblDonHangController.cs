using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblDonHangController : Controller
    {
        // GET: Administrator/tblDonHang
        tblDonHangRepository donhangRepo = new tblDonHangRepository();
        tblKhachHangRepository khachhangRepo = new tblKhachHangRepository();
        tblChiTietDonHangRepository chitietdonhangRepo = new tblChiTietDonHangRepository();
        WebYogaDBContext db = new WebYogaDBContext();
        public ActionResult Index()
        {
            return View(donhangRepo.GetAll());
        }

        public ActionResult ChiTietDonHang(int id)
        {
            tblDonHang sp = db.tblDonHangs.SingleOrDefault(x => x.IdDonHang == id);
            ViewBag.ChiTietDonHang = db.tblChiTietDonHangs.Where(x=>x.IdDonHang==id).Take(1000).ToList();
            return View(sp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdKhachHang = new SelectList(khachhangRepo.GetAll(), "IdKhachHang", "TenKhachHang");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblDonHang c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    donhangRepo.Create(c);

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
            ViewBag.IdKhachHang = new SelectList(khachhangRepo.GetAll(), "IdKhachHang", "TenKhachHang");
            tblDonHang c = donhangRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblDonHang c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    donhangRepo.Update(c);
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
                donhangRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
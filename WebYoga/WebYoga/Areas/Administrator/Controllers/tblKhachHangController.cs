using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblKhachHangController : Controller
    {
        // GET: Administrator/tblKhachHang
        tblKhachHangRepository khachhangRepo = new tblKhachHangRepository();
        public ActionResult Index()
        {
            return View(khachhangRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblKhachHang c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    khachhangRepo.Create(c);

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
            tblKhachHang c = khachhangRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblKhachHang c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    khachhangRepo.Update(c);
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
                khachhangRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblHangSanXuatController : Controller
    {
        // GET: Administrator/tblHangSanXuat
        tblHangSanXuatRepository hangsanxuatRepo = new tblHangSanXuatRepository();
        public ActionResult Index()
        {
            return View(hangsanxuatRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblHangSanXuat c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    hangsanxuatRepo.Create(c);

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
            tblHangSanXuat c = hangsanxuatRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblHangSanXuat c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    hangsanxuatRepo.Update(c);
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
                hangsanxuatRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
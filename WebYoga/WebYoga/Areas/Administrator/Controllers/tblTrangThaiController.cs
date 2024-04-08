using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblTrangThaiController : Controller
    {
        // GET: Administrator/tblTrangThai
        tblTrangThaiRepository trangthaiRepo = new tblTrangThaiRepository();
        public ActionResult Index()
        {
            return View(trangthaiRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblTrangThai c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    trangthaiRepo.Create(c);

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
            tblTrangThai c = trangthaiRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblTrangThai c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    trangthaiRepo.Update(c);
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
                trangthaiRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
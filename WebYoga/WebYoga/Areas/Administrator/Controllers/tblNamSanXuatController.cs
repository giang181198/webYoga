using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblNamSanXuatController : Controller
    {
        // GET: Administrator/tblNamSanXuat
        tblNamSanXuatRepository namsanxuatRepo = new tblNamSanXuatRepository();
        public ActionResult Index()
        {
            return View(namsanxuatRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblNamSanXuat c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    namsanxuatRepo.Create(c);

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
            tblNamSanXuat c = namsanxuatRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblNamSanXuat c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    namsanxuatRepo.Update(c);
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
                namsanxuatRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
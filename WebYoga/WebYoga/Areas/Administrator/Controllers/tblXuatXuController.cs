using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblXuatXuController : Controller
    {
        // GET: Administrator/tblXuatXu
        tblXuatXuRepository xuatxuRepo = new tblXuatXuRepository();
        public ActionResult Index()
        {
            return View(xuatxuRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblXuatXu c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    xuatxuRepo.Create(c);

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
            tblXuatXu c = xuatxuRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblXuatXu c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    xuatxuRepo.Update(c);
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
                xuatxuRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
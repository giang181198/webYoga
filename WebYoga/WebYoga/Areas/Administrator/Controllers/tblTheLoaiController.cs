using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblTheLoaiController : Controller
    {
        // GET: Administrator/tblTheLoai
        tblTheLoaiRepository theloaiRepo = new tblTheLoaiRepository();
        public ActionResult Index()
        {
            return View(theloaiRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblTheLoai c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    theloaiRepo.Create(c);

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
            tblTheLoai c = theloaiRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblTheLoai c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    theloaiRepo.Update(c);
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
                theloaiRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
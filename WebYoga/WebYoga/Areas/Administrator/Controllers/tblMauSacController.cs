using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblMauSacController : Controller
    {
        // GET: Administrator/tblMauSac
        tblMauSacRepository mausacRepo = new tblMauSacRepository();
        public ActionResult Index()
        {
            return View(mausacRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblMauSac c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mausacRepo.Create(c);

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
            tblMauSac c = mausacRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblMauSac c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mausacRepo.Update(c);
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
                mausacRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
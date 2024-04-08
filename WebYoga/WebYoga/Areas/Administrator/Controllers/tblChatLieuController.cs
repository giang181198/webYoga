using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYoga.Model;
using WebYoga.Repository;

namespace WebYoga.Areas.Administrator.Controllers
{
    public class tblChatLieuController : Controller
    {
        // GET: Administrator/tblChatLieu
        tblChatLieuRepository chatlieuRepo = new tblChatLieuRepository();
        public ActionResult Index()
        {
            return View(chatlieuRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblChatLieu c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chatlieuRepo.Create(c);

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
            tblChatLieu c = chatlieuRepo.GetById(id);
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(tblChatLieu c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chatlieuRepo.Update(c);
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
                chatlieuRepo.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
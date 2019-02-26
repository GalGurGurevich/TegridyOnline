using Model;
using Repository;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class WeedController : Controller
    {
        private DBManager db;

        public WeedController()
        {
            this.db = new DBManager();
        }
        // GET: Weed
        public ActionResult Index(string sort)
        {
            var items = ShoppingCart.GetAllItemsInAllShoppingCarts();

            var weed = db.WeedRepository.GetWeed().Where(w => !items.Contains(w.WeedId));

            var sorted = sort == "date"
                ? weed.OrderBy(product => product.WeedId)
                : weed.OrderBy(product => product.Title);

            return View(sorted);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var weed = db.WeedRepository.GetWeedByID(id);
            return View(weed);
        }

        [Authorize] //Only Register user can add product
        [HttpPost]
        [ValidateAntiForgeryToken] //Attribute that prevents cyber attacks 
        public ActionResult Create(Weed weed, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Some error occured");
                    return View(weed);
                }

                weed.Pic = GetFileContent(file1);
                weed.Pic2 = GetFileContent(file2);
                weed.Pic3 = GetFileContent(file3);

                if (ModelState.IsValid)
                {
                    db.WeedRepository.InsertWeed(weed);
                    weed.PublishDate = DateTime.Now;
                    db.WeedRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator. ");
            }
            return View(weed);
        }

        public ActionResult Edit(int id)
        {
            Weed weed = db.WeedRepository.GetWeedByID(id);
            return View(weed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Weed weed)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.WeedRepository.UpdateWeed(weed);
                    db.WeedRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(weed);
        }

        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Weed weed = db.WeedRepository.GetWeedByID(id);
            return View(weed);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                db.WeedRepository.DeleteWeed(id);
                db.WeedRepository.Save();
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.WeedRepository.Dispose();
            base.Dispose(disposing);
        }

        private static byte[] GetFileContent(HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    return ms.GetBuffer();
                }
            }
            else
            {
                return null;
            }
        }
    }
}
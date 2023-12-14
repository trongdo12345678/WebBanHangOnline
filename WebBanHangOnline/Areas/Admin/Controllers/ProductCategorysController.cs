using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.Entity;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class ProductCategorysController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductsCategory
        public ActionResult Index()
        {
            var items = db.ProductCates;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCategorys model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Commons.Filter.FilterChar(model.Title);
                db.ProductCates.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }
        public ActionResult Edit(int Id)
        {
            var item = db.ProductCates.Find(Id);
            return View(item);
        }
        //update danh mục sản phẩm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategorys model)
        {
            if (ModelState.IsValid)
            {
                db.ProductCates.Attach(model);
                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Commons.Filter.FilterChar(model.Title);
                db.Entry(model).Property(x => x.Title).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.Alias).IsModified = true;
                db.Entry(model).Property(x => x.Icon).IsModified = true;
                db.Entry(model).Property(x => x.SeoDescripton).IsModified = true;
                db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                db.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }
        //delete danh mục sản phẩm
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductCates.Find(id);
            if (item != null)
            {
                //var DeleteItem = db.Categorles.Attach(item);    
                db.ProductCates.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        } 
    }
}

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
        //daleteall danh muc sản phẩm
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.ProductCates.Find(Convert.ToInt32(item));
                        db.ProductCates.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}

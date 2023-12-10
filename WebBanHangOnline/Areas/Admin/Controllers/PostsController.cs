using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.Entity;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string searchtext, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }

            IEnumerable<Posts> items = db.Posts.OrderByDescending(x => x.Id);

            if (!string.IsNullOrEmpty(searchtext))
            {
                searchtext = searchtext.ToLower();
                items = items.Where(x => x.Alias.ToLower().Contains(searchtext) || x.Title.ToLower().Contains(searchtext)).ToList();
            }

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.OrderByDescending(x => x.Id).ToPagedList(pageIndex, pageSize);

            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return View(items);
        }

        //add thêm sản phẩm
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Posts model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.CategoryID = 3;
                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Commons.Filter.FilterChar(model.Title);
                db.Posts.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }
        public ActionResult Edit(int Id)
        {
            var item = db.Posts.Find(Id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Commons.Filter.FilterChar(model.Title);
                db.Posts.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);

        }

        public ActionResult Delete(int Id)
        {
            var item = db.Posts.Find(Id);
            if (item != null)
            {
                db.Posts.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = true });
        }
        //bật tắt hiểm thi tin
        public ActionResult IsActived(int id)
        {
            var item = db.Posts.Find(id);
            if (item != null)
            {
                item.IsActived = !item.IsActived;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActived = item.IsActived });
            }
            return Json(new { success = false });
        }
        //deleteall sản phẩm
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.Posts.Find(Convert.ToInt32(item));
                        db.Posts.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}
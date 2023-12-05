using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.Entity;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext db =  new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = db.Categorles;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Categorys model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedrDate = DateTime.Now;
                model.Alias = WebBanHangOnline.Models.Commons.Filter.FilterChar(model.Title);
                db.Categorles.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.Data.Entity;
using PagedList.Mvc;
using PagedList;
using Blog.Models;
namespace Blog.Controllers
{
    public class AddArController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: AddAr
        public ActionResult AddAr()
        {
          
            var categories = context.Categories;
            ViewBag.Categories = categories;
            SelectList category = new SelectList(context.Categories, "CategoryId", "CategoryName");
            ViewBag.Category = category;
            //      ViewBag.ProductId = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddAr(Article article)
        {

            context.Articles.Add(article);
            var category = context.Categories;


            context.SaveChanges();
            return RedirectToAction("../Home/");
        }
    }
}
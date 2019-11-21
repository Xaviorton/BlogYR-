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
    public class CategoryController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Category


        [HttpGet]
        public ActionResult Category(int? id)
        {
            
            ViewBag.Id = id;
            var categories = context.Categories;
            ViewBag.Categories = categories;
            var Articles = context.Articles.Include(c => c.CN);
            ViewBag.Articles = Articles;




            if (id == null)
            {
                return HttpNotFound();
            }
            Category category = context.Categories.Include(t => t.Articles).FirstOrDefault(t => t.CategoryId == id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);

        }
    }
}
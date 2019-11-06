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
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            //   IEnumerable<Product> Articles = db.Articles;
          
            //     IEnumerable<Category> categories = db.Categories;
            //    ViewBag.Articles = Articles;
   
            var categories = context.Categories;
            ViewBag.Categories = categories;

            //     ViewBag.Categories = categories;
            var prod = context.Articles.Include(c => c.CN);
            var pr = prod.ToList();
            int pageSize = 6;

            int pageNumber = (page ?? 1);
            return View(pr.ToPagedList(pageNumber, pageSize));
        //    return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;
namespace Blog.Controllers
{
    public class MoreController : Controller
    {
       
            ApplicationDbContext db = new ApplicationDbContext();
            // GET: More
            [HttpGet]
            public ActionResult More(int? id)
            {
                var categories = db.Categories;
                ViewBag.Categories = categories;
                if (id == null)
                {
                    return HttpNotFound();
                }
                Article article = db.Articles.Find(id);
                if (article != null)
                {
                    return View(article);
                }
                return HttpNotFound();

            }


        }
    }


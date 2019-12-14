using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class MyController : Controller
    {
        // GET: My
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var authors = db.Authors.ToList();
                ViewBag.AuthorName = db.Authors.Select(a => a.FirstName).FirstOrDefault();
                ViewData["AuthorName"] = db.Authors.Select(a => a.FirstName).FirstOrDefault();
                TempData["AuthorName"] = db.Authors.Select(a => a.FirstName.StartsWith("o")).FirstOrDefault();
                return View(authors);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Authors author)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                    //RedirectToAction("Index");
                }
                else return View(author);

            }
            return RedirectToAction("Index");

        }

        public ActionResult Hi()
        {
            return Content("<div>Hi</div>", "text/html");
        }

        public ActionResult Details()
        {
            //return Redirect("Error");
            //return HttpNotFound();
            //return View();
            return new HttpStatusCodeResult(403);
        }

    }
}
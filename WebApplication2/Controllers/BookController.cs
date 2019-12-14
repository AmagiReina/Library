using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var books = db.Books.OrderBy(x => x.Title).ToList();

                //ViewBag.AuthorName = db.Authors.Select(a => a.FirstName).FirstOrDefault();

                return View(books);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (Model1 db = new Model1())
            {
                ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "Id", "FirstName");
                ViewBag.GenreList = new SelectList(db.Genres.ToList(), "Id", "Name");

                return View();
            }
        }


        [HttpPost]
        public ActionResult Create(Books book)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                else return View(book);

            }
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (Model1 db = new Model1())
            {
                var book = db.Books.Find(id);
                ViewBag.AuthorList = new SelectList(db.Authors.ToList(), "Id", "FirstName");
                ViewBag.GenreList = new SelectList(db.Genres.ToList(), "Id", "Name");

                return View(book);
            };
        }


        [HttpPost]
        public ActionResult Edit(Books book)
        {
            using (Model1 db = new Model1())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(book).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else return View(book);

            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (Model1 db = new Model1())
            {
                var book = db.Books.Find(id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }


    }

    
}
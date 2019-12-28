using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    public class OrderBookController : Controller
    {
        // GET: OrderBook
        public ActionResult Index()
        {
            using (Model1 db = new Model1())
            {
                var orderBooks = db.OrderBooks.Include(nameof(db.Users)).Include(nameof(db.Books)).ToList();

                ViewBag.UserList = new SelectList(db.Users.ToList(), "Id", "UsersName");
                ViewBag.BookList = new SelectList(db.Books.ToList(), "Id", "Title");

                return View(orderBooks);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (Model1 db = new Model1())
            {
                ViewBag.UserList = new SelectList(db.Users.ToList(), "Id", "UsersName");
                ViewBag.BookList = new SelectList(db.Books.ToList(), "Id", "Title");
   
                var order = db.OrderBooks.Find(id);

                var book = db.OrderBooks.Where(o => o.UserId == order.UserId).Take(5).Select(o => o.BookId);

                /*TO DO Change to Lambda ForEach*/
                List<Books> bookList = new List<Books>();
                foreach (int item in book)
                {
                    var l = db.Books.Where(b => b.Id == item).FirstOrDefault();
                    bookList.Add(l);
                }

                ViewBag.OrderedBooksList = bookList;

                return View(order);
            }
               
        }

        public ActionResult GetTop5(int userId)
        {
            using (Model1 db = new Model1())
            {
                var book = db.OrderBooks.Where(o => o.UserId == userId).Take(5).Select(o => o.BookId);

                /*TO DO Change to Lambda ForEach*/
                List<Books> bookList = new List<Books>();
                foreach (int item in book)
                {
                    var l = db.Books.Where(b => b.Id == item).FirstOrDefault();
                    bookList.Add(l);
                }
                return new JsonResult
                {
                    Data = bookList,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (Model1 db = new Model1())
            {
                ViewBag.UserList = new SelectList(db.Users.ToList(), "Id", "UsersName");
                ViewBag.BookList = new SelectList(db.Books.ToList(), "Id", "Title");
                return PartialView("Partial/_CreatePartialView");
            }
        }


        [HttpPost]
        public ActionResult Create(OrderBook order)
        {
            using (Model1 db = new Model1())
            {
                ViewBag.UserList = new SelectList(db.Users.ToList(), "Id", "UsersName");
                ViewBag.BookList = new SelectList(db.Books.ToList(), "Id", "Title");
                if (Request.IsAjaxRequest())
                {

                }

                if (ModelState.IsValid)
                {
                    order.orderDate = DateTime.Now;
                    db.OrderBooks.Add(order);
                    db.SaveChanges();
                }
                return null;
                /*return new JsonResult
                {
                    Data = db.OrderBooks.ToList(),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };*/
            }
        }
    }
}
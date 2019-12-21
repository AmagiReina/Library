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
    }
}
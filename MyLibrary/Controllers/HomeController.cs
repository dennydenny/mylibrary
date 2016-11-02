using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult AddNewBook()
        {
            return View();
        }

        /// <summary>
        /// Метод добавления книги в БД.
        /// </summary>
        /// <param name="book">Модель книги, полученная из формы ввода.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddNewBook(Book book)
        {
            bool status = false;
            string message = "";
            // TODO: Реализовать проверку входных данных.
            if (ModelState.IsValid)
            {
                try
                {
                    DatabaseHelper.AddBook(book);
                    status = true;
                    message = "Ok";
                }
                catch (Exception e)
                {
                    message = String.Format("Error: {0}", e.Message);
                }
            }
            else
            {
                message = "Error: model is not valid";
            }
            return new JsonResult { Data = new { status = status, message = message } };
        }

        public ActionResult ShowBook(Book book)
        {
            return View();
        }
    }
}
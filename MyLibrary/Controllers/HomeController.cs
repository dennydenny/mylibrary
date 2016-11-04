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

        [HttpPost]
        public JsonResult DeleteBook(Book book)
        {
            bool status = false;
            string message = "";
            // TODO: Реализовать проверку входных данных.
            if (ModelState.IsValid)
            {
                try
                {
                    //DatabaseHelper.AddBook(book);
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

        /// <summary>
        /// Метод, выводящий информацию по книге на основе её идентификатора.
        /// </summary>
        /// <param name="id">Идентификатор книги.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ShowBook(int id)
        {
            if (id > 0)
            {
                try
                {
                    Book book = DatabaseHelper.GetBookById(id);
                    return View(book);
                }
                catch (Exception e)
                {
                    return HttpNotFound(e.Message);
                }            
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult ShowBook()
        {
            return View("Index");
        }

    }
}
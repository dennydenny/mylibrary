﻿using System;
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
            DatabaseHelper.FillByTestData();
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
                    ViewBag.Readers = DatabaseHelper.GetAllReaders();
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

        /// <summary>
        /// Метод, осуществляющий добавление нового читателя в библиотеку.
        /// </summary>
        /// <param name="reader">Экземпляр читателя.</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddNewReader(Reader reader)
        {
            bool status = false;
            string message = "";
            // TODO: Реализовать проверку входных данных.
            if (ModelState.IsValid)
            {
                try
                {
                    DatabaseHelper.AddReader(reader);
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

        public ActionResult AddNewReader()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewCard(int readerid, int count, int bookid, int direction)
        {
            //TODO: Реализовать валидацию данных на клиенте и сервере.
            Card card = new Card {ReaderId1 = readerid, Count = count, BookId1 = bookid, Timestamp = DateTime.Now, Direction = direction};
            DatabaseHelper.AddCard(card);
            return View();
        }

    }
}
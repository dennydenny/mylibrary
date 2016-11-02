using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public static class DatabaseHelper
    {
        /// <summary>
        /// Метод, осуществляющий запись информации о книги в БД.
        /// </summary>
        /// <param name="book">Экземпляр книги, которую необходимо добавить.</param>
        public static void AddBook (Book book)
        {
            if (book != null)
            {
                using (LibraryContainer context = new LibraryContainer())
                {
                    context.BookSet.Add(book);
                    context.SaveChanges();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }   
    }
}
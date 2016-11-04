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

        /// <summary>
        /// Метод, осуществляющий поиск книг в БД по подстроке.
        /// </summary>
        /// <param name="substring">Подстрока для поиска книги</param>
        /// <returns>Список найденных книг</returns>
        public static IEnumerable<Book> GetBookBySubstring (string substring)
        {
            if (!String.IsNullOrEmpty(substring))
            {
                IEnumerable<Book> result;
                using (LibraryContainer context = new LibraryContainer())
                {
                    result = context.BookSet.Where(b => b.Discription.Contains(substring)).ToList();
                }
                if (result.Count() < 1)
                {
                    return null;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Метод осуществляет поиск книги по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор книги</param>
        /// <returns></returns>
        public static Book GetBookById(int id)
        {
            if (id > 0)
            {
                Book result;
                using (LibraryContainer context = new LibraryContainer())
                {
                    result = context.BookSet.Single(b => b.Id == id);
                }
                return result;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public static void RemoveBook(Book book)
        {
            if (book != null)
            {
                using (LibraryContainer context = new LibraryContainer())
                {
                    context.BookSet.Remove(book);
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
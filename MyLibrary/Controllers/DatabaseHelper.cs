using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyLibrary.Models;
using System.Data.Entity;

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

        /// <summary>
        /// Метод для заполнения БД тестовыми данными.
        /// </summary>
        public static void FillByTestData()
        {
            using (LibraryContainer context = new LibraryContainer())
            {
                context.BookSet.Load();
                if (context.BookSet.Local.Count < 6)
                {
                    context.BookSet.Add(
                    new Book
                    {
                        Author = "Достоевский",
                        Count = 20,
                        Discription = "Как писателя и публициста Ф.М.Достоевского интересовало практически все происходящее в современном ему мире, все находило отклик в его творчестве. «Дневник писателя», помимо обсуждений самых различных тем, от глубоких философских и нравственных вопросов до анализа внешней политики держав, включает прямое обращение к читателю, как к непосредственному соучастнику событий своего времени. Для нашего же времени актуальность «Дневника писателя» заключается в проницательности Ф.М.Достоевского, вскрывающей неизменную суть явлений.",
                        Name = "Дневник писателя",
                        Year = 1872,
                        Genre = "Публицистика",
                        Publishing = "Русская классика"
                    });
                    context.BookSet.Add(
                        new Book
                        {
                            Author = "Булгаков Михаил",
                            Count = 25,
                            Discription = "«Собачье сердце» — одно из самых любимых читателями произведений Михаила Булгакова. Этот вариант текста, пришедший из там/самиздата — не вполне булгаковский, с сотнями произвольных искажений. О нем можно сказать, что это — повесть, которой Булгаков не писал, но именно ее прочитали все.",
                            Name = "Собачье сердце",
                            Year = 1925,
                            Genre = "Советская классическая проза",
                            Publishing = "Русская классика"
                        });
                    context.BookSet.Add(
                        new Book
                        {
                            Author = "Достоевский",
                            Count = 6,
                            Discription = "Идиот - роман, в котором Достоевский впервые с подлинной страстью, ярко и полно изобразил положительного героя, каким его представлял. В князе Мышкине соединились черты образа Христа и одновременно ребенка, умиротворенность, граничащая с беспечностью, и невозможность пройти мимо беды ближнего.В нормальном обществе людей, одержимых корыстью и разрушительными страстями, князь Мышкин - идиот. В мире, где красота замутнена нечистыми помыслами людей, такой герой беспомощен, хотя и прекрасен. Но красота спасет мир!, утверждает Достоевский устами князя Мышкина, и в мире становится светлей.",
                            Name = "Идиот",
                            Year = 2002,
                            Genre = "Драма",
                            Publishing = "Эксмо"
                        });
                    context.BookSet.Add(
                        new Book
                        {
                            Author = "Борис Пастернак",
                            Count = 21,
                            Discription = "Одни из самых лучших, самых сокровенных стихов Б.Пастернак вложил в уста своего любимого героя Юрия Живаго. ДОКТОР ЖИВАГО - роман о любви, о России, о русской природе, о русской интеллигенции... Это роман обо всей нашей жизни. И он удивительно созвучен сегодняшнему дню.",
                            Name = "Доктор Живаго",
                            Year = 2016,
                            Genre = "Русская классика",
                            Publishing = "Эксмо"
                        });
                    context.BookSet.Add(
                        new Book
                        {
                            Author = "Лев Толстой",
                            Count = 7,
                            Discription = "Анна Каренина, один из самых знаменитых романов Льва Толстого, начинается ставшей афоризмом фразой: Все счастливые семьи похожи друг на друга,каждая несчастливая семья несчастлива по - своему.Это книга о вечных ценностях: о любви, о вере, о семье, о человеческом достоинстве.",
                            Name = "Анна Каренина",
                            Year = 2016,
                            Genre = "Русская классика",
                            Publishing = "Эксмо"
                        });
                    context.BookSet.Add(
                        new Book
                        {
                            Author = "Иоганн Вольфганг Гете",
                            Count = 8,
                            Discription = "Великий Гете задумал своего Фауста, когда ему было немногим больше двадцати лет, а завершил трагедию за несколько месяцев до кончины. Это произведение стало итогом философских и художественных исканий автора - поэта, драматурга, прозаика, крупнейшего ученого своего времени, человека энциклопедических познаний. Герой трагедии доктор Иоганн Фауст жил в первой половине XVI века и слыл магом и чернокнижником, который, отвергнув современную науку и религию, продал душу дьяволу.",
                            Name = "Фауст",
                            Year = 2014,
                            Genre = "Мировая классика",
                            Publishing = "Азбука"
                        });
                    context.SaveChanges();
                }
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
using System;
using System.Web.Mvc;
using MyLibrary.Models;

namespace MyLibrary.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public ActionResult Index(string searchQuery)
        {
            BookSearchResponse response = new BookSearchResponse();
            response.Query = searchQuery;
            try
            {
                response.Result = DatabaseHelper.GetBookBySubstring(searchQuery);
            }
            catch (Exception e)
            {
                response.Exception = e;
            }
            return PartialView("_SearchResults", response);
        }
    }
}
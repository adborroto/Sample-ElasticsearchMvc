using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Web.Models;
using Library.Web.ViewModels;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private SearchService _searchService;
        public HomeController()
        {
            _searchService = new SearchService();
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Search(string query, int page = 0, int pageSize = 10)
        {

            var result = _searchService.Find(query, page, pageSize);
            var suggestion = _searchService.FindPhraseSuggestion(query, 0, 3);

            var viewModel = new SearchViewModel { Query = query, Results = result.Item1,Elapsed = result.Item2, Suggestions = suggestion };


            return View("Index", viewModel);
        }

    }
}
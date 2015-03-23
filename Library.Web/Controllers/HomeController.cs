using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Web.Models;

namespace Library.Web.Controllers
{
    public class HomeController : Controller
    {
        private SearchService _searchService;
        public HomeController()
        {
          _searchService =  new SearchService();
        }
        public ActionResult Index()
        {
            
            return View();
        }
        
        public ActionResult Search(string query,int page= 0,int pageSize = 10)
        {
           var result = _searchService.Find(query, page, pageSize);
            return View("Index", result);
        }

    }
}
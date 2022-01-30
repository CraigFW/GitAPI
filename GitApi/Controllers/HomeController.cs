using GitApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                return RedirectToAction("Details", "Git", new { UserName = SearchString });
            }
            else
            {
                return RedirectToAction("index", "home");
            }
        }
    }
}
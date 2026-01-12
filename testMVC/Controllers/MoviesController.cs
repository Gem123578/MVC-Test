using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testMVC.Models;

namespace testMVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = new Movies { Name = "Sai Aung Myo Thant" };
            return View(movies);
        }
        
        public ActionResult Edit(int? id)
        {
            return Content("id=" + id);
        }
        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("PageIndex = {0} & SortBy = {1}", pageIndex, sortBy));
          
        }
    }
}
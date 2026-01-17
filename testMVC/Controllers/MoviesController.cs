using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testMVC.Models;
using testMVC.ViewModels;

namespace testMVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movies = new Movies { Name = "Sai Aung Myo Thant" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };
            RandomMovieViewModel viewModel = new RandomMovieViewModel
            {
                Movie = movies,
                Customers = customers
            };
            return View(viewModel);
        }
        //Moves/Edit/1
        public ActionResult Edit(int? id)
        {
            return Content("id=" + id);
        }
        //movies/index?pageIndex=1&sortBy=name
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("PageIndex = {0} & SortBy = {1}", pageIndex, sortBy));
          
        }

        //movies/released/2015/03
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult Release(int year, int month)
        { 
            return Content(year + "/" + month);
        }
    }
}
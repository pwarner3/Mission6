using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesContext _context { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MoviesContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies()
        {
            ViewBag.Categories = _context.Categories.ToList();//Using ViewBag which can be passed around views

            return View();
        }

        [HttpPost]
        public IActionResult AddMovies(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();
                return View("Confirmation",movie);
            }

            ViewBag.Categories = _context.Categories.ToList();//Using ViewBag which can be passed around views
            return View();
            
        }

        [HttpGet]
        public IActionResult ListMovies()
        {
            //pulling data from db
            var movies = _context.Movies
                .Include(x => x.Category)
                //.Where()
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _context.Categories.ToList();

            var movie = _context.Movies.Single(x => x.MovieId == movieid);

            return View("AddMovies",movie);
        }
        [HttpPost]
        public IActionResult Edit(MovieModel movieUpdated)
        {
            _context.Movies.Update(movieUpdated);
            _context.SaveChanges();
            return RedirectToAction("ListMovies");//Redirects to the list movie page

        }
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = _context.Movies.Single(x => x.MovieId == movieid);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieModel movieDelete)
        {
            _context.Remove(movieDelete);
            _context.SaveChanges();

            return RedirectToAction("ListMovies");
        }











        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

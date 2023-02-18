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











        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

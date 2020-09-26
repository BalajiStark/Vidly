using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private MyDbContext _context;

        public MoviesController()
        {
            _context = new MyDbContext();
        }
        public ActionResult Random()
        {
            var movies = _context.movies.Include(c => c.Genre).ToList();
            return View(movies);
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}
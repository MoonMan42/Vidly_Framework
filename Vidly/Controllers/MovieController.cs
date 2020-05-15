using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movie
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("Index");
            }
            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var modelView = new MovieFormViewModel
            {
                Id = 0,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", modelView);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var veiwModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList(),
               

            };

            return View("MovieForm", veiwModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                movie.NumberAvailable = movie.NumberInStock;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieToUpdate = _context.Movies.Single(m => m.Id == movie.Id);

                movieToUpdate.Name = movie.Name;
                movieToUpdate.RealseDate = movie.RealseDate;
                movieToUpdate.GenreId = movie.GenreId;
                movieToUpdate.NumberInStock = movie.NumberInStock;
                movieToUpdate.NumberAvailable = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
    }
}
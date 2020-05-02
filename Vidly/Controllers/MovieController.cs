using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            
            return View(GetMovies());
        }

       private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>{
                new Movie { Id=1, Name="Wall-e"}, 
                new Movie { Id=2, Name="Red"}
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public NewRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals (NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == newRentalDto.CustomerId);

            if (customer == null)
            {
                return BadRequest("Invalid customer Id.");
            }

            var movies = _context.Movies.Where(
                m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != newRentalDto.MovieIds.Count)
                return BadRequest("OneOrMore Movie Ids are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest("Movie is not available");
                }

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
          
    }
}

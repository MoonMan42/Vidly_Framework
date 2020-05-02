using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers = GetCusomters().ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var movie = GetCusomters().FirstOrDefault(m => m.Id == id);

            return View(movie);
        }

        private IEnumerable<Customer> GetCusomters()
        {
            return new List<Customer>
            {
                new Customer{Id=1, Name="John Doe"},
                new Customer{Id=2, Name="Wilson Doe"}
            };
        }
    }
}
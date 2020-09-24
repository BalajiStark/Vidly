using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult CustomersList()
        {
            var customers = GetCustomer();
            return View(customers);
        }

        public ActionResult CustomerDetails(int id)
        {
            var customer = GetCustomer().Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public RandomMovieViewModel GetCustomer()
        {
            var random = new RandomMovieViewModel();
            var customers = new List<Customers>();
            var customer1 = new Customers
            {
                Name = "Tony Stark",
                Id = 1
            };
            var customer2 = new Customers
            {
                Name = "Steve Rogers",
                Id = 2
            };
            customers.Add(customer1);
            customers.Add(customer2);
            random.Customers = customers;
            return random;
        }
    }
}
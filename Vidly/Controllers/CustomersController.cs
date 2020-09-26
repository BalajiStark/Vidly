using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private MyDbContext _context;

        public CustomersController()
        {
            _context = new MyDbContext();
        }

        public ActionResult New()
        {
            var memberShipTypes = _context.memberShipTypes.ToList();
            var viewmodel = new CustomerFormViewModel
            {
                MemberShipType = memberShipTypes
            };
            return View(viewmodel);
        }
        public ActionResult CustomersList()
        {
            var customers = _context.customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult CustomerDetails(int id)
        {
            var customer = _context.customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }        
    }
}
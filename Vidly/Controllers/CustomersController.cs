using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Runtime.Remoting.Messaging;

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

        public ActionResult CustomerForm()
        {
            var memberShipTypes = _context.memberShipTypes.ToList();
            var viewmodel = new CustomerFormViewModel
            {
                MemberShipType = memberShipTypes
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Create(CustomerFormViewModel customerDetails)
        {
            var customer = customerDetails.Customers;
            if (customer.Id == 0)
            {
                _context.customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.customers.Include(c => c.MemberShipType).Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DateofBirth = customer.DateofBirth;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsSubscribed = customer.IsSubscribed;
            }
            _context.SaveChanges();

            return RedirectToAction("CustomersList", "Customers");
        }
        public ActionResult CustomersList()
        {
            var customers = _context.customers.Include(c => c.MemberShipType).ToList();
            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.customers.Include(c => c.MemberShipType).Single(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewmodel = new CustomerFormViewModel
            {
                Customers = customer,
                MemberShipType = _context.memberShipTypes.ToList()
            };
            return View("CustomerForm" , viewmodel);
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
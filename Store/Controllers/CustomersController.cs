using Store.Models;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class CustomersController : Controller
    {
        private StoreEntities db;
        public CustomersController()
        {
            db = new StoreEntities();
        }
        // GET: Customers

        public ActionResult CustomerList()
        {
            var viewModel = new CustomerViewModel
            {
                Customers = db.customers.ToList()
            };
            return View(viewModel);
        }

        public ActionResult CustomerForm()
        {
            var viewModel = new CustomerViewModel
            {
                Customer = new customer()
            };
            return View(viewModel);
        }

        public ActionResult EditCustomer(int id)
        {
            var viewModel = new CustomerViewModel
            {
                Customer = db.customers.Where(x => x.customer_id == id).SingleOrDefault()
            };
            return View("CustomerForm", viewModel);
        }
        public ActionResult Save(customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.customer_id == 0)
            {
                db.customers.Add(customer);
            }
            else
            {
                var customerInDb = db.customers.Where(x => x.customer_id == customer.customer_id).SingleOrDefault();
                customerInDb.first_name = customer.first_name;
                customerInDb.last_name = customer.last_name;
                customerInDb.birth_date = customer.birth_date;
                customerInDb.phone = customer.phone;
                customerInDb.address = customer.address;
                customerInDb.city = customer.city;
                customerInDb.state = customer.state;                
            }

            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCustomer(int id)
        {
            var customerToDelete = db.customers.Where(x => x.customer_id == id).SingleOrDefault();
            db.customers.Remove(customerToDelete);
            db.SaveChanges();
            return RedirectToAction("CustomerList");
        }
    }
}
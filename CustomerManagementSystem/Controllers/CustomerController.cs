using CustomerManagementSystem.Models;
using CustomerManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerManagementSystem.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerController()
        {
            _customerRepository = new CustomerRepository(new Models.CustomerDbEntity());
        }

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCustomer()
        {
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = "Add Customer Failed";
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(User customer)
        {
            if (ModelState.IsValid)
            {
                int result = _customerRepository.AddCustomer(customer);

                if (result > 0)
                {
                    return RedirectToAction("ListCustomers");
                }
                else
                {
                    TempData["Failed"] = "Failed";

                    return RedirectToAction("ListCustomers");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(_customerRepository.GetCustomerId(id));
        }

        [HttpPost]
        public ActionResult Edit(User customer)
        {
            if (ModelState.IsValid)
            {
                int result = _customerRepository.UpdateCustomer(customer);

                if (result > 0)
                {
                    return RedirectToAction("ListCustomers");
                }
                else
                {

                    return RedirectToAction("ListCustomers");
                }
            }
            return View();
        }

        public ActionResult RemoveCustomer(int id)
        {
            return View(_customerRepository.GetCustomerId(id));
        }

        [HttpPost]
        public ActionResult RemoveCustomer(int id,User customer)
        {
            //if (TempData["Failed"] != null)
            //{
            //    ViewBag.Failed = "Delete Employee Failed";
            //}
            _customerRepository.DeleteCustomer(id);

            return RedirectToAction("ListCustomers");
        }

        public ActionResult CustomerDetails(int id)
        {
            User customer = _customerRepository.GetCustomerId(id);

            return View(customer);
        }

        public ActionResult ListCustomers(string rating, string searchByRating)
        {
            return View(_customerRepository.SearchCustomer(rating, searchByRating));

        }


    }
}
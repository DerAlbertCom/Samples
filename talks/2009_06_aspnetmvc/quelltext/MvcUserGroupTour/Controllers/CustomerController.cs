using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcUserGroupTour.DataTransferObjects;
using MvcUserGroupTour.Extensions;
using MvcUserGroupTour.Models;
using MvcUserGroupTour.Services;
using MvcUserGroupTour.Validation;

namespace MvcUserGroupTour.Controllers
{
    public class CustomerController : UserGroupController
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View(service.GetFirst5Customers());
        }

        public ActionResult Search(string searchText)
        {
            return View("Index", service.GetCustomersForSearch(searchText));
        }

        public ActionResult Details(string id)
        {
            var model = new CustomerDetailModel
            {
                Customer = service.GetCustomer(id),
                Orders = service.GetOrdersForCustomer(id)
            };
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View(new CustomerDto());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        public ActionResult Create(CustomerDto customerDto)
        {
            try
            {
                customerDto.Validate(ModelState);
                if (ModelState.IsValid)
                {
                    service.SaveCustomer(customerDto);
                    return RedirectToAction("Index");
                }
                return View(customerDto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(customerDto);
            }
        }

        [Authorize]
        public ActionResult Edit(string id)
        {
            return View(service.GetCustomer(id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Authorize]
        public ActionResult Edit(string id, CustomerDto customerDto)
        {
            try
            {
                if (id != customerDto.CustomerID)
                {
                    throw new InvalidOperationException();
                }
                customerDto.Validate(ModelState);
                if (ModelState.IsValid)
                {
                    service.UpdateCustomer(customerDto);
                    return RedirectToAction("Index");
                }
                return View(customerDto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(customerDto);
            }
        }


    }
}
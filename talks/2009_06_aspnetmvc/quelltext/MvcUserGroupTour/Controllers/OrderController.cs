using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MvcUserGroupTour.Services;

namespace MvcUserGroupTour.Controllers
{
    public class OrderController : UserGroupController
    {
        private readonly IOrderService service;

        public OrderController(IOrderService service)
        {
            this.service = service;
        }

        //
        // GET: /Order/

        public ActionResult Detail(int id)
        {
            return View(service.GetOrderById(id));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Rhino.Mocks;

namespace MvcUserGroupTour.Tests.ActionFilter
{
    public static class ActionContextTestHelper
    {
        private class TestController : Controller
        {
            public ActionResult TestAction()
            {
                return View();
            }
        }

        public static ActionExecutingContext CreateActionExecutingContext()
        {
            var controller = new TestController();
            ActionDescriptor actionDescriptor = CreateActionDescriptorFor(controller, "TestAction");
            var routeData = new RouteData();
            var httpContext = MockRepository.GenerateStub<HttpContextBase>();
            var controllerContext = new ControllerContext(httpContext, routeData, controller);

            return new ActionExecutingContext(controllerContext, actionDescriptor, new Dictionary<string, object>());
        }

        public static ActionExecutedContext CreateActionExecutedContext()
        {
            var controller = new TestController();
            ActionDescriptor actionDescriptor = CreateActionDescriptorFor(controller, "TestAction");
            var routeData = new RouteData();
            var httpContext = MockRepository.GenerateStub<HttpContextBase>();
            var controllerContext = new ControllerContext(httpContext, routeData, controller);

            return new ActionExecutedContext(controllerContext, actionDescriptor, false, null);
        }

        private static ActionDescriptor CreateActionDescriptorFor(Controller controller, string actionName)
        {
            var type = controller.GetType();
            return new ReflectedActionDescriptor(type.GetMethod(actionName), actionName,
                                                 new ReflectedControllerDescriptor(type));
        }
    }
}
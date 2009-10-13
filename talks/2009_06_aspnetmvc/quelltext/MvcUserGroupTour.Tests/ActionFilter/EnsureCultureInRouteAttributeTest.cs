using System;
using System.Web.Mvc;
using MvcUserGroupTour.ActionFilter;
using NUnit.Framework;

namespace MvcUserGroupTour.Tests.ActionFilter
{
    [TestFixture]
    public class EnsureCultureInRouteAttributeTest
    {
        [Test]
        public void RedirectToRoute_wenn_keine_Culture_vorhanden_ist()
        {
            ActionExecutingContext actionExecutingContext = ActionContextTestHelper.CreateActionExecutingContext();
            var attribute = new EnsureCultureInRouteAttribute();
            attribute.OnActionExecuting(actionExecutingContext);
            Assert.AreEqual(typeof(RedirectToRouteResult), actionExecutingContext.Result.GetType());
        }

        [Test]
        public void RedirectToRoute_mit_Culture_wenn_keine_Culture_vorhanden_ist()
        {
            ActionExecutingContext actionExecutingContext = ActionContextTestHelper.CreateActionExecutingContext();
            var attribute = new EnsureCultureInRouteAttribute();
            attribute.OnActionExecuting(actionExecutingContext);

            var result = (RedirectToRouteResult) actionExecutingContext.Result;
            result.RouteValues.ContainsKey(RouteDataValue.Culture);
        }

        [Test]
        public void Kein_ActionResult_wenn_Culture_vorhanden_ist()
        {
            ActionExecutingContext actionExecutingContext = ActionContextTestHelper.CreateActionExecutingContext();
            actionExecutingContext.RouteData.Values.Add(RouteDataValue.Culture, "de-de");
            var attribute = new EnsureCultureInRouteAttribute();
            attribute.OnActionExecuting(actionExecutingContext);
                
            Assert.IsNull(actionExecutingContext.Result);
        }
    }
}
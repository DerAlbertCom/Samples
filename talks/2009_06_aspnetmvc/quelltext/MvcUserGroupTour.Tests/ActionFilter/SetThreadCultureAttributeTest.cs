using System;
using System.Globalization;
using System.Web.Mvc;
using MvcUserGroupTour.ActionFilter;
using NUnit.Framework;

namespace MvcUserGroupTour.Tests.ActionFilter
{
    [TestFixture]
    public class SetThreadCultureAttributeTest
    {
        private CultureInfo deCulture;
        private CultureInfo nlCulture;

        private CultureInfo currentCulture;

        [SetUp]
        public void TestSetup()
        {
            currentCulture = GetThreadCulture();
            deCulture = new CultureInfo("de-de");
            nlCulture = new CultureInfo("nl-nl");
        }

        [TearDown]
        public void TestEnd()
        {
            SetThreadCulture(currentCulture);
        }

        [Test]
        public void Thread_Culture_wird_zu_der_Sprache_in_der_Route_gesetzt()
        {
            SetThreadCulture(deCulture);
            ActionExecutingContext actionExecutingContext = ActionContextTestHelper.CreateActionExecutingContext();
            actionExecutingContext.RouteData.Values.Add(RouteDataValue.Culture, "nl-nl");
            var attribute = new SetThreadCultureAttribute();
            attribute.OnActionExecuting(actionExecutingContext);

            Assert.AreEqual(nlCulture.LCID, GetThreadCulture().LCID);
        }

        [Test]
        public void Thread_Culture_wird_nicht_geändert_wenn_keine_Sprache_in_der_Route_gesetzt_ist()
        {
            SetThreadCulture(deCulture);
            ActionExecutingContext actionExecutingContext = ActionContextTestHelper.CreateActionExecutingContext();
            var attribute = new SetThreadCultureAttribute();
            attribute.OnActionExecuting(actionExecutingContext);

            Assert.AreEqual(deCulture.LCID, GetThreadCulture().LCID);
        }

        private static CultureInfo GetThreadCulture()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        private static void SetThreadCulture(CultureInfo culture)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
        }
    }
}
using System.Web.Routing;
using MvcUserGroupTour.RouteConstraints;
using NUnit.Framework;

namespace MvcUserGroupTour.Tests.RouteConstraints
{
    [TestFixture]
    public class CultureRouteConstraintTest
    {
        [Test]
        public void Culture_hat_einen_Bindestrich_passt()
        {
            IRouteConstraint routeConstraint = new CultureRouteConstraint();
            var values = new RouteValueDictionary { { RouteDataValue.Culture, "de-de" } };
            Assert.IsTrue(routeConstraint.Match(null, null, RouteDataValue.Culture, values, RouteDirection.IncomingRequest));
        }

        [Test]
        public void Culture_ohne_einen_Bindestrich_passt_nicht()
        {
            IRouteConstraint routeConstraint = new CultureRouteConstraint();
            var values = new RouteValueDictionary { { RouteDataValue.Culture, "dede" } };
            Assert.IsFalse(routeConstraint.Match(null, null, RouteDataValue.Culture, values, RouteDirection.IncomingRequest));
        }

        [Test]
        public void Eine_leere_Culture_passt_nicht()
        {
            IRouteConstraint routeConstraint = new CultureRouteConstraint();
            var values = new RouteValueDictionary { { RouteDataValue.Culture, "" } };
            Assert.IsFalse(routeConstraint.Match(null, null, RouteDataValue.Culture, values, RouteDirection.IncomingRequest));
        }

        [Test]
        public void Eine_Culture_mit_Bindestrich_am_Anfang_passt_nicht()
        {
            IRouteConstraint routeConstraint = new CultureRouteConstraint();
            var values = new RouteValueDictionary { { RouteDataValue.Culture, "-dede" } };
            Assert.IsFalse(routeConstraint.Match(null, null, RouteDataValue.Culture, values, RouteDirection.IncomingRequest));
        }

        [Test]
        public void Eine_Culture_mit_Bindestrich_am_Ende_passt_nicht()
        {
            IRouteConstraint routeConstraint = new CultureRouteConstraint();
            var values = new RouteValueDictionary { { RouteDataValue.Culture, "dede-" } };
            Assert.IsFalse(routeConstraint.Match(null, null, RouteDataValue.Culture, values, RouteDirection.IncomingRequest));
        }

    }
}
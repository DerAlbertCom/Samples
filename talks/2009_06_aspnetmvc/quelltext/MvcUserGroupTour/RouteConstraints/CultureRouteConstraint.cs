using System.Web;
using System.Web.Routing;

namespace MvcUserGroupTour.RouteConstraints
{
    public class CultureRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
                          RouteDirection routeDirection)
        {
            var value = (string) values[parameterName];
            if (!string.IsNullOrEmpty(value))
            {
                if (value.Contains("-"))
                {
                    return !value.StartsWith("-") && !value.EndsWith("-");
                }
            }
            return false;
        }
    }
}
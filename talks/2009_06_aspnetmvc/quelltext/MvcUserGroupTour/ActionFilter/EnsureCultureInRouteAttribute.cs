using System.Web.Mvc;
using System.Web.Routing;

namespace MvcUserGroupTour.ActionFilter
{
    public class EnsureCultureInRouteAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!CultureIsInRoute(filterContext))
            {
                RouteValueDictionary routeValues = CreateRouteValuesWithCulture(filterContext, "de-de");
                filterContext.Result = new RedirectToRouteResult(routeValues);
            }
        }

        private static RouteValueDictionary CreateRouteValuesWithCulture(ActionExecutingContext filterContext,
                                                                         string culture)
        {
            var routeValues = new RouteValueDictionary(filterContext.RouteData.Values)
                                  {
                                      {RouteDataValue.Culture, culture}
                                  };
            return routeValues;
        }

        private static bool CultureIsInRoute(ControllerContext filterContext)
        {
            return filterContext.RouteData.Values.ContainsKey(RouteDataValue.Culture);
        }
    }
}
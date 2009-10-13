using System;
using System.Globalization;
using System.Web.Mvc;

namespace MvcUserGroupTour.ActionFilter
{
    public class SetThreadCultureAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var culture = GetRouteDataCulture(filterContext);
            if (!string.IsNullOrEmpty(culture))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);
            }
        }

        private static string GetRouteDataCulture(ControllerContext filterContext)
        {
            return (string)filterContext.RouteData.Values[RouteDataValue.Culture];
        }
    }
}
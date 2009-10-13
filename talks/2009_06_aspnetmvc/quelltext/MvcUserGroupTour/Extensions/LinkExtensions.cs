using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MvcUserGroupTour.Extensions
{
    public static class LinkExtensions
    {
        public static string CultureLink(this HtmlHelper htmHelper, string caption, string culture)
        {
            RouteData routeData = htmHelper.ViewContext.RouteData;
            routeData.Values[RouteDataValue.Culture] = culture;
            return htmHelper.ActionLink(caption,
                                        routeData.Values["action"].ToString(),
                                        routeData.Values["controller"].ToString(),
                                        routeData.Values,
                                        null);
        }
    }
}
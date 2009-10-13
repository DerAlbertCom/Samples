using System.Web.Mvc;

namespace MvcUserGroupTour.Extensions
{
    public static class OutputExtensions
    {
        public static string EncodeFormat(this HtmlHelper htmlHelper, string format, params object[] args)
        {
            return htmlHelper.Encode(string.Format(format, args));
        }
    }
}
/*
 * 08.02.2009 - Albert Weinert- erstellt.
 * 
 */
using System.Web.Mvc;


namespace MvcUserGroupTour.ActionFilter
{
    public class MasterPageSwitchAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;
            if (viewResult != null)
            {
                viewResult.MasterName = "Site";
            }
        }
    }
}
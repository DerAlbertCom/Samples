using System.Web.Mvc;
using MvcUserGroupTour.ActionFilter;

namespace MvcUserGroupTour.Controllers
{
    [HandleError]
    [EnsureCultureInRoute]
    [SetThreadCulture]
    public abstract class UserGroupController : Controller
    {
        
    }
}
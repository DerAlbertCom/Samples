using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Core;
using Castle.Windsor;
using MvcUserGroupTour.Controllers;
using MvcUserGroupTour.ModelBinders;
using MvcUserGroupTour.Models;
using MvcUserGroupTour.Repositories;
using MvcUserGroupTour.RouteConstraints;
using MvcUserGroupTour.Services;
using MvcUserGroupTour.Mapper;

namespace MvcUserGroupTour
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            RegisterModelBinders(System.Web.Mvc.ModelBinders.Binders);
            RegisterWindsorIoC();
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // Routing Beispiel mit Culture, wenn keine Culture angebeben ist, wird mittels EnsureCultureInRouteAttribute
            // eine Culture in die Route eingefügt. Es wird keine Standard Culture in der Route angegeben, da sonst kein
            // Redirect stattfinden würde. Ohne Redirect funktioren dann die Standard-Anmeldeseiten nicht wie
            // gewünscht 

            routes.MapRoute(
                "DefaultWithCulture", // Route name
                "{culture}/{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = ""}, // Parameter defaults
                new
                    {
                        culture = new CultureRouteConstraint()
                    }
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
        }


        private static void RegisterWindsorIoC()
        {
            var container = new WindsorContainer();
            RegisterTypesInContainer(container);
            ControllerBuilder.Current.SetControllerFactory(new UserGroupWindsorControllerFactory(container));
        }

        private static void RegisterTypesInContainer(IWindsorContainer container)
        {
            RegisterControllersInContainer(container);
            container.AddComponentLifeStyle<ICustomerRepository, CustomerRepository>(LifestyleType.Transient);
            container.AddComponentLifeStyle<IOrderRepository, OrderRepository>(LifestyleType.Transient);
            container.AddComponentLifeStyle<ICustomerService, CustomerService>(LifestyleType.Transient);
            container.AddComponentLifeStyle<IOrderService, OrderService>(LifestyleType.Transient);
            container.AddComponentLifeStyle<ICustomerMapper, CustomerMapper>(LifestyleType.Singleton);
            container.AddComponentLifeStyle<IOrderMapper, OrderMapper>(LifestyleType.Singleton);
        }

        // Dies nur als Beispiel, besser direkt die Implementierung von http://mvccontrib.org verwenden
        private static void RegisterControllersInContainer(IWindsorContainer container)
        {
            var controllerType = from t in typeof(HomeController).Assembly.GetTypes()
                              where typeof (IController).IsAssignableFrom(t)
                              select t;
            foreach (var type in controllerType)
            {
                container.AddComponentLifeStyle(type.FullName, type, LifestyleType.Transient);
            }
        }

        private static void RegisterModelBinders(ModelBinderDictionary binders)
        {
            binders[typeof (ButtonState)] = new ButtonStateModelBinder();
        }
    }
}
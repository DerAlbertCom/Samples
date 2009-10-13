using System;
using System.Web;
using System.Web.Mvc;
using Castle.Windsor;

namespace MvcUserGroupTour
{
    // Dient nur als Beispiel, besser die Factory für den IoC-Container der Wahl von http://mvccontrib.org verwenden
    internal class UserGroupWindsorControllerFactory : DefaultControllerFactory
    {
        private readonly WindsorContainer container;

        public UserGroupWindsorControllerFactory(WindsorContainer container)
        {
            this.container = container;
        }

        protected override IController GetControllerInstance(Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404,
                                        string.Format(" '{0}' nicht gefunden", RequestContext.HttpContext.Request.Path));
            }

            return (IController) container.Resolve(controllerType);
        }

        public override void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;

            if (disposable != null)
            {
                disposable.Dispose();
            }

            container.Release(controller);
        }
    }
}
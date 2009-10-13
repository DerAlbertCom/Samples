using System;
using MvcUserGroupTour.Objects;

namespace MvcUserGroupTour.Repositories
{
    public class RepositoryBase : IRepositoryBase
    {
        private NorthwindDataContext context;

        protected void ExecuteInDataContext(Action<NorthwindDataContext> action)
        {
            if (context != null)
            {
                action(context);
            }
            else
            {
                using (var ctx = new NorthwindDataContext())
                {
                    context = ctx;
                    action(ctx);
                    context = null;
                }
            }
        }

        public void ExecuteInDataContext(Action action)
        {
            ExecuteInDataContext(ctx => action());
        }
    }
}
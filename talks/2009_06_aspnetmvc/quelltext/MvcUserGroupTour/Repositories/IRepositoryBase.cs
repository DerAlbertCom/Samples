using System;

namespace MvcUserGroupTour.Repositories
{
    public interface IRepositoryBase
    {
        void ExecuteInDataContext(Action action);
    }
}
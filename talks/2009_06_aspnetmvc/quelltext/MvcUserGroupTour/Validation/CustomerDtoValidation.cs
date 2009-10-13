using System.Web.Mvc;
using MvcUserGroupTour.DataTransferObjects;

namespace MvcUserGroupTour.Validation
{
    public static class CustomerDtoValidation
    {
        public static void Validate(this CustomerDto customer, ModelStateDictionary modelState)
        {
            var errors = new ModelErrorDictionary<CustomerDto>(modelState);

            if (customer.CustomerID.Trim().Length != 5)
            {
                errors.AddModelError(c => c.CustomerID, "Die CustomerID muss 5 Zeichen lang sein");
            }
        }
    }
}
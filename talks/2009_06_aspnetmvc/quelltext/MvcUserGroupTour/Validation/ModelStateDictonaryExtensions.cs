using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Microsoft.Web.Mvc.Internal;

namespace MvcUserGroupTour.Validation
{
    public class ModelErrorDictionary<TModel> 
    {
        private readonly ModelStateDictionary modelState;

        public ModelErrorDictionary(ModelStateDictionary modelState)
        {
            this.modelState = modelState;
        }

        public void AddModelError<TProperty>(Expression<Func<TModel, TProperty>> expression, string errorMessage)
        {
            modelState.AddModelError(ExpressionHelper.GetInputName(expression), errorMessage);
        }
    }
}
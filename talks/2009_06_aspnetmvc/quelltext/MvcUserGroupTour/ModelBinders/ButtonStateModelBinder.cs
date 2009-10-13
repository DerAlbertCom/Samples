using System;
using System.Web.Mvc;
using MvcUserGroupTour.Models;

namespace MvcUserGroupTour.ModelBinders
{
    public class ButtonStateModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = ButtonState.None;
            if (bindingContext.ValueProvider.ContainsKey(bindingContext.ModelName))
            {
                result = ButtonState.Clicked;
            }
            return result;
        }
    }
}
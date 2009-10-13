/*
 * 15.02.2009 - Albert Weinert- erstellt.
 * 
 */
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

using Microsoft.Web.Mvc;
using Microsoft.Web.Mvc.Internal;

namespace MvcUserGroupTour.Extensions
{
    public static class FormExtensions
    {
        private static TProperty GetValue<TModel, TProperty>(HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            TModel model = htmlHelper.ViewData.Model;
            if (model == null)
            {
                return default(TProperty);
            }

            return expression.Compile()(model);
        }

        public static string NameFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            return ExpressionHelper.GetInputName(expression);
        }

        public static string IdFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            return ExpressionHelper.GetInputName(expression).Replace(".", "_");
        }


        public static string CheckBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            return htmlHelper.CheckBox(htmlHelper.NameFor(expression));
        }

        public static string ButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string caption)
            where TModel : class
        {
            return htmlHelper.Button(htmlHelper.NameFor(expression),caption,HtmlButtonType.Submit);
        }
        public static string LabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                         string caption) where TModel : class
        {
            return LabelFor(htmlHelper, expression, caption, new object());
        }

        public static string LabelFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                         string caption, object htmlAttributes)
            where TModel : class
        {
            var tag = new TagBuilder("label");
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
            tag.MergeAttribute("for", htmlHelper.IdFor(expression), true);
            tag.SetInnerText(caption);
            return tag.ToString();
        }

        public static string PasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            return PasswordFor(htmlHelper, expression, new RouteValueDictionary());
        }

        public static string PasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                            object htmlAttributes)
            where TModel : class
        {
            string inputName = ExpressionHelper.GetInputName(expression);
            TProperty value = GetValue(htmlHelper, expression);
            return htmlHelper.Password(inputName, value, new RouteValueDictionary(htmlAttributes));
        }

        public static string PostAction<TController>(this HtmlHelper htmlHelper, Expression<Action<TController>> action, string linkText)
            where TController : Controller
        {
            var url = htmlHelper.BuildUrlFromExpression(action);
            var builder = new TagBuilder("a");
            var href = string.Format("javascript:postUrl('{0}');", url);
            builder.MergeAttribute("href", href);
            builder.SetInnerText(linkText);
            return builder.ToString();
        }
    }
}
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Microsoft.Web.Mvc;


namespace MvcUserGroupTour.Extensions
{
    public static class CombinationFormsExtensions
    {
        private static TProperty GetValue<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            TModel model = htmlHelper.ViewData.Model;
            if (model == null)
            {
                return default(TProperty);
            }
            return expression.Compile()(model);
        }


        public static string LabelTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            return htmlHelper.LabelTextBoxFor(expression, htmlHelper.NameFor(expression) + ":");
        }

        public static string LabelTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                string caption) where TModel : class
        {
            string html = htmlHelper.LabelFor(expression, caption);
            html += htmlHelper.TextBoxFor(expression);
            html += htmlHelper.ValidationMessage(htmlHelper.NameFor(expression), "*");
            return html;
        }

        public static string LabelTextFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                             string caption) where TModel : class
        {
            string html = htmlHelper.LabelFor(expression, caption);
            html += "<span>" + htmlHelper.Encode(htmlHelper.GetValue(expression)) + "</span>";
            return html;
        }

        public static string LabelTextFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                             string caption, string format) where TModel : class
        {
            format = string.Format("{{0:{0}}}", format);
            string html = htmlHelper.LabelFor(expression, caption);
            html += "<span>" + htmlHelper.Encode(string.Format(format, htmlHelper.GetValue(expression))) + "</span>";
            return html;
        }

        public static string LabelPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                 string caption) where TModel : class
        {
            string html = htmlHelper.LabelFor(expression, caption);
            html += htmlHelper.PasswordFor(expression);
            html += htmlHelper.ValidationMessage(htmlHelper.NameFor(expression), "*");
            return html;
        }

        public static string LabelTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
            where TModel : class
        {
            return htmlHelper.LabelTextAreaFor(expression, htmlHelper.NameFor(expression) + ":");
        }

        public static string LabelTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression,
                                                                 string caption) where TModel : class
        {
            string html = htmlHelper.LabelFor(expression, caption);
            html += htmlHelper.TextAreaFor(expression);
            html += htmlHelper.ValidationMessage(htmlHelper.NameFor(expression), "*");
            return html;
        }
    }
}
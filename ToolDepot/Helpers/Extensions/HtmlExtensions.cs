using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ToolDepot.Helpers.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString BackLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            var sb = new StringBuilder("<a href=\"/");
            sb.Append(controllerName);
            sb.Append("/");
            sb.Append(actionName);
            sb.Append("\" ");
            sb.Append("class=\"btn btn-link\">");
            //sb.Append("<i class=\"icon-chevron-left icon-white\"></i>");
            sb.Append("«&nbsp;");
            if (string.IsNullOrEmpty(linkText))
            {
                linkText = "Take me back to previous page";
            }
            sb.Append(linkText);
            sb.Append("</a>");

            return MvcHtmlString.Create(sb.ToString());
        }
        public static MvcHtmlString Limit(this HtmlHelper htmlHelper, string text, int limitCount, int startIndex = 0)
        {
            var newText = text;
            if (newText.Length > limitCount)
            {
                newText = text.Substring(startIndex, limitCount) + "...";
            }
            return MvcHtmlString.Create(newText);
        }
        public static MvcHtmlString FileFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression)
        {
            string name = GetFullPropertyName(expression);
            return html.File(name);
        }
        public static MvcHtmlString File(this HtmlHelper html, string name)
        {
            var tb = new TagBuilder("input");
            tb.Attributes.Add("type", "file");
            tb.Attributes.Add("name", name);
            tb.GenerateId(name);
            return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));
        }
        public static MvcHtmlString RequiredHint(this HtmlHelper helper, string additionalText = null)
        {
            // Create tag builder
            var builder = new TagBuilder("span");
            builder.AddCssClass("required");
            var innerText = "*";
            //add additinal text if specified
            if (!String.IsNullOrEmpty(additionalText))
                innerText += " " + additionalText;
            builder.SetInnerText(innerText);
            // Render tag
            return MvcHtmlString.Create(builder.ToString());
        }
        #region Helpers

        static string GetFullPropertyName<T, TProperty>(Expression<Func<T, TProperty>> exp)
        {
            MemberExpression memberExp;

            if (!TryFindMemberExpression(exp.Body, out memberExp))
                return string.Empty;

            var memberNames = new Stack<string>();

            do
            {
                memberNames.Push(memberExp.Member.Name);
            }
            while (TryFindMemberExpression(memberExp.Expression, out memberExp));

            return string.Join(".", memberNames.ToArray());
        }
        static bool TryFindMemberExpression(Expression exp, out MemberExpression memberExp)
        {
            memberExp = exp as MemberExpression;

            if (memberExp != null)
                return true;

            if (IsConversion(exp) && exp is UnaryExpression)
            {
                memberExp = ((UnaryExpression)exp).Operand as MemberExpression;

                if (memberExp != null)
                    return true;
            }

            return false;
        }

        static bool IsConversion(Expression exp)
        {
            return (exp.NodeType == ExpressionType.Convert || exp.NodeType == ExpressionType.ConvertChecked);
        }

        #endregion
    }
}
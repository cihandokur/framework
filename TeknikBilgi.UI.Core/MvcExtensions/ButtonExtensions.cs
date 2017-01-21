using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace TeknikBilgi.UI.Core.MvcExtensions
{
    public static class ButtonExtensions
    {
        public static MvcHtmlString ButtonSearch(this HtmlHelper html, string value = "")
        {
            return html.Partial("~/Views/Shared/Buttons/Search.cshtml", value);
        }

        public static MvcHtmlString ButtonNew(this HtmlHelper html, string url)
        {
            return html.Partial("~/Views/Shared/Buttons/New.cshtml", url);
        }

        public static MvcHtmlString ButtonGoBack(this HtmlHelper html, string url)
        {
            return html.Partial("~/Views/Shared/Buttons/GoBack.cshtml", url);
        }

        public static MvcHtmlString ButtonCancel(this HtmlHelper html, string url)
        {
            return html.Partial("~/Views/Shared/Buttons/Cancel.cshtml", url);
        }

        public static MvcHtmlString ButtonSave(this HtmlHelper html, string value = "")
        {
            return html.Partial("~/Views/Shared/Buttons/Save.cshtml", value);
        }

        public static MvcHtmlString ButtonSaveAndClose(this HtmlHelper html, string value = "")
        {
            return html.Partial("~/Views/Shared/Buttons/SaveAndClose.cshtml", value);
        }

        public static MvcHtmlString ButtonDelete(this HtmlHelper html, string value = "")
        {
            return html.Partial("~/Views/Shared/Buttons/Delete.cshtml", value);
        }

        public static MvcHtmlString ButtonDeleteLink(this HtmlHelper html, string value = "")
        {
            return html.Partial("~/Views/Shared/Buttons/DeleteLink.cshtml", value);
        }

        public static MvcHtmlString ButtonDetail(this HtmlHelper html, string value = "")
        {
            return html.Partial("~/Views/Shared/Buttons/Detail.cshtml", value);
        }

        public static MvcHtmlString ButtonEdit(this HtmlHelper html, string value = "")
        {
            return html.Partial("~/Views/Shared/Buttons/Edit.cshtml", value);
        }
    }
}
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace TeknikBilgi.UI.Core.MvcExtensions
{
    public static class HtmlExtension
    {
        public static IHtmlString Script(this HtmlHelper htmlHelper, string server, string path, string cacheParam = "")
        {
            var attributes = new Dictionary<string, object>
            {
                { "src", string.Format("{0}{1}{2}", server, path, cacheParam) },
                { "type", "text/javascript" }
            };
            return Generic(htmlHelper, "script", attributes, TagRenderMode.Normal);
        }

        public static IHtmlString Style(this HtmlHelper htmlHelper, string server, string path, string cacheParam = "")
        {
            var attributes = new Dictionary<string, object>
            {
                { "href", string.Format("{0}{1}{2}", server, path, cacheParam) },
                { "type", "text/css" },
                { "rel", "stylesheet" }
            };
            return Generic(htmlHelper, "link", attributes);
        }

        private static IHtmlString Generic(this HtmlHelper htmlHelper,
            string htmlTag,
            Dictionary<string, object> attributes,
            TagRenderMode tagRenderMode = TagRenderMode.SelfClosing)
        {
            var builder = new TagBuilder(htmlTag);
            builder.MergeAttributes(attributes);
            return MvcHtmlString.Create(builder.ToString(tagRenderMode));
        }
    }
}

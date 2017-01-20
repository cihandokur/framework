using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TeknikBilgi.UI.Core.Controllers
{
    public abstract class BaseController : Controller
    {
        public T TaskCheck<T>(Task<T> task) where T : new()
        {
            return (task.Status == TaskStatus.RanToCompletion && task.Result != null) ? task.Result : new T();
        }

        protected string RenderPartialViewToString()
        {
            return RenderPartialViewToString(null, null);
        }

        protected string RenderPartialViewToString(string viewName)
        {
            return RenderPartialViewToString(viewName, null);
        }

        protected string RenderPartialViewToString(object model)
        {
            return RenderPartialViewToString(null, model);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        public ModelErrorCollection GetModelErrors()
        {
            var modelError = new ModelErrorCollection();
            foreach (var error in ViewData.ModelState.Values.SelectMany(entry => entry.Errors))
            {
                modelError.Add(error);
            }
            return modelError;
        }

        public string Errors(ModelErrorCollection modelError)
        {
            if (modelError == null) return (string.Empty);
            var ulTag = new TagBuilder("ul");
            
            ulTag.InnerHtml += Environment.NewLine;
            foreach (var liTag in modelError.Select(error => new TagBuilder("li") { InnerHtml = error.ErrorMessage }))
            {
                ulTag.InnerHtml += string.Format("{0}{1}", liTag, Environment.NewLine);
            }
            //ulTag.MergeAttributes(htmlAttributes);
            return (ulTag.ToString());
        }

        public JsonResult JsonResult(object obj)
        {
            return Json(obj, "text/json", Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
    }
}
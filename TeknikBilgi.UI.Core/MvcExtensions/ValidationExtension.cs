using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TeknikBilgi.Infrastructure.Constraints.Enums.Types;
using TeknikBilgi.Infrastructure.Constraints.Structs;
using TeknikBilgi.UI.Core.Manager;
using TeknikBilgi.UI.Core.ViewModel.TempData;

namespace TeknikBilgi.UI.Core.MvcExtensions
{
    public static class ValidationExtension
    {
        public static List<TempDataMessageViewModel> GetValidationSummary<TModel>(this HtmlHelper<TModel> htmlHelper,
    bool excludePropertyErrors = false,
    bool addTempDataMessages = false,
    string tempDataMessageKey = Keys.TempDataMessage.General)
        {
            var list = new List<TempDataMessageViewModel>();
            if (!htmlHelper.ViewData.ModelState.IsValid)
            {
                list.Add(new TempDataMessageViewModel
                {
                    MessageString = htmlHelper.ValidationSummary(excludePropertyErrors).ToHtmlString().Replace(Environment.NewLine, ""),
                    MessageTypeId = TempDataMessage.Error,
                    AutoClose = false
                });
            }
            if (addTempDataMessages)
            {
                var temp = htmlHelper.ViewContext.Controller.TempData.GetMessage(tempDataMessageKey).ToList();
                list = temp.Concat(list).ToList();
            }

            return list;
        }
    }
}
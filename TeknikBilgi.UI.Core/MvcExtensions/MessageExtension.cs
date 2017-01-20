using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TeknikBilgi.Infrastructure.Constraints.Enums.Types;
using TeknikBilgi.UI.Core.ViewModel.TempData;

namespace TeknikBilgi.UI.Core.MvcExtensions
{
    public static class MessageExtension
    {
        public static IHtmlString MessagePartialFor(this HtmlHelper htmlHelper,
            List<TempDataMessageViewModel> messageModel,
            bool clearBefore = false,
            bool isMessageToParent = false,
            bool isScriptTagEnabled = false)
        {
            var model = new TempDataMessageContainerViewModel
            {
                IsClearNotificationsSet = clearBefore,
                IsParentNotificationsSet = isMessageToParent,
                MessageList = (messageModel != null && messageModel.Any()) ? messageModel : new List<TempDataMessageViewModel>()
            };

            model.IsScriptTagEnabled = isScriptTagEnabled && (model.IsClearNotificationsSet || model.MessageList.Any());
            var cssPrefix = model.IsScriptTagEnabled ? "alert-" : "note-";
            foreach (var item in model.MessageList)
            {
                var itemCss = "info";
                switch (item.MessageTypeId)
                {
                    case TempDataMessage.Success:
                        itemCss = "success";
                        break;
                    case TempDataMessage.Warning:
                        itemCss = "warning";
                        break;
                    case TempDataMessage.Error:
                        itemCss = "danger";
                        break;
                }
                item.CssClass = string.Concat(cssPrefix, itemCss);
            }
            return htmlHelper.Partial("~/Views/Shared/Messages/_MessagePartial.cshtml", model);
        }
    }
}
using System.Collections.Generic;

namespace TeknikBilgi.UI.Core.ViewModel.TempData
{
    public class TempDataMessageContainerViewModel
    {
        public List<TempDataMessageViewModel> MessageList { get; set; }

        public bool IsScriptTagEnabled { get; set; }

        public bool IsClearNotificationsSet { get; set; }

        public bool IsParentNotificationsSet { get; set; }
    }
}
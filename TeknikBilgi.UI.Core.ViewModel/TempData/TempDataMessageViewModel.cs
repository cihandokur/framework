using System;
using System.Globalization;
using TeknikBilgi.Infrastructure.Constraints.Enums.Types;

namespace TeknikBilgi.UI.Core.ViewModel.TempData
{
    [Serializable]
    public class TempDataMessageViewModel
    {
        public string MessageString { get; set; }
        public TempDataMessage MessageTypeId { get; set; }
        public bool AutoClose { get; set; }
        public short AutoCloseSecond { get; set; }
        public string CssClass { get; set; }
        public string AutoCloseString { get { return AutoClose ? "auto-close" : ""; } }
        public string AutoCloseMiliSecond
        {
            get { return AutoCloseSecond > 0 ? (AutoCloseSecond * 1000).ToString(CultureInfo.InvariantCulture) : ""; }
        }
    }
}
using TeknikBilgi.Infrastructure.Constraints.Structs;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TeknikBilgi.Infrastructure.Constraints.Enums.Types;
using TeknikBilgi.UI.Core.ViewModel.TempData;

namespace TeknikBilgi.UI.Core.Manager
{
    public static class TempDataManager
    {
        public static IEnumerable<TempDataMessageViewModel> GetMessage(this TempDataDictionary tempData, string key = Keys.TempDataMessage.General)
        {
            if (key == null) throw new ArgumentNullException("key");
            if (tempData[key] == null)
                yield break;
            var messageList = tempData[key] as List<TempDataMessageViewModel>;
            if (messageList != null)
                foreach (var item in messageList)
                    yield return item;
        }

        public static void SetMessage(this TempDataDictionary tempData, TempDataMessageViewModel message, string key = Keys.TempDataMessage.General)
        {
            if (tempData[key] == null)
                tempData[key] = new List<TempDataMessageViewModel>();

            var messageList = tempData[key] as List<TempDataMessageViewModel>;
            messageList.Add(message);
        }

        public static void SetMessage(this TempDataDictionary tempData, string messageString, TempDataMessage messageType,
            string key = Keys.TempDataMessage.General, bool autoClose = true, short autoCloseSecond = 5)
        {
            tempData.SetMessage(new TempDataMessageViewModel
            {
                MessageString = messageString,
                MessageTypeId = messageType,
                AutoClose = autoClose,
                AutoCloseSecond = autoCloseSecond
            }, key);
        }

        public static void SetMessage(this TempDataDictionary tempData, string messageString, TempDataMessage messageType, string key = Keys.TempDataMessage.General)
        {
            tempData.SetMessage(new TempDataMessageViewModel
            {
                MessageString = messageString,
                MessageTypeId = messageType,
                AutoClose = false
            }, key);
        }
        public static void SetMessage(this TempDataDictionary tempData, string messageString, TempDataMessage messageType)
        {
            tempData.SetMessage(new TempDataMessageViewModel
            {
                MessageString = messageString,
                MessageTypeId = messageType,
                AutoClose = false
            });
        }

    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using TeknikBilgi.Infrastructure.Constraints.Enums.Types;

namespace TeknikBilgi.Infrastructure.AppConfiguration
{
    public class AppConfigBase
    {
        static AppConfigBase()
        {
            AppKeyValueList = new Dictionary<string, string>();
            ApplicationId = Convert.ToInt32(ConfigurationManager.AppSettings["ApplicationId"]);
            Application = (Applications)ApplicationId;
            ApplicationMode = ConfigurationManager.AppSettings["ApplicationMode"];
            ApplicationModeSplitted = ConfigurationManager.AppSettings["ApplicationMode"].Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }
        public static Dictionary<string, string> AppKeyValueList { get; protected set; }

        public static string GetValue(string key)
        {
            return AppKeyValueList[key];
        }

        public static Applications Application
        {
            get;
            protected set;
        }

        public static string ApplicationMode
        {
            get;
            protected set;
        }

        public static string ApplicationModeSplitted
        {
            get;
            protected set;
        }

        public static int ApplicationId
        {
            get;
            protected set;
        }

        public static string LastRefreshDate
        {
            get;
            protected set;
        }
    }
}
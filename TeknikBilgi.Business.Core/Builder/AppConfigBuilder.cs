using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using TeknikBilgi.Business.Core.Interface;
using TeknikBilgi.Infrastructure.AppConfiguration;
using TeknikBilgi.Infrastructure.Extension;

namespace TeknikBilgi.Business.Core.Builder
{
    public class AppConfigBuilder
    {
        private readonly IApplicationBusiness _applicationBusiness;
        public AppConfigBuilder(IApplicationBusiness applicationBusiness)
        {
            _applicationBusiness = applicationBusiness;
        }

        public void RegisterAppConfig<T>(T appConfigInstance) //where T : AppConfigBase
        {
            var keys = LoadKeys();
            var t = appConfigInstance?.GetType() ?? typeof(T);

            if (t.BaseType == null)
                return;

            var propId = t.BaseType.GetProperty(ExpressionMethods.GetMemberName<AppConfigBase>(@base => AppConfigBase.ApplicationId),
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            propId.SetValue(appConfigInstance, GetTypeValue(propId, _applicationBusiness.GetApplication(AppConfigBase.Application).Id.ToString()), null);


            var propKeys = t.BaseType.GetProperty(ExpressionMethods.GetMemberName<AppConfigBase>(@base => AppConfigBase.AppKeyValueList),
                    BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            propKeys.SetValue(appConfigInstance, keys, null);

            var propLrd = t.BaseType.GetProperty(ExpressionMethods.GetMemberName<AppConfigBase>(@base => AppConfigBase.LastRefreshDate),
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            if (keys.ContainsKey(propLrd.Name))
                propLrd.SetValue(appConfigInstance, GetTypeValue(propLrd, keys[propLrd.Name]), null);

            var props = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (var prop in props)
            {
                if (keys.ContainsKey(prop.Name))
                {
                    prop.SetValue(appConfigInstance, GetTypeValue(prop, keys[prop.Name]), null);
                }
                else if (ConfigurationManager.AppSettings.AllKeys.Contains(prop.Name))
                {
                    prop.SetValue(appConfigInstance, GetTypeValue(prop, keys[prop.Name]), null);
                }
            }
        }

        /// <summary>
        /// sets type values will be filled
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="propValue"></param>
        /// <returns></returns>
        private static object GetTypeValue(PropertyInfo prop, string propValue)
        {
            switch (Type.GetTypeCode(prop.PropertyType))
            {
                case TypeCode.String:
                    return propValue;
                case TypeCode.Boolean:
                    return bool.Parse(propValue);
                case TypeCode.Byte:
                    return byte.Parse(propValue);
                case TypeCode.Int32:
                    return int.Parse(propValue);
                case TypeCode.Object:
                    if (prop.PropertyType == typeof(Guid))
                    {
                        return Guid.Parse(propValue);
                    }
                    break;
                case TypeCode.Int16:
                    return short.Parse(propValue);
                case TypeCode.Int64:
                    return long.Parse(propValue);
                case TypeCode.Double:
                    return double.Parse(propValue);
                case TypeCode.Decimal:
                    return decimal.Parse(propValue);
                case TypeCode.DateTime:
                    return DateTime.Parse(propValue);
            }
            return null;
        }

        public void RefreshAppConfig<T>(T appConfigInstance) //where T : AppConfigBase
        {
            RegisterAppConfig(appConfigInstance);
        }

        private Dictionary<string, string> LoadKeys()
        {
            _applicationBusiness.SetApplicationConfigValueBy(AppConfigBase.Application, AppConfigBase.ApplicationMode, ExpressionMethods.GetMemberName<AppConfigBase>(@base => AppConfigBase.LastRefreshDate), DateTime.UtcNow.ToString(CultureInfo.InvariantCulture), null, Infrastructure.Constraints.Enums.Status.ApplicationConfig.Active);
            var appConfigItems = new Dictionary<string, string>();

            var appModeLevels = AppConfigBase.ApplicationMode.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var currentAppModeLevel = string.Empty;
            foreach (var rootMode in appModeLevels)
            {
                currentAppModeLevel += string.IsNullOrWhiteSpace(currentAppModeLevel) ? rootMode : string.Format(".{0}", rootMode);
                var appConfigList = _applicationBusiness.GetAllApplicationConfigBy(AppConfigBase.Application, currentAppModeLevel, Infrastructure.Constraints.Enums.Status.ApplicationConfig.Active);
                foreach (var applicationConfig in appConfigList)
                {
                    if (appConfigItems.ContainsKey(applicationConfig.Key))
                    {
                        appConfigItems[applicationConfig.Key] = applicationConfig.Value;
                        continue;
                    }
                    appConfigItems.Add(applicationConfig.Key, applicationConfig.Value);
                }
            }
            return appConfigItems;
        }
    }
}
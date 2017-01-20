using System;
using System.Collections.Generic;
using System.Linq;
using TeknikBilgi.Business.Core.Interface;
using TeknikBilgi.Data.Core.Entity.Application;
using TeknikBilgi.Data.Core.Interface;
using TeknikBilgi.Infrastructure.AppConfiguration;
using TeknikBilgi.Infrastructure.Constraints.Enums.Types;

namespace TeknikBilgi.Business.Core.Implement
{
    public class ApplicationBusiness : IApplicationBusiness
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationBusiness(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public ApplicationConfig GetApplicationConfigBy(Applications application, string mode, string key)
        {
            var data = _applicationRepository.GetApplicationConfigBy(application, AppConfigBase.ApplicationMode, key) ??
                       _applicationRepository.GetApplicationConfigBy(application, AppConfigBase.ApplicationModeSplitted, key);
            return data;
        }

        public ApplicationConfig GetApplicationConfigBy(Applications application, string key)
        {
            return GetApplicationConfigBy(application, AppConfigBase.ApplicationMode, key);
        }

        public ApplicationConfig GetApplicationConfigBy(string mode, string key)
        {
            return GetApplicationConfigBy(AppConfigBase.Application, mode, key);
        }

        public ApplicationConfig GetApplicationConfigBy(string key)
        {
            return GetApplicationConfigBy(AppConfigBase.Application, AppConfigBase.ApplicationMode, key);
        }

        public string GetApplicationConfigValueBy(Applications application, string mode, string key)
        {
            var appConfig = GetApplicationConfigBy(application, mode, key);
            return appConfig?.Value;
        }

        public string GetApplicationConfigValueBy(Applications application, string key)
        {
            return GetApplicationConfigValueBy(application, AppConfigBase.ApplicationMode, key);
        }

        public string GetApplicationConfigValueBy(string mode, string key)
        {
            return GetApplicationConfigValueBy(AppConfigBase.Application, mode, key);
        }

        public string GetApplicationConfigValueBy(string key)
        {
            return GetApplicationConfigValueBy(AppConfigBase.Application, AppConfigBase.ApplicationMode, key);
        }

        private string _imageBaseUrl { get; set; }

        public string ImageBaseUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_imageBaseUrl))
                {
                    _imageBaseUrl = GetApplicationConfigValueBy(AppConfigBase.Application, AppConfigBase.ApplicationMode, "ImageBaseUrl");
                }
                return _imageBaseUrl;
            }
        }

        private string _defaultImagePath { get; set; }

        public string DefaultImagePath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_defaultImagePath))
                {
                    _defaultImagePath = GetApplicationConfigValueBy(AppConfigBase.Application, AppConfigBase.ApplicationMode, "DefaultImagePath");
                }
                return _defaultImagePath;
            }
        }

        public T GetApplicationConfigValueBy<T>(string key, T defaultValue = default(T))
        {
            var keyValue = GetApplicationConfigValueBy(key);
            try
            {
                if (string.IsNullOrEmpty(keyValue))
                    return defaultValue;

                return (T)Convert.ChangeType(keyValue, typeof(T));
            }
            catch (Exception)
            {

                return default(T);
            }
        }

        public IList<ApplicationConfig> GetAllApplicationConfigBy(Applications application, string mode, Infrastructure.Constraints.Enums.Status.ApplicationConfig statusId)
        {
            return _applicationRepository.GetAllApplicationConfigBy(application, mode, statusId).ToList();
        }

        public IList<ApplicationConfig> GetAllApplicationConfigBy(Applications application, string mode)
        {
            return _applicationRepository.GetAllApplicationConfigBy(application, mode).ToList();
        }

        public IList<ApplicationConfig> GetAllApplicationConfigBy(Applications application)
        {
            return GetAllApplicationConfigBy(application, AppConfigBase.ApplicationMode);
        }

        public IList<ApplicationConfig> GetAllApplicationConfigBy(string mode)
        {
            return GetAllApplicationConfigBy(AppConfigBase.Application, mode);
        }

        public IList<ApplicationConfig> GetAllApplicationConfigBy()
        {
            return GetAllApplicationConfigBy(AppConfigBase.Application, AppConfigBase.ApplicationMode);
        }

        public Application GetApplication(Applications application)
        {
            return _applicationRepository.GetApplication(application, (int)Infrastructure.Constraints.Enums.Status.Application.Active);
        }

        public void SetApplicationConfigValueBy(Applications application, string mode, string key, string value, string description, Infrastructure.Constraints.Enums.Status.ApplicationConfig statusId)
        {
            _applicationRepository.SetApplicationConfigBy(application, mode, key, value, description, (int)statusId);
        }

        public void SetApplicationConfigValueBy(Applications application, string mode, string key, string value)
        {
            SetApplicationConfigValueBy(application, mode, key, value, null, Infrastructure.Constraints.Enums.Status.ApplicationConfig.Passive);
        }

        public void SetApplicationConfigValueBy(Applications application, string key, string value)
        {
            SetApplicationConfigValueBy(application, AppConfigBase.ApplicationMode, key, value, null, Infrastructure.Constraints.Enums.Status.ApplicationConfig.Passive);
        }
        public void SetApplicationConfigValueBy(string mode, string key, string value)
        {
            SetApplicationConfigValueBy(AppConfigBase.Application, mode, key, value, null, Infrastructure.Constraints.Enums.Status.ApplicationConfig.Passive);
        }

        public void SetApplicationConfigValueBy(string key, string value)
        {
            SetApplicationConfigValueBy(AppConfigBase.Application, AppConfigBase.ApplicationMode, key, value, null, Infrastructure.Constraints.Enums.Status.ApplicationConfig.Passive);
        }

        public Application AddApplicationBy(Applications application, string name, string description, int? orderNumber, Infrastructure.Constraints.Enums.Status.Application statusId)
        {
            var applicationInfo = _applicationRepository.AddApplicationBy(application, name, description, orderNumber, (int)statusId);
            return applicationInfo;
        }

        public void UpdateApplicationBy(int applicationId, string name, string description, int? orderNumber, Infrastructure.Constraints.Enums.Status.Application status)
        {
            _applicationRepository.UpdateApplicationBy(applicationId, name, description, orderNumber, (int)status);
        }
    }
}
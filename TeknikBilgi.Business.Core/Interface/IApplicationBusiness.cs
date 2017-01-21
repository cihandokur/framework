using System.Collections.Generic;
using TeknikBilgi.Data.Core.Entity.Application;
using TeknikBilgi.Infrastructure.Constraints.Enums.Types;

namespace TeknikBilgi.Business.Core.Interface
{
    public interface IApplicationBusiness
    {
        #region ApplicationConfig

        /// <summary>
        /// given app, given mode, given key
        /// </summary>
        /// <param name="application"></param>
        /// <param name="mode"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        ApplicationConfig GetApplicationConfigBy(Applications application, string mode, string key);
        /// <summary>
        /// current mode, given app, given key
        /// </summary>
        /// <param name="application"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        ApplicationConfig GetApplicationConfigBy(Applications application, string key);
        /// <summary>
        /// current app, given mode, given key
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        ApplicationConfig GetApplicationConfigBy(string mode, string key);
        /// <summary>
        /// current app, current mode, given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        ApplicationConfig GetApplicationConfigBy(string key);

        /// <summary>
        /// given app, given mode, given key
        /// </summary>
        /// <param name="application"></param>
        /// <param name="mode"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetApplicationConfigValueBy(Applications application, string mode, string key);
        /// <summary>
        /// current mode, given app, given key
        /// </summary>
        /// <param name="application"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetApplicationConfigValueBy(Applications application, string key);
        /// <summary>
        /// current app, given mode, given key
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetApplicationConfigValueBy(string mode, string key);
        /// <summary>
        /// current app, current mode, given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetApplicationConfigValueBy(string key);

        /// <summary>
        /// current app, current mode, given key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns>Return T</returns>
        T GetApplicationConfigValueBy<T>(string key, T defaultValue = default(T));

        /// <summary>
        /// given app, given mode, given isActive
        /// </summary>
        /// <param name="application"></param>
        /// <param name="mode"></param>
        /// <param name="statusId"></param>
        /// <returns></returns>
        IList<ApplicationConfig> GetAllApplicationConfigBy(Applications application, string mode, Infrastructure.Constraints.Enums.Status.ApplicationConfig statusId);
        /// <summary>
        /// given app, given mode
        /// </summary>
        /// <param name="application"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        IList<ApplicationConfig> GetAllApplicationConfigBy(Applications application, string mode);
        /// <summary>
        /// given app, current mode
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        IList<ApplicationConfig> GetAllApplicationConfigBy(Applications application);
        /// <summary>
        /// current app, given mode
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        IList<ApplicationConfig> GetAllApplicationConfigBy(string mode);
        /// <summary>
        /// current app, current mode
        /// </summary>
        /// <returns></returns>
        IList<ApplicationConfig> GetAllApplicationConfigBy();


        ///// <summary>
        ///// given app, given mode, given key, given value, given description
        ///// </summary>
        ///// <param name="application"></param>
        ///// <param name="mode"></param>
        ///// <param name="key"></param>
        ///// <param name="value"></param>
        ///// <param name="description"></param>
        ///// <param name="statusId"></param>
        void SetApplicationConfigValueBy(Applications application, string mode, string key, string value, string description, Infrastructure.Constraints.Enums.Status.ApplicationConfig statusId);

        #endregion

        Application GetApplication(Applications application);

        string ImageBaseUrl { get; }

        string DefaultImagePath { get; }
    }
}
using System.Collections.Generic;
using TeknikBilgi.Data.Core.Entity.Application;
using TeknikBilgi.Infrastructure.Constraints.Enums.Types;

namespace TeknikBilgi.Data.Core.Interface
{
    public interface IApplicationRepository
    {
        IEnumerable<ApplicationConfig> GetAllApplicationConfigBy(Applications application, string mode, Infrastructure.Constraints.Enums.Status.ApplicationConfig status = Infrastructure.Constraints.Enums.Status.ApplicationConfig.Active);
        ApplicationConfig GetApplicationConfigBy(Applications application, string mode, string key);
        void SetApplicationConfigBy(Applications application, string mode, string key, string value, string description, int statusId);

        Application AddApplicationBy(Applications application, string name, string description, int? orderNumber, int statusId);

        void UpdateApplicationBy(int applicationId, string name, string description, int? orderNumber, int status);

        Application GetApplication(Applications application, int statusId);
    }
}
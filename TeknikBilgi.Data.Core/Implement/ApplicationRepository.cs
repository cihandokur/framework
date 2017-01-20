using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TeknikBilgi.Data.Core.Entity.Application;
using TeknikBilgi.Data.Core.Interface;
using TeknikBilgi.Infrastructure.Constraints.Enums.Types;
using ConfigStatus = TeknikBilgi.Infrastructure.Constraints.Enums.Status.ApplicationConfig;

namespace TeknikBilgi.Data.Core.Implement
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IDbConnection _connection;
        public ApplicationRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<ApplicationConfig> GetAllApplicationConfigBy(Applications application, string mode, ConfigStatus status = ConfigStatus.Active)
        {
            var result = _connection.Query<ApplicationConfig>("GetApplicationConfigByStatus",
                new
                {
                    ApplicationId = application,
                    ApplicationMode = mode,
                    StatusId = status
                }, commandType: CommandType.StoredProcedure);

            return result;

        }

        public ApplicationConfig GetApplicationConfigBy(Applications application, string mode, string key)
        {
            return _connection.Query<ApplicationConfig>("GetApplicationConfigByKey", new
            {
                ApplicationId = application,
                ApplicationMode = mode,
                Key = key
            }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void SetApplicationConfigBy(Applications application, string mode, string key, string value, string description, int statusId)
        {
            _connection.Execute("UpdateApplicationConfigByKey", new
            {
                ApplicationId = application,
                ApplicationMode = mode,
                Key = key,
                Value = value,
                Description = description,
                StatusId = statusId
            }, commandType: CommandType.StoredProcedure);
        }

        public Application AddApplicationBy(Applications application, string name, string description, int? orderNumber, int statusId)
        {
            return _connection.Query<Application>("AddApplicationBy", new
            {
                ApplicationId = application,
                Name = name,
                Description = description,
                OrderNumber = orderNumber,
                StatusId = statusId
            }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void UpdateApplicationBy(int applicationId, string name, string description, int? orderNumber, int status)
        {
            _connection.Execute("UpdateApplicationBy",
                new
                {
                    Id = applicationId,
                    Name = name,
                    Description = description,
                    OrderNumber = orderNumber,
                    StatusId = status
                }, commandType: CommandType.StoredProcedure);
        }

        public Application GetApplication(Applications application, int statusId)
        {
            return _connection.Query<Application>("GetApplicationById", new
            {
                ApplicationId = application,
                StatusId = statusId
            }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

    }
}
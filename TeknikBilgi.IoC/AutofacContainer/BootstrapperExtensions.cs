using Autofac;
using Autofac.Builder;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TeknikBilgi.IoC.AutofacContainer
{
    public static class BootstrapperExtensions
    {
        public static IRegistrationBuilder<IDbConnection, SimpleActivatorData, SingleRegistrationStyle> SqlConnection(this ContainerBuilder builder, string conStrConfigName, object key = null)
        {
            var result =  key == null
                ? builder.Register<IDbConnection>(c => new SqlConnection(ConfigurationManager.ConnectionStrings[conStrConfigName].ConnectionString))
                : builder.Register<IDbConnection>(c => new SqlConnection(ConfigurationManager.ConnectionStrings[conStrConfigName].ConnectionString)).Keyed(key, typeof(IDbConnection));
            return result;
        }
    }
}